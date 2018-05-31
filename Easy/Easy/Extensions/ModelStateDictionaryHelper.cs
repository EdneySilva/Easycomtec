using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easy.Extensions
{
    public static class ModelStateDictionaryHelper
    {
        public static IEnumerable<string> Errors(this ModelStateDictionary modelState)
        {
            return modelState.SelectMany(s => s.Value.Errors.Select(e => e.ErrorMessage)).ToArray();
        }

        public static JsonResult AsJsonResult(this ModelStateDictionary modelState)
        {
            return new JsonResult(new 
            {
                Success = modelState.IsValid,
                Erros = modelState.Errors()
            });
        }
    }
}
