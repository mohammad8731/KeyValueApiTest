using AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Identity.Request;
using Swashbuckle.AspNetCore.Filters;

namespace AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.SetStatus.Request
{
    public class SetStatusDto<T> : PanelIdentityDto<T>

    {
        public bool Status { get; set; }
    }

    public class SetStattusDtoExample
    {
        public int Id { get; set; }
        public byte RoleId { get; set; } = 2;
        public int RoleAccountId { get; set; } = 0;
        public bool Status { get; set; }
    }
    public class SetStattusDtoExampleProvider : IMultipleExamplesProvider<SetStattusDtoExample>
    {
        public IEnumerable<SwaggerExample<SetStattusDtoExample>> GetExamples()
        {
            yield return SwaggerExample.Create("Example", new SetStattusDtoExample
            {
            });
        }
    }
}