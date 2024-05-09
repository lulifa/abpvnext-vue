﻿namespace Lion.AbpPro.BasicModule.Systems;

[Route("IdentitySecurityLogs")]
public class IdentitySecurityLogController : BasicModuleController, IIdentitySecurityLogAppService
{
    private readonly IIdentitySecurityLogAppService _identitySecurityLogAppService;

    public IdentitySecurityLogController(IIdentitySecurityLogAppService identitySecurityLogAppService)
    {
        _identitySecurityLogAppService = identitySecurityLogAppService;
    }

    [HttpPost("page")]
    [SwaggerOperation(summary: "分页获取登录日志信息", Tags = new[] { "IdentitySecurityLogs" })]
    public Task<PagedResultDto<PagingIdentitySecurityLogOutput>> GetListAsync(PagingIdentitySecurityLogInput input)
    {
        return _identitySecurityLogAppService.GetListAsync(input);
    }
}