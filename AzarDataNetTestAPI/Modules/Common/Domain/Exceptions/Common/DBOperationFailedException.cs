﻿using System.Runtime.CompilerServices;
using AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Identity.Request;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Static;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    public class DBOperationFailedException : BaseException
    {
        public Exception MainException { get; set; }
        public string MethodName { get; set; }
        public DBOperationFailedException(string EntityName, string EnglishEntityName, string lang, Exception mainException, PanelIdentityDto<long> panelIdentityDto = null, [CallerMemberName] string methodName = "default") : base(Messages.GetOperationFailedMessage(EntityName, EnglishEntityName, lang), panelIdentityDto)
        {
            MainException = mainException;
            MethodName = methodName;
        }
    }
}
