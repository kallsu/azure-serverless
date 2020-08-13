using System;
using Azure.Function.HelloWorld.BlobFunction.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Function.HelloWorld.BlobFunction.Core
{
    public sealed class MyFunctionServiceProvider
    {
        private static MyFunctionServiceProvider instance = null;

        public ServiceProvider ServiceCollection {get; internal set;}

        private MyFunctionServiceProvider()
        {
            Init();
        }

        public static MyFunctionServiceProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MyFunctionServiceProvider();
                }
                return instance;
            }
        }

        private void Init()
        {
            var services = new ServiceCollection();

            // the only service that I have
            services.AddTransient<IMyService, MyService>();

            ServiceCollection = services.BuildServiceProvider(false);
        }
    }
}
