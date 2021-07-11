using Calculator.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;

namespace IndividualUserModule.Services
{
    public static class HttpClientShared
    {
        public static Uri BaseAddress
        {
            get { return new Uri("https://localhost:5016/api/"); }
        }
    }
}
