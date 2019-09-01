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
        /// Filter by clan location identifier.
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        IClanSearchBuilder WithLocationId(int locationId);

        /// <summary>
        /// Filter by minimum number of clan members
        /// </summary>
        /// <param name="minMembers"></param>
        /// <returns></returns>
        IClanSearchBuilder WithMinMembers(int minMembers);

        /// <summary>
        /// Filter by maximum number of clan members
        /// </summary>
        /// <param name="maxMembers"></param>
        /// <returns></returns>
        IClanSearchBuilder WithMaxMembers(int maxMembers);

        /// <summary>
        /// Filter by minimum amount of clan points.
        /// </summary>
        /// <param name="minClanPoints"></param>
        /// <returns></returns>
        IClanSearchBuilder WithMinClanPoints(int minClanPoints);

        /// <summary>
        /// Filter by minimum clan level.
        /// </summary>
        /// <param name="minClanLevel"></param>
        /// <returns></returns>
        IClanSearchBuilder WithMinClanLevel(int minClanLevel);

        /// <summary>
        /// Limit the number of items returned in the response.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        IClanSearchBuilder WithLimt(int limit);

        Task<ICollection<Clan>> Search();
    }
}
