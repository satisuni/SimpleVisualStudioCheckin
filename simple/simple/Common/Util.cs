using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple.Common
{
    public static class UtilMethods
    {
        public static string GetValueFromJson(string json, string key)
        {
            var p = json.IndexOf("\"" + key + "\"");
            if (p < 0) return "";
            var c = json.IndexOf(":", p);
            if (c < 0) return "";
            var q = json.IndexOf("\"", c);
            if (q < 0) return "";
            var b = q + 1;
            var e = b;
            for (; e < json.Length && json[e] != '\"'; e++)
            {
            }
            var r = json.Substring(b, e - b);
            return r;
        }
    }
}
