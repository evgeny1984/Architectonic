using Ar.Compiler.Service.Properties;
using Ar.Messages.EventBus.EventBus.Abstractions;
using Architect.Dto.Dto;
using Architect.Dto.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Ar.Compiler.Service.Services
{
    public class RecognitionService : IRecognitionService
    {
        private ITransformationService _transformationService;
        private readonly IEventBus _eventBus;
        private readonly ILogger<RecognitionService> _logger;

        public RecognitionService(ITransformationService transformationService, IEventBus eventBus, ILogger<RecognitionService> logger)
        {
            _transformationService = transformationService;
            _eventBus = eventBus;
            _logger = logger;
        }
        public async Task RecognizeProvidedAdl(FileDto adlFile)
        {
            // TODO Call the transformation service to build a solution semantic model based on ADL information
            var semanticModel = await _transformationService.TransformToSemanticModel(adlFile);

            var eventMessage = new SemanticModelCreatedIntegrationEvent(semanticModel);

            // Once solution is constructed, sends an integration event to generator.api to create a new project based on the solution configuration 
            try
            {
                _eventBus.Publish(eventMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"ERROR Publishing integration event: {eventMessage.Id} from {Resources.AppName}");

                throw;
            }

        }
    }
}
