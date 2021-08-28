using System;
using Stylet;
using StyletIoC;
using Bun.ViewModels;
using System.Net.Sockets;

namespace Bun
{
    public class Bootstrapper : Bootstrapper<RootViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // IOC配置
        }

        protected override void Configure()
        {
            // 启动前设置
        }

        protected override void OnStart()
        {
        }
    }
}
