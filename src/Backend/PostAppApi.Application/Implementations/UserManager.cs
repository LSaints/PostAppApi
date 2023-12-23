using AutoMapper;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Application.ModelViews.User;
using PostAppApi.Domain.Models;

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
    }
}
