using Carter;
using HaccpBackend.Data;
using HaccpBackend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UserEntity = HaccpBackend.Domain.Entities.User;

namespace HaccpBackend.Features.User
{
    public static class RegisterUser
    {
        public sealed record Command(
            string UserName,
            string Email,
            int OrganizationID,
            string Password
        ) : IRequest<int>;

        internal sealed class Handler : IRequestHandler<Command, int>
        {
            private readonly AppDataContext _appDataContext;
            private readonly UserManager<UserEntity> _userManager;

            public Handler(AppDataContext appDataContext, UserManager<UserEntity> userManager)
            {
                _appDataContext = appDataContext;
                _userManager = userManager;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                Organization organization =
                    await _appDataContext.Organizations.FindAsync(
                        request.OrganizationID,
                        cancellationToken
                    ) ?? throw new Exception("Organization not found");

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

        public class Endpoint : ICarterModule
        {
            public void AddRoutes(IEndpointRouteBuilder app)
            {
                app.MapPost(
                    "api/signup",
                    async (Command command, ISender sender) =>
                    {
                        int userId = await sender.Send(command);

                        return Results.Ok(userId);
                    }
                );
            }
        }
    }
}
