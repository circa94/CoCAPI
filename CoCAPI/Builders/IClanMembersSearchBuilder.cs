using CoCAPI.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoCAPI.Builders
{
    public interface IClanMembersSearchBuilder
    {
        Task<ICollection<ClanMember>> Search();
    }
}
