using AutoMapper;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Comunicacao.ModelViews.User;
using PostAppApi.Domain.Models;
using PostAppApi.Exceptions.UserExceptions;
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
            var user = await _userRepository.GetByEmail(email);
            if (string.IsNullOrEmpty(email) || user == null)
                throw new EmailNotFoundException();

            return user;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null || user.Id <= 0) throw new UserNotFoundException();
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
            var user = await _userRepository.GetByUsername(username);
            if (string.IsNullOrEmpty(username) || user == null)
                throw new UsernameNotFoundException();

            return user;
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
                throw new UserNotFoundException();

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
