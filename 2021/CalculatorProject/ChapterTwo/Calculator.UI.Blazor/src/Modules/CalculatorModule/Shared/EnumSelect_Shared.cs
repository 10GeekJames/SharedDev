
using System;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.WebAssembly.Services;
namespace Calculator.UI.Blazor.Modules.CalculatorModule.Shared
{
    public static class EnumSelect_Shared
    {
        public static TEnum ToEnum<TEnum>(this string value)
        {
            return (TEnum) Enum.Parse(typeof(TEnum), value, true);
        }
    }
}