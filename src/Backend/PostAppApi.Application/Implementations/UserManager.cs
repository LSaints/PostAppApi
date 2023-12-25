using AutoMapper;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Application.ModelViews.User;
using PostAppApi.Domain.Models;
using System.Text;

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
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> InsertAsync(UserPostRequestBody entity)
        {
            var entityBody = _mapper.Map<User>(entity);
            byte[] hash, salt;
            GenerateHash(entity.Password, out hash, out salt);
            entityBody.PasswordHash = hash;
            entityBody.PasswordSalt = salt;
            return await _userRepository.InsertAsync(entityBody);
        }

        public Task<User> InsertAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateAsync(UserPutRequestBody entity)
        {
            var entityBody = _mapper.Map<User>(entity);
            return await _userRepository.UpdateAsync(entityBody);
        }

        public Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public void GenerateHash(String password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hash = new System.Security.Cryptography.HMACSHA512())
            {
                passwordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                passwordSalt = hash.Key;
            }
        }
    }
}
