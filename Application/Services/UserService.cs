using APIControleTarefasComAutenticação.Application.DTO_s;
using APIControleTarefasComAutenticação.Application.DTO_s.Response;
using APIControleTarefasComAutenticação.Application.Interfaces;
using APIControleTarefasComAutenticação.Domain.Entities;
using APIControleTarefasComAutenticação.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace APIControleTarefasComAutenticação.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }


        //Registrar um novo usuário
        public async Task RegisterAsync(RegisterUserDto dto)
        {

            var existe = await _userRepository.GetByEmailAsync(dto.Email);

            if (existe != null)
                throw new Exception("Email já cadastrado");
            if (string.IsNullOrEmpty(dto.Email))
                throw new Exception("Email é obrigatório");
            if (string.IsNullOrEmpty(dto.Password)) 
                throw new Exception("Senha é obrigatória");

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);
            await _userRepository.AddAsync(user);
        }


        //Autenticar um usuário existente
        public async Task<LoginResponseDto> LoginAsync(LoginUserDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);

            if (user == null)
                throw new Exception("Email ou senha invalido");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Email ou senha invalido");
            if(result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);
                await _userRepository.UpdateAsync(user); // aqui faz um update para atualizar a senha do usuário caso seja necessário
            }

            return new LoginResponseDto
            {
                Id = user.Id,
                Email = user.Email,
            };
        }
    }
}
