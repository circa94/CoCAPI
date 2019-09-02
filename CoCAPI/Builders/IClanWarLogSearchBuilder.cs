using CoCAPI.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoCAPI.Builders
{
    public interface IClanWarLogSearchBuilder
    {
        IClanWarLogSearchBuilder WithLimit(int limit);

        Task<ICollection<War>> Search();
    }
}
