using Asp.Versioning;
using AzarDataNetTestAPI.Modules.KeyValueService.Application.Contracts.Dto;
using AzarDataNetTestAPI.Modules.KeyValueService.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace AzarDataNetTestAPI.Modules.KeyValueService.API.Controllers
{
    [ApiController]

    // with bellow data anotation the default return type of each action is application/json
    [Produces("application/json")]

    //defines the API version of the controller
    [ApiVersion("1")]

    //define the path of the versioned controller
    [Route("{culture}/v{version:apiVersion}/[controller]/[action]")]
    public class KeyValueController : ControllerBase
    {
        private readonly IKeyValueService _keyValueService;

        public KeyValueController(IKeyValueService KeyValueService)
        {
            _keyValueService = KeyValueService;
        }

        [HttpPost]
        [SwaggerRequestExample(typeof(AddOrUpdateKeyValuePairDtoExample), typeof(AddOrUpdateKeyValuePairDto))]
        public async Task<IActionResult> Add([FromBody] AddOrUpdateKeyValuePairDto request)
        {
            var result = await _keyValueService.Add(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
