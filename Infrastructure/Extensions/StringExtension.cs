using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class StringExtension
    {
        public static string TrimObjectToString(this object value)
        {
            return value.ToString().Trim();
        }
    }
}
