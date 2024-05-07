namespace Pure.AbpPro.Shared.Hosting.Microservices;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(AbpExceptionFilter))]
public class AbpProExceptionFilter : AbpExceptionFilter
{
    private const string PermissionDeniedMessageKey = "Pure.AbpPro:PermissionDenied";
    private const string ParameterValidationFailedMessageKey = "Pure.AbpPro:ParameterValidationFailed";
    private const string EntityNotFoundMessageKey = "Pure.AbpPro:EntityNotFound";
    private const string UnimplementedMessageKey = "Pure.AbpPro:Unimplemented";
    private const string DbUpdateConcurrencyMessageKey = "Pure.AbpPro:DbUpdateConcurrency";

    protected override bool ShouldHandleException(ExceptionContext context)
    {
        return IsWrapResult(context) || base.ShouldHandleException(context);
    }

    protected override async Task HandleAndWrapException(ExceptionContext context)
    {
        LoggerException(context);
        if (WrapResultHandler(context)) return;
        await DefaultHandlerAsync(context);
    }

    private void LoggerException(ExceptionContext context)
    {
        var (exceptionHandlingOptions, exceptionToErrorInfoConverter) = GetExceptionHandlingDependencies(context);

        var remoteServiceErrorInfo = exceptionToErrorInfoConverter.Convert(context.Exception, options =>
        {
            options.SendExceptionsDetailsToClients = exceptionHandlingOptions.SendExceptionsDetailsToClients;
            options.SendStackTraceToClients = exceptionHandlingOptions.SendStackTraceToClients;
        });

        var logger = context.GetService<ILogger<AbpExceptionFilter>>(NullLogger<AbpExceptionFilter>.Instance)!;
        var logLevel = context.Exception.GetLogLevel();
        logger.LogException(context.Exception, logLevel);
    }

    private async Task DefaultHandlerAsync(ExceptionContext context)
    {
        var (exceptionHandlingOptions, exceptionToErrorInfoConverter) = GetExceptionHandlingDependencies(context);

        if (context.Exception is AbpAuthorizationException)
        {
            await context.HttpContext.RequestServices.GetRequiredService<IAbpAuthorizationExceptionHandler>()
                .HandleAsync(context.Exception.As<AbpAuthorizationException>(), context.HttpContext);
        }
        else
        {
            context.HttpContext.Response.StatusCode = (int)context
                .GetRequiredService<IHttpExceptionStatusCodeFinder>()
                .GetStatusCode(context.HttpContext, context.Exception);
            context.Result = new ObjectResult(new RemoteServiceErrorResponse(exceptionToErrorInfoConverter.Convert(context.Exception, options =>
            {
                options.SendExceptionsDetailsToClients = exceptionHandlingOptions.SendExceptionsDetailsToClients;
                options.SendStackTraceToClients = exceptionHandlingOptions.SendStackTraceToClients;
            })));
        }
    }

    private (AbpExceptionHandlingOptions, IExceptionToErrorInfoConverter) GetExceptionHandlingDependencies(ExceptionContext context)
    {
        var exceptionHandlingOptions = context.GetRequiredService<IOptions<AbpExceptionHandlingOptions>>().Value;
        var exceptionToErrorInfoConverter = context.GetRequiredService<IExceptionToErrorInfoConverter>();
        return (exceptionHandlingOptions, exceptionToErrorInfoConverter);
    }

    private bool WrapResultHandler(ExceptionContext context)
    {
        if (!IsWrapResult(context)) return false;

        context.HttpContext.Response.StatusCode = 200;
        var result = SimplifyMessage(context);
        context.Result = new ObjectResult(result);
        return true;
    }

    private bool IsWrapResult(ExceptionContext context)
    {
        if (context.ActionDescriptor.AsControllerActionDescriptor().ControllerTypeInfo.GetCustomAttributes(typeof(WrapResultAttribute), true).Any())
        {
            return true;
        }

        if (context.ActionDescriptor.GetMethodInfo().GetCustomAttributes(typeof(WrapResultAttribute), true).Any())
        {
            return true;
        }

        return false;
    }

    private WrapResult<object> SimplifyMessage(ExceptionContext context)
    {
        var result = new WrapResult<object>();
        var localizer = context.GetRequiredService<IStringLocalizer<AbpProLocalizationResource>>();
        switch (context.Exception)
        {
            case AbpAuthorizationException:
                result.SetFail(localizer[PermissionDeniedMessageKey], "401");
                break;
            case AbpValidationException validationException:
                var errorMessage = localizer[ParameterValidationFailedMessageKey] + ";" + validationException.ValidationErrors.JoinAsString(";");
                result.SetFail(errorMessage, "400");
                break;
            case EntityNotFoundException:
                result.SetFail(localizer[EntityNotFoundMessageKey], "506");
                break;
            case NotImplementedException:
                result.SetFail(localizer[UnimplementedMessageKey], "507");
                break;
            case DbUpdateConcurrencyException:
                result.SetFail(localizer[DbUpdateConcurrencyMessageKey], "508");
                break;
            default:
                if (context.Exception is IHasErrorCode codeException)
                {
                    var exceptionConverter = context.GetRequiredService<IAbpProExceptionConverter>();
                    var message = exceptionConverter.TryToLocalizeExceptionMessage(context.Exception);
                    if (codeException.Code.IsNullOrWhiteSpace())
                    {
                        result.SetFail(context.Exception.Message);
                    }
                    else
                    {
                        result.SetFail(message, codeException.Code);
                    }
                }
                else
                {
                    result.SetFail(context.Exception.Message);
                }
                break;
        }

        return result;
    }
}
