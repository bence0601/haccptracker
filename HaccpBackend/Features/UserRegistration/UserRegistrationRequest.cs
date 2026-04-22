 namespace HaccpBackend.Features.UserRegistration
{
    public sealed record UserRegistrationRequest(
        string UserName,
        string Email,
        string Password);
}
