using Pure.AbpPro.BasicModule.Users.Dtos;

namespace Pure.AbpPro.BasicModule.Users
{
    public interface IAccountAppService: IApplicationService
    {
        /// <summary>
        /// 用户名密码登录
        /// </summary>
        Task<LoginOutput> LoginAsync(LoginInput input);
    }
}
