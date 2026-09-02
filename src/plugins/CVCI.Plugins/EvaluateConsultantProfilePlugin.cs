using System;
using Microsoft.Xrm.Sdk;

namespace CVCI.Plugins
{
    public class EvaluateConsultantProfilePlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracingService =
                (ITracingService)serviceProvider.GetService(
                    typeof(ITracingService));

            IPluginExecutionContext context =
                (IPluginExecutionContext)serviceProvider.GetService(
                    typeof(IPluginExecutionContext));

            IOrganizationServiceFactory serviceFactory =
                (IOrganizationServiceFactory)serviceProvider.GetService(
                    typeof(IOrganizationServiceFactory));

            IOrganizationService service =
                serviceFactory.CreateOrganizationService(
                    context.UserId);

            tracingService.Trace(
                "EvaluateConsultantProfile API started."
            );

            tracingService.Trace(
                "Message Name: " + context.MessageName
            );

            tracingService.Trace(
                "Stage: " + context.Stage
            );

            tracingService.Trace(
                "Depth: " + context.Depth
            );

            tracingService.Trace(
                "Organization Service created."
            );

            tracingService.Trace(
                "Listing Input Parameters..."
            );

            foreach (string parameterName in context.InputParameters.Keys)
            {
                tracingService.Trace(
                    "Input Parameter: " + parameterName
                );

                if (context.InputParameters[parameterName] != null)
                {
                    tracingService.Trace(
                        "Input Parameter Type: " +
                        context.InputParameters[parameterName]
                            .GetType()
                            .FullName
                    );
                }
            }

            tracingService.Trace(
                "EvaluateConsultantProfile API finished."
            );
        }
    }
}