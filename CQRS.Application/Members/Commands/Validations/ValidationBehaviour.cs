using FluentValidation;
using MediatR;

namespace CQRS.Application.Members.Commands.Validations
{
    public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

        public async Task<TResponse> Handle(TRequest request, 
                                      RequestHandlerDelegate<TResponse> next, 
                                      CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));

                var failures = validationResults.SelectMany(x => x.Errors.Where(f => f != null)).ToList();

                if (failures.Count != 0)
                    throw new ValidationException(failures);
            }
            return await next(cancellationToken);
        }
    }
}
