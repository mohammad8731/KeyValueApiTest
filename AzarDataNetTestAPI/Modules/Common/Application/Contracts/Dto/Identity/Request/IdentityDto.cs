namespace AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Identity.Request
{
    public class IdentityDto<T> : IdentityParentDto
    {
        // id of entity we want to get info: sometimes id of entity we want is equal with entityId of user requesting
        public T Id { get; set; }

    }
}
