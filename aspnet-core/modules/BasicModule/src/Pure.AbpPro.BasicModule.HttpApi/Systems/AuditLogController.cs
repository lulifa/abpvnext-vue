namespace Pure.AbpPro.BasicModule.Systems
{
    [Route("AuditLogs")]
    public class AuditLogController : BasicModuleController,IAuditLogAppService
    {
        private readonly IAuditLogAppService _auditLogAppService;

        public AuditLogController(IAuditLogAppService auditLogAppService)
        {
            _auditLogAppService = auditLogAppService;
        }

        [HttpPost("page")]
        [SwaggerOperation(summary: "分页获取审计日志信息", Tags = new[] {"AuditLogs"})]
        public Task<PagedResultDto<PagingAuditLogOutput>> GetListAsync(PagingAuditLogInput input)
        {
            return _auditLogAppService.GetListAsync(input);
        }
    }
}