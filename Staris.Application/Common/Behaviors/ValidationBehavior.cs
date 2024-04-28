using FluentValidation;
using MediatR;
using AppValidationException = Staris.Application.Common.Exceptions.ValidationException;

namespace Staris.Application.Common.Behaviors
{
	public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : class, IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
			_validators = validators;
		}

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			if (!_validators.Any())
			{
				return await next();
			}

			var validador = new ValidationContext<TRequest>(request);

			var errors = _validators.Select(s => s.Validate(validador))
				.SelectMany(s => s.Errors)
				.Where(s => s != null)
				.GroupBy(
					gb => gb.PropertyName,
					gb => gb.ErrorMessage,

					(propertyName, errorMessage) => new
					{
						Key = propertyName,
						Values = errorMessage.Distinct().ToArray()
					}
				)
				.ToDictionary(d => d.Key, d=> d.Values);

			if (errors.Any())
			{
				throw new AppValidationException(errors);
			}

			return await next();
		}
	}
}
