using System.ComponentModel.DataAnnotations;
using Carter;
using FluentValidation;
using HaccpBackend.Data;
using HaccpBackend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using UserEntity = HaccpBackend.Domain.Entities.User;

namespace HaccpBackend.Features.User
{
    public static class RegisterUser
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// This should return something other than int in a real application, but for the sake of simplicity, we'll return the user ID. ///
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public sealed record Command(
            string UserName,
            string Email,
            int OrganizationID,
            string Password
        ) : IRequest<int>;

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.UserName).NotEmpty();
                RuleFor(c => c.Email).EmailAddress();
                RuleFor(c => c.OrganizationID).NotNull();

                /////////////////////////////////////////////////////////////////
                /// Password validation should be stricter in PRD environment ///
                /////////////////////////////////////////////////////////////////

                RuleFor(c => c.Password).NotEmpty().Length(8, 32);
            }
        }

        internal sealed class Handler : IRequestHandler<Command, int>
        {
            private readonly AppDataContext _appDataContext;
            private readonly UserManager<UserEntity> _userManager;
            private readonly IValidator<Command> _validator;

            public Handler(
                AppDataContext appDataContext,
                UserManager<UserEntity> userManager,
                IValidator<Command> validator
            )
            {
                _appDataContext = appDataContext;
                _userManager = userManager;
                _validator = validator;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                _validator.ValidateAndThrow(request);

                Organization organization =
                    await _appDataContext.Organizations.FindAsync(
                        request.OrganizationID,
                        cancellationToken
                    ) ?? throw new KeyNotFoundException("Organization not found");

                UserEntity user = new UserEntity
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    Organization = organization,
                };

                user.PasswordHash = _userManager.PasswordHasher.HashPassword(
                    user,
                    request.Password
                );

                _appDataContext.Add(user);

                await _appDataContext.SaveChangesAsync(cancellationToken);

                return user.Id;
            }
        }
    }

    public class RegisterUserEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost(
                "api/signup",
                async (RegisterUser.Command command, ISender sender) =>
                {
                    int userId = await sender.Send(command);

                    return Results.Ok(userId);
                }
            );
        }
    }
}
