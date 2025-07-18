using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace MiniERP.Web.ModelBinders
{
    // Temporarily disabled due to .NET 9.0 API changes
    // Will be implemented with proper .NET 9.0 ModelBindingResult API
    /*
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // Implementation commented out due to .NET 9.0 API changes
            return Task.CompletedTask;
        }
    }
    */

    public class DecimalModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            // Temporarily disabled - using default decimal model binding
            return null;
            
            /*
            if (context.Metadata.ModelType == typeof(decimal) || context.Metadata.ModelType == typeof(decimal?))
            {
                return new DecimalModelBinder();
            }

            return null;
            */
        }
    }
}
