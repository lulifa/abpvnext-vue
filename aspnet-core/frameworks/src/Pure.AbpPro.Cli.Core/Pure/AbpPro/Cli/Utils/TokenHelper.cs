﻿namespace Pure.AbpPro.Cli.Core;

public static class TokenHelper
{
    /// <summary> 
    /// 解密数据 
    /// </summary> 
    /// <param name="data">要解密数据</param> 
    /// <param name="keyContainerName">密匙容器的名称</param> 
    public static string Decrypt(string data, string keyContainerName = "abpvnext-vue")
    {
        Check.NotNullOrWhiteSpace(data, nameof(data));
        return data.Replace(keyContainerName, "");
    }
}