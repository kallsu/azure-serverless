using System;
using System.IO;
using Azure.Function.HelloWorld.BlobFunction.Core;
using Azure.Function.HelloWorld.BlobFunction.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Azure.Function.HelloWorld.BlobFunction
{
    public static class MyBlobFunction
    {
        [FunctionName("MyBlobFunction")]
        public static void Run([BlobTrigger("samples-workitems/{name}", Connection = "")] Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            // why thi try/catch ? Because the serverless execution is stateless, and need to be prepared 
            try
            {

                // call my service provider
                var serviceCollection = MyFunctionServiceProvider.Instance.ServiceCollection;

                // obtain my service with all dependencies injected
                var myService = (IMyService)serviceCollection.GetService(typeof(IMyService));

                // do something
                myService.DoSomethingHere();
            }
            catch (Exception e)
            {
                log.LogError(e.Message);
            }
        }
    }
}
