using CoCAPI.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoCAPI.Builders
{
    public interface IClanSearchBuilder
    {
        /// <summary>
        /// Search clans by name. If name is used as part of search query, it needs to be at least three characters long. 
        /// Name search parameter is interpreted as wild card search, so it may appear anywhere in the clan name.
        /// </summary>
        /// <param name="clanName"></param>
        /// <returns></returns>
        IClanSearchBuilder WithName(string clanName);

        /// <summary>
        /// Filter by clan war frequency. See <see cref="WarFrequency"/> constants for available options.
        /// </summary>
        /// <param name="warFrequency"></param>
        /// <returns></returns>
        IClanSearchBuilder WithWarFrequency(string warFrequency);

        /// <summary>
        /// Executes the clan search.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Clan>> Search();
    }
}
