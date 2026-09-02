using System;
using Microsoft.Xrm.Sdk;

namespace CVCI.Plugins
{
    public class ConsultantApprovalValidationPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracingService =
                (ITracingService)serviceProvider.GetService(
                    typeof(ITracingService));

            IPluginExecutionContext context =
                (IPluginExecutionContext)serviceProvider.GetService(
                    typeof(IPluginExecutionContext));

            tracingService.Trace(
                "Consultant Approval Validation Plugin started."
            );

            if (context.Depth > 1)
            {
                tracingService.Trace(
                    "Depth greater than 1. Exiting."
                );

                return;
            }

            if (!context.InputParameters.Contains("Target"))
            {
                tracingService.Trace(
                    "Target not found."
                );

                return;
            }

            if (!(context.InputParameters["Target"] is Entity target))
            {
                tracingService.Trace(
                    "Target is not an Entity."
                );

                return;
            }

            if (target.LogicalName != "harpi_consultant")
            {
                tracingService.Trace(
                    "Not a Consultant record."
                );

                return;
            }

            if (!context.PreEntityImages.Contains("PreImage"))
            {
                tracingService.Trace(
                    "PreImage not found."
                );

                return;
            }

            Entity preImage =
                context.PreEntityImages["PreImage"];

            const int ApprovedStatus = 312820002;

            OptionSetValue profileStatus =
                target.Contains("harpi_profilestatus")
                    ? target.GetAttributeValue<OptionSetValue>(
                        "harpi_profilestatus")
                    : preImage.GetAttributeValue<OptionSetValue>(
                        "harpi_profilestatus");

            OptionSetValue title =
                target.Contains("harpi_title")
                    ? target.GetAttributeValue<OptionSetValue>(
                        "harpi_title")
                    : preImage.GetAttributeValue<OptionSetValue>(
                        "harpi_title");

            string professionalSummary =
                target.Contains("harpi_professionalsummary")
                    ? target.GetAttributeValue<string>(
                        "harpi_professionalsummary")
                    : preImage.GetAttributeValue<string>(
                        "harpi_professionalsummary");

            if (profileStatus == null)
            {
                tracingService.Trace(
                    "Profile Status is null."
                );

                return;
            }

            tracingService.Trace(
                "Effective Profile Status: " +
                profileStatus.Value
            );

            if (profileStatus.Value != ApprovedStatus)
            {
                tracingService.Trace(
                    "Consultant is not Approved."
                );

                return;
            }

            tracingService.Trace(
                "Consultant is Approved. Validating profile."
            );

            if (title == null)
            {
                tracingService.Trace(
                    "Validation failed. Title missing."
                );

                throw new InvalidPluginExecutionException(
                    "Approved Consultants must have a Title."
                );
            }

            if (string.IsNullOrWhiteSpace(
                professionalSummary))
            {
                tracingService.Trace(
                    "Validation failed. Professional Summary missing."
                );

                throw new InvalidPluginExecutionException(
                    "Approved Consultants must have a Professional Summary."
                );
            }

            tracingService.Trace(
                "Validation passed."
            );
        }
    }
}