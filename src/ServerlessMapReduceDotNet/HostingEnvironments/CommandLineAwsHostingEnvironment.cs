﻿using System;
using AzureFromTheTrenches.Commanding.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using ServerlessMapReduceDotNet.Configuration;
using ServerlessMapReduceDotNet.Handlers;
using ServerlessMapReduceDotNet.Handlers.ObjectStore;
using ServerlessMapReduceDotNet.Handlers.Terminate;
using ServerlessMapReduceDotNet.Queue.AmazonSqs;
using ServerlessMapReduceDotNet.ServerlessInfrastructure.Abstractions;

namespace ServerlessMapReduceDotNet.HostingEnvironments
{
    public class CommandLineAwsHostingEnvironment : HostingEnvironment
    {
        protected override IQueueClient QueueClientFactory(IServiceProvider serviceProvider) => serviceProvider.GetService<AmazonSqsQueueClient>();
        
        public override IConfig ConfigFactory() => new Config();

        protected override Type TerminatorHandlerTypeFactory() => typeof(TerminateCommandHandler);

        protected override Type FireAndForgetHandlerType() => typeof(AsyncHandler<,>);

        protected override void RegisterObjectStoreImpl(ICommandRegistry cr) => cr.RegisterAmazonS3ObjectStore();
    }
}