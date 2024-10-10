using Bookify.Application.Abstractions.Messaging;
using Bookify.Application.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Bookify.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseCommand
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request,
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                return  await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var ValidationErrors = _validators
                .Select(validator => validator.Validate(context))
                .Where(ValidationResult => ValidationResult.Errors.Any())
                .SelectMany(ValidationResult => ValidationResult.Errors)
                .Select(ValidationFailure => new ValidationError(
                    ValidationFailure.PropertyName,
                    ValidationFailure.ErrorMessage)).ToList();

            if (ValidationErrors.Any())
            {
                throw new Exceptions.ValidationException(ValidationErrors);
            }

            return await next();
        }
    }
}
