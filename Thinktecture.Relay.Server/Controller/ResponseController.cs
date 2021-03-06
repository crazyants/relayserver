﻿using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Autofac;
using Newtonsoft.Json.Linq;
using NLog.Interface;
using Thinktecture.Relay.OnPremiseConnector.OnPremiseTarget;
using Thinktecture.Relay.Server.Communication;

namespace Thinktecture.Relay.Server.Controller
{
    [Authorize(Roles = "OnPremise")]
    public class ResponseController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IBackendCommunication _backendCommunication;

        public ResponseController(ILifetimeScope scope, ILogger logger)
        {
            _logger = logger;
            _backendCommunication = scope.Resolve<IBackendCommunication>();
        }

        public async Task<OkResult> Forward(JToken message)
        {
            _logger.Trace("Forwarding {0}", message.ToString());

            var onPremiseTargetReponse = message.ToObject<OnPremiseTargetReponse>();

            await _backendCommunication.SendOnPremiseTargetResponse(onPremiseTargetReponse.OriginId, onPremiseTargetReponse);

            return Ok();
        }
    }
}
