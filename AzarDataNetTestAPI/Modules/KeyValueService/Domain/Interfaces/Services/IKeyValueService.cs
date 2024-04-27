using AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.ServiceResult.Response;
using AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common;
using AzarDataNetTestAPI.Modules.KeyValueService.Application.Contracts.Dto;
using AzarDataNetTestAPI.Modules.KeyValueService.Application.Contracts.statics;
using AzarDataNetTestAPI.Modules.KeyValueService.Domain.Entities;
using AzarDataNetTestAPI.Modules.KeyValueService.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Localization;

namespace AzarDataNetTestAPI.Modules.KeyValueService.Domain.Interfaces.Services
{
    // we apply interface in service implementation for open closed principle and dependency inversion principle
    public interface IKeyValueService
    {
        Task<ResultDto<KeyValueEntity>> GetByKey(string key);

        Task<ResultDto> Add(AddOrUpdateKeyValuePairDto request);

        Task<ResultDto> Update(AddOrUpdateKeyValuePairDto request);

        Task<ResultDto> Remove(string key);
    }
}
