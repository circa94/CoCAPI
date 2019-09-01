using CoCAPI.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoCAPI.Builders
{
    public interface IPlayerSearchBuilder
    {
        /// <summary>
        /// Get information about a single player by player tag.
        /// </summary>
        /// <param name="playerTag"></param>
        /// <returns></returns>
        IPlayerSearchBuilder WithPlayerTag(string playerTag);

        /// <summary>
        /// Executes the clan search.
        /// </summary>
        /// <returns></returns>
        Task<Player> Search();
    }
}
