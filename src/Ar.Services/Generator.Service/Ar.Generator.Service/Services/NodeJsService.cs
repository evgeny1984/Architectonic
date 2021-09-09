using Ar.Generator.Service.Helpers;
using Jering.Javascript.NodeJS;
using System.IO;
using System.Threading.Tasks;

namespace Ar.Generator.Service.Services
{
    public class NodeJsService : INodeJsService
    {
        private INodeJSService _nodeJSService;

        public NodeJsService(INodeJSService nodeServices)
        {
            _nodeJSService = nodeServices;
        }

        public async Task<int> AddNumbers(int x, int y)
        {
            string path = "App.js";
            var resultAdd = await _nodeJSService.InvokeFromFileAsync<int>(path, JsFunctions.AddNumbers, args: new object[] { x, y });
            var renderResult = await _nodeJSService.InvokeFromFileAsync<string>(path, JsFunctions.RenderTemplate, args: new object [] { x });

            return resultAdd;
        }
    }
}
