using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Models;
using AutoMapper;
using Domain.Dtos.User;
using Domain.Entities;
using Domain.Interfaces;
using Service.Services.User;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UsuarioEntity> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UsuarioEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserDto>(entity) ?? new UserDto();
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UsuarioEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UsuarioEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}
