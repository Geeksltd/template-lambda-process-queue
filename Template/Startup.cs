using Amazon.SQS;
using Microsoft.Extensions.DependencyInjection;
using Olive;

namespace App
{
    public class Startup : Olive.Aws.Startup
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddAwsEventBus();
            services.AddSingleton(sp => new AmazonSQSConfig { ServiceURL = AwsServiceUrl });
            services.AddSingleton<IAmazonSQS>(sp => new AmazonSQSClient(sp.GetService<AmazonSQSConfig>()));

            #region Using Dynamo Db?
            // services.AddSingleton(sp => new AmazonDynamoDBConfig { ServiceURL = AwsServiceUrl });
            // services.AddSingleton<IAmazonDynamoDB>(sp => new AmazonDynamoDBClient(sp.GetService<AmazonDynamoDBConfig>()));
            #endregion

            #region Using S3?
            // services.AddSingleton(sp => new AmazonS3Config { ServiceURL = AwsServiceUrl, ForcePathStyle = Config.Get<bool>("AWS:ForcePathStyle", defaultValue: false) });
            // services.AddSingleton<IAmazonS3>(sp => new AmazonS3Client(sp.GetService<AmazonS3Config>()));
            #endregion
        }
    }
}