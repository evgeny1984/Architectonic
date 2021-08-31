using Architect.Dto.Dto;
using System.Threading.Tasks;

namespace Ar.Compiler.Service.Services
{
    public interface IRecognitionService
    {
        Task RecognizeProvidedAdl(FileDto solution);
    }
}
