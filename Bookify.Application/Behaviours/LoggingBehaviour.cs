﻿
using Bookify.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bookify.Application.Behaviours
{
    public sealed class LoggingBehaviour<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseCommand
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var name = request.GetType().Name;

            try
            {
                _logger.LogInformation($"Executing command {name}");

                var result = await next();

                _logger.LogInformation($"Command {name} Executed successfully");

                return result;  
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"command {name} fails");

                throw;
            }
        }
    }
}
