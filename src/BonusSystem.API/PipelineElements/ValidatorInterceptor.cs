using BonusSystem.Application;
using BonusSystem.Core.Exceptions;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BonusSystem.API.PipelineElements
{
    internal class ValidatorInterceptor : IValidatorInterceptor
    {
        public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult result)
        {
            if (!result.IsValid)
            {
               var errors= result.Errors.GroupBy(x => x.PropertyName)
                    .ToDictionary(x => x.Key, x => x.Select(y => y.ErrorMessage));

                throw new BadRequestException("The submitted model does not meet the requirements.",errors);
            }
            return result;
        }

        public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
        {
            return commonContext;
        }
    }

    internal static class FluentValidationExtensions    
    {
        internal static IServiceCollection AddValidatorInterceptor(this IServiceCollection services)
        {
            services.AddScoped<IValidatorInterceptor, ValidatorInterceptor>();
            services.AddValidatorsFromAssemblyContaining<IValidatorReferance>(includeInternalTypes: true);
            services.AddFluentValidationAutoValidation(cfg => cfg.DisableDataAnnotationsValidation = true);
            return services;
        }
    }
}
