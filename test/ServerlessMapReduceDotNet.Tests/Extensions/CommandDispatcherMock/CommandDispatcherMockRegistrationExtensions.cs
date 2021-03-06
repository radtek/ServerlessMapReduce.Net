﻿using System;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using AzureFromTheTrenches.Commanding.Abstractions.Model;
using NSubstitute;
using NSubstitute.Core;

namespace ServerlessMapReduceDotNet.Tests.Extensions.CommandDispatcherMock
{
    public static class CommandDispatcherMockRegistrationExtensions {

        public static ICommandDispatcher Register<TCommandHandler>(this ICommandDispatcher commandDispatcherMock, TCommandHandler commandHandler) where TCommandHandler : ICommandHandler
        {
            var registerCommandHandlerExpression = new RegisterCommandHandlerStubActionBuilder().Build<TCommandHandler>();
            registerCommandHandlerExpression(commandDispatcherMock, commandHandler);
            
            return commandDispatcherMock;
        }
        
        public static ConfiguredCall ReturnsCommandResult<T>(this Task<CommandResult<T>> value, T returnThis)
        {
            return value.Returns(new CommandResult<T>(returnThis, false));
        }
        
        public static ConfiguredCall ReturnsCommandResult<T>(this Task<CommandResult<T>> value, Func<T> returnThis)
        {
            return value.Returns(ci => new CommandResult<T>(returnThis(), false));
        }
    }
}