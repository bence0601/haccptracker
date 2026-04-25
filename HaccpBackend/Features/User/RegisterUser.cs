namespace HaccpBackend.Features.User
{
    public static class RegisterUser
    {
        public sealed record Command(
        string UserName,
        string Email,
        string Password);

    }
}

