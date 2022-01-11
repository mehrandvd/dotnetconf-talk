using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLava.API
{
    public static class HttpClientExtensions
    {
        public static Task<T> GetOne<T>(this HttpClient client, string uri)
        {
            throw new NotImplementedException();
        }

        public static Task<List<T>> GetList<T>(this HttpClient client, string uri)
        {
            throw new NotImplementedException();
        }
    }
}
