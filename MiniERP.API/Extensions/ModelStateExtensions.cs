using Microsoft.AspNetCore.Mvc.ModelBinding;
using MiniERP.API.DTOs;

namespace MiniERP.API.Extensions
{
    public static class ModelStateExtensions
    {
        public static ApiResponse<T> ToApiResponse<T>(this ModelStateDictionary modelState)
        {
            var errors = modelState
                .Where(x => x.Value?.Errors.Count > 0)
                .SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();

            return ApiResponse<T>.ErrorResult("Validation failed", errors);
        }

        public static List<string> GetErrorMessages(this ModelStateDictionary modelState)
        {
            return modelState
                .Where(x => x.Value?.Errors.Count > 0)
                .SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();
        }
    }
}
