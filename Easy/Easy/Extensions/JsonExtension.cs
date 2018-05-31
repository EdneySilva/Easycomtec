using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easy.Extensions
{
    public static class JsonExtension
    {
        public static string ToSafelyJson(this object item)
        {
            return JsonConvert.SerializeObject(item, new JsonSerializerSettings() { MaxDepth = 1, ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
    }
}
