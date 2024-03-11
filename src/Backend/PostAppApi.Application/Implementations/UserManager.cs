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

        public async Task<IEnumerable<UserGetRequestBody>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserGetRequestBody>>(await _userRepository.GetAllAsync());
        }

        public async Task<UserGetRequestBody> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            if (string.IsNullOrEmpty(email) || user == null)
                throw new EmailNotFoundException();

            return _mapper.Map<User, UserGetRequestBody>(await _userRepository.GetByEmail(email)); ;
        }

        public async Task<UserGetRequestBody> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null || user.Id <= 0) throw new UserNotFoundException();
            Validator.ValidateObject(user, new ValidationContext(user), true);

            return _mapper.Map<User, UserGetRequestBody>(await _userRepository.GetByIdAsync(id));
        }

        public async Task<UserGetRequestBody> GetByLogin(UserLoginRequestBody user)
        {
            var entityBody = _mapper.Map<User>(user);
            return _mapper.Map<User, UserGetRequestBody>(await _userRepository.GetByLogin(entityBody));
        }

        public async Task<UserGetRequestBody> GetByUsername(string username)
        {
            var user = await _userRepository.GetByUsername(username);
            if (string.IsNullOrEmpty(username) || user == null)
                throw new UsernameNotFoundException();

            return _mapper.Map<User, UserGetRequestBody>(await _userRepository.GetByUsername(username));
        }

        public async Task<UserGetRequestBody> InsertAsync(UserPostRequestBody entity)
        {
            if (entity.Username == null) 
                throw new Exception("Nome de Usuario não foi informado");

            Validator.ValidateObject(entity, new ValidationContext(entity), true);

            var entityBody = _mapper.Map<User>(entity);
            return _mapper.Map<User, UserGetRequestBody>(await _userRepository.InsertAsync(entityBody));
        }
        public async Task<UserGetRequestBody> UpdateAsync(UserPutRequestBody entity)
        {
            if (entity.Id <= 0)
                throw new UserNotFoundException();

            Validator.ValidateObject(entity, new ValidationContext(entity), true);

            var entityBody = _mapper.Map<User>(entity);
            return _mapper.Map<User, UserGetRequestBody>(await _userRepository.UpdateAsync(entityBody));
        }
    }
}
