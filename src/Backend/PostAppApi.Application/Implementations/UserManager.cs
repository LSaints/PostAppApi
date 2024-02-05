using AutoMapper;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Comunicacao.ModelViews.User;
using PostAppApi.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace PostAppApi.Application.Implementations
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new Exception("ID do usuario informado não foi encontrado ou é inválido");

            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new Exception("Email não informado");

            return await _userRepository.GetByEmail(email);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new Exception("ID do usuario informado não foi encontrado ou é inválido");

            Validator.ValidateObject(user, new ValidationContext(user), true);

            return user;
        }

        public async Task<User> GetByLogin(UserLoginRequestBody user)
        {
            var entityBody = _mapper.Map<User>(user);
            return await _userRepository.GetByLogin(entityBody);
        }

        public async Task<User> GetByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new Exception("Nome de usuario não foi informado");
            
            return await _userRepository.GetByUsername(username);
        }

        public async Task<User> InsertAsync(UserPostRequestBody entity)
        {
            if (entity.Username == null) 
                throw new Exception("Nome de Usuario não foi informado");
            
            Validator.ValidateObject(entity, new ValidationContext(entity), true);
            var entityBody = _mapper.Map<User>(entity);
            return await _userRepository.InsertAsync(entityBody);
        }

        public Task<User> InsertAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateAsync(UserPutRequestBody entity)
        {
            if (entity.Id <= 0)
                throw new Exception("ID do usuario informado não foi encontrado");

            Validator.ValidateObject(entity, new ValidationContext(entity), true);

            var entityBody = _mapper.Map<User>(entity);
            return await _userRepository.UpdateAsync(entityBody);
        }

        public Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
