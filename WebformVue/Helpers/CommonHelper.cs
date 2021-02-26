using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebformVue.Helpers
{
    public static class CommonHelper
    {
        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
        {
            if (dict.TryGetValue(key, out TValue result))
            {
                return result;
            }

            return default(TValue);
        }

        public static string ToJson<T>(this T source)
        {
            return JsonConvert.SerializeObject(source);
        }
    }
}
