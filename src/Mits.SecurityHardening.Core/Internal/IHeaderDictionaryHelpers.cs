namespace Mits.SecurityHardening.Core.Internal
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;
    using Microsoft.Net.Http.Headers;

    internal static class IHeaderDictionaryHelpers
    {
        /// <summary>Gets the <c>Location</c> HTTP header.</summary>
        internal static StringValues GetLocation(this IHeaderDictionary headers) => headers[HeaderNames.Location];

        /// <summary>Sets the <c>Location</c> HTTP header.</summary>
        internal static void SetLocation(this IHeaderDictionary headers, StringValues values) => headers[HeaderNames.Location] = values;
    }
}