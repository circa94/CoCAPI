using CoCAPI.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoCAPI.Builders
{
    public interface IClanMembersSearchBuilder
    {
        IClanMembersSearchBuilder WithLimit(int limit);

        Task<ICollection<ClanMember>> Search();
    }
}
