using Application.UseCases.DeleteProduct;
using Application.UseCases.GetProduct;
using Application.UseCases.PutProduct;
using Application.UseCases.ValidateProduct;
using Application.UseCases.ValidateProduct.Input;
using Application.UseCases.ValidateProduct.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddUseCases();
            services.AddValidators();
            return services;
        }

        internal static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IPostProductUseCase, PostProductUseCase>();
            services.AddTransient<IGetProductUseCase, GetProductUseCase>();
            services.AddTransient<IPutProductUseCase, PutProductUseCase>();
            services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
        }

        internal static void AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<ValidateProductInput>, ValidateProductInputValidator>();
        }
    }
}
