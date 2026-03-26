namespace ProjectEventAssos.Core.Service.Auth;

using ProjectEventAssos.Core.Dto.Requests;
using ProjectEventAssos.Domain.Models;

internal class AuthService(
    IUserRepository _userRepository,
    IPasswordHasherService _passwordHasherService,
    IJwtService _jwtService
    ) : IAuthService
{
    public async Task<LoginResponseDTO> Login(LoginRequestDTO credentials)
    {
        if (string.IsNullOrWhiteSpace(credentials.Email) || string.IsNullOrWhiteSpace(credentials.Password))
            throw new ArgumentException("Email et mot de passe sont requis");

        var user = await _userRepository.GetUserByEmail(credentials.Email);
        if (user == null || !_passwordHasherService.VerifyPassword(credentials.Password, user.Password))
            throw new UnauthorizedAccessException("Email ou mot de passe incorrect");

        return await _jwtService.GenerateToken(user);
    }

    public async Task<User> Register(RegisterRequestDTO credentials)
    {
        var existingUser = await _userRepository.GetUserByEmail(credentials.Email);
        if (existingUser != null)
            throw new InvalidOperationException("L'email est déjà utilisée");

        var hashedPassword = _passwordHasherService.HashPassword(credentials.Password);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = credentials.Email,
            Password = hashedPassword,
            Role = UserRole.User,
            Firstname = credentials.Firstname,
            Lastname = credentials.Lastname
        };

        return await _userRepository.AddAsync(user);
    }
}
