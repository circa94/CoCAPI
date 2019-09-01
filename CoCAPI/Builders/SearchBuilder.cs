using System.Net.Http;

namespace CoCAPI.Builders
{
    public abstract class SearchBuilder
    {
        protected readonly HttpClient httpClient;
        protected string searchString = "";

        protected SearchBuilder(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Adds a new parameter to the search.
        /// </summary>
        /// <param name="paramName">Name of the paramter.</param>
        /// <param name="paramValue">Value of the paramter.</param>
        /// <returns></returns>
        protected void AppendSearchParameter(string paramName, object paramValue)
        {
            searchString += $"{paramName}={paramValue}&";
        }
    }
}
