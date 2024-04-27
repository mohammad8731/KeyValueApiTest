using AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.ServiceResult.Response;
using AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common;
using AzarDataNetTestAPI.Modules.KeyValueService.Application.Contracts.statics;
using AzarDataNetTestAPI.Modules.KeyValueService.Domain.Entities;
using AzarDataNetTestAPI.Modules.KeyValueService.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Localization;

namespace AzarDataNetTestAPI.Modules.KeyValueService.Application.Services
{
    public class KeyValueService
    {
        private readonly IKeyValueRepository _keyValueRepository;
        private readonly string _serviceMessageLanguage;


        public KeyValueService(IKeyValueRepository keyValueRepository,IHttpContextAccessor httpContextAccessor)
        {
            _keyValueRepository = keyValueRepository;
            _serviceMessageLanguage =httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
        }

        public async Task<ResultDto<KeyValueEntity>> GetByKeyAsync(string key)
        {
           var entity = await _keyValueRepository.GetByKeyAsync(key);
           if (entity == null)
           {
               throw new NotFoundException(KeyValueMessagePlaceHolders.KeyValueEntityPersian,
                   KeyValueMessagePlaceHolders.KeyValueEntityEng, _serviceMessageLanguage);
           }
           return ResultDto<KeyValueEntity>.Success(entity);
        }

        public async Task<ResultDto> Add(KeyValueEntity newEntity)
        {
            var existedEntity = await _keyValueRepository.GetByKeyAsync(newEntity.Key);
            if (existedEntity == null)
            {
                await _keyValueRepository.AddAsync(newEntity);
            }
            else
            {
                // if any value exits for the key ,so we update it since we have no repeated key
                await UpdateKeyValue(existedEntity, newEntity);
            }
            return ResultDto.Success(_serviceMessageLanguage);
        }

        public async Task<ResultDto> Update(KeyValueEntity entity)
        {
            var existedEntity = await _keyValueRepository.GetByKeyAsync(entity.Key);
            if (existedEntity == null)
            {
                throw new NotFoundException(KeyValueMessagePlaceHolders.KeyValueEntityPersian,
                    KeyValueMessagePlaceHolders.KeyValueEntityEng, _serviceMessageLanguage);
            }
            await UpdateKeyValue(existedEntity, entity);
            return ResultDto.Success(_serviceMessageLanguage);
        }

        private async Task UpdateKeyValue(KeyValueEntity existedEntity,KeyValueEntity updateEntity)
        {
            existedEntity.Value = updateEntity.Value;
            await _keyValueRepository.UpdateAsync(existedEntity);
        }

        public async Task<ResultDto> Remove(string key)
        {
            var existedEntity = await _keyValueRepository.GetByKeyAsync(key);
            if (existedEntity == null)
            {
                throw new NotFoundException(KeyValueMessagePlaceHolders.KeyValueEntityPersian,
                    KeyValueMessagePlaceHolders.KeyValueEntityEng, _serviceMessageLanguage);
            }
            await _keyValueRepository.DeleteAsync(existedEntity);
            return ResultDto.Success(_serviceMessageLanguage);
        }
    }
}
