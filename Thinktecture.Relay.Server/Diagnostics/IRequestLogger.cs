﻿using System;
using System.Net;
using Thinktecture.Relay.OnPremiseConnector.OnPremiseTarget;
using Thinktecture.Relay.Server.OnPremise;

namespace Thinktecture.Relay.Server.Diagnostics
{
	public interface IRequestLogger
	{
		void LogRequest(IOnPremiseConnectorRequest onPremiseConnectorRequest, IOnPremiseTargetReponse onPremiseTargetReponse, HttpStatusCode responseStatusCode, Guid linkId, string originId, string relayPath);
	}
}