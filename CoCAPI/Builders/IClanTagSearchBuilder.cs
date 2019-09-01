using CoCAPI.Responses;
using System.Threading.Tasks;

namespace CoCAPI.Builders
{
    public interface IClanTagSearchBuilder
    {
        IClanMembersSearchBuilder Members();

        Task<Clan> Search();
    }
}
