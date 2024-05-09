﻿using Microsoft.Extensions.Logging;
using System.Runtime.Serialization;
using Volo.Abp;

namespace Pure.AbpPro.BasicModule.Dicts;

public class DataDictionaryDomainException : BusinessException
{
    public DataDictionaryDomainException(string code = null, string message = null, string details = null, Exception innerException = null,
            LogLevel logLevel = LogLevel.Warning) : base(code, message, details, innerException, logLevel)
    {

    }

    public DataDictionaryDomainException(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context)
    {
    }
}
