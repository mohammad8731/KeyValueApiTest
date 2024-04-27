using System.Runtime.CompilerServices;
using System.Text.Json;
using Swashbuckle.AspNetCore.Filters;

namespace AzarDataNetTestAPI.Modules.KeyValueService.Application.Contracts.Dto
{
    public class AddOrUpdateKeyValuePairDto : IMultipleExamplesProvider<AddOrUpdateKeyValuePairDtoExample>
    {
        public string Key { get; set; }
        // used for json value
        public string Value { get; set; }
        public IEnumerable<SwaggerExample<AddOrUpdateKeyValuePairDtoExample>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "example1", 
                new AddOrUpdateKeyValuePairDtoExample()
                {
                    Key = "key 1",
                    Value = JsonSerializer.Serialize(
                        new ValueTest
                        {
                            Age = 10,
                            Name = "ali"
                        })
                });
        }
    }

    public class AddOrUpdateKeyValuePairDtoExample
    {
        public string Key { get; set; }
        // used for json value
        public string Value { get; set; }
    }

    public class ValueTest
    {
        public string Name  { get; set; }
        public int Age  { get; set; }
    }
}
