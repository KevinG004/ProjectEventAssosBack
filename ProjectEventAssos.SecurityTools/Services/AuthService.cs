namespace ProjectEventAssos.SecurityTools.Services;

using Microsoft.AspNetCore.Http.HttpResults;
using ProjectEventAssos.Core.Dto.Requests.User;
using ProjectEventAssos.Core.Dto.Responses.User;
using ProjectEventAssos.Core.Interfaces.Repositories;
using ProjectEventAssos.Core.Interfaces.Services;
using ProjectEventAssos.Core.Interfaces.Tools;
using ProjectEventAssos.Domain.Models;

public class AuthService(
    IUserRepository _userRepository,
    IPasswordHashService _passwordHasherService,
    IJwtService _jwtService,
    IPasswordGenerateService _password,
    IEmailService _emailService
    ) : IAuthService
{
    public async Task<LoginResponseDTO> Login(LoginRequestDTO credentials)
    {
        if (string.IsNullOrWhiteSpace(credentials.Identifiant) || string.IsNullOrWhiteSpace(credentials.Password))
            throw new ArgumentException("Identifiant et mot de passe sont requis");

        if (credentials.Identifiant.Contains('@'))
        {
            var user = await _userRepository.GetUserByEmail(credentials.Identifiant);
            if (user == null || !_passwordHasherService.VerifyPassword(credentials.Password, user.Password))
                throw new UnauthorizedAccessException("Identifiant ou mot de passe incorrect");

            var response = await _jwtService.GenerateToken(user);
            response.PasswordChanged = user.PasswordChanged;
            return response;
        }
        else
        {
            var user = await _userRepository.GetUserByUserName(credentials.Identifiant);
            if (user == null || !_passwordHasherService.VerifyPassword(credentials.Password, user.Password))
                throw new UnauthorizedAccessException("Identifiant ou mot de passe incorrect");

            var response = await _jwtService.GenerateToken(user);
            response.PasswordChanged = user.PasswordChanged;
            return response;
        }
    }

    public async Task<User> Register(RegisterRequestDTO credentials)
    {
        var existingUser = await _userRepository.GetUserByEmail(credentials.Email);
        if (existingUser != null)
            throw new InvalidOperationException("L'email est déjà utilisée");

        var StockedPassword = _password.GeneratePassword();
        var hashedPassword = _passwordHasherService.PasswordHash(StockedPassword);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = credentials.Email,
            Password = hashedPassword,
            RoleId = credentials.RoleId,
        };

        await _emailService.SendWelcomeEmailAsync(credentials.Email, StockedPassword);
        return await _userRepository.AddAsync(user);
    }
}
