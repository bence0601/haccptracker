using FluentValidation;
using HaccpBackend.Data;
using HaccpBackend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static HaccpBackend.Features.User._Shared;

namespace HaccpBackend.Features.User
{
    public static class GetAllUsers
    {
        public sealed record Query : IRequest<List<UserResponse>>;

        internal sealed class Handler : IRequestHandler<Query, List<UserResponse>>
        {
            private readonly AppDataContext _appDataContext;

            public Handler(AppDataContext appDataContext)
            {
                _appDataContext = appDataContext;
            }

            public async Task<List<UserResponse>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
                return await _appDataContext
                    .Users.AsNoTracking()
                    .Select(u => new UserResponse(u.Id!, u.UserName!, u.Email!, u.Organization.Id))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
