using System.Threading.Tasks;

namespace Ar.Generator.Service.Services
{
    public interface INodeJsService
    {
        Task<int> AddNumbers(int x, int y);
    }
}
