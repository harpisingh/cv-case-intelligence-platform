using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

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

            EntityReference consultantRef =
                (EntityReference)context.InputParameters["Target"];

            tracingService.Trace(
                "Consultant Id: " + consultantRef.Id
            );

            Entity consultant =
                service.Retrieve(
                    "harpi_consultant",
                    consultantRef.Id,
                    new ColumnSet(
                        "harpi_name",
                        "harpi_title",
                        "harpi_seniority",
                        "harpi_office",
                        "harpi_department",
                        "harpi_professionalsummary"
                    )
                );

            tracingService.Trace(
                "Consultant retrieved successfully."
            );

            string name =
                consultant.GetAttributeValue<string>(
                    "harpi_name");

            OptionSetValue title =
                consultant.GetAttributeValue<OptionSetValue>(
                    "harpi_title");

            OptionSetValue seniority =
                consultant.GetAttributeValue<OptionSetValue>(
                    "harpi_seniority");

            OptionSetValue office =
                consultant.GetAttributeValue<OptionSetValue>(
                    "harpi_office");

            OptionSetValueCollection department =
                consultant.GetAttributeValue<OptionSetValueCollection>(
                    "harpi_department");

            string professionalSummary =
                consultant.GetAttributeValue<string>(
                    "harpi_professionalsummary");

            bool isProfileComplete =
                !string.IsNullOrWhiteSpace(name)
                && title != null
                && seniority != null
                && office != null
                && department != null
                && department.Count > 0
                && !string.IsNullOrWhiteSpace(
                    professionalSummary);

            int profileScore = 0;

            if (!string.IsNullOrWhiteSpace(name))
                profileScore += 10;

            if (title != null)
                profileScore += 10;

            if (seniority != null)
                profileScore += 10;

            if (office != null)
                profileScore += 10;

            if (department != null &&
                department.Count > 0)
            {
                profileScore += 10;
            }

            if (!string.IsNullOrWhiteSpace(
                professionalSummary))
                profileScore += 20;

            int skillCount = GetRelatedRecordCount(
                service,
                "harpi_consultantskill",
                "harpi_consultant",
                consultantRef.Id);

            int certificationCount = GetRelatedRecordCount(
                service,
                "harpi_consultantcertification",
                "harpi_consultant",
                consultantRef.Id);

            int projectCaseCount = GetRelatedRecordCount(
                service,
                "harpi_consultantprojectcase",
                "harpi_consultant",
                consultantRef.Id);

            if (skillCount > 0)
                profileScore += 10;

            if (certificationCount > 0)
                profileScore += 10;

            if (projectCaseCount > 0)
                profileScore += 10;

            string evaluationMessage;

            if (!isProfileComplete)
            {
                evaluationMessage =
                    "Profile is incomplete. Required information is missing.";
            }
            else if (profileScore == 100)
            {
                evaluationMessage =
                    "Profile is staffing ready.";
            }
            else
            {
                evaluationMessage =
                    $"Profile is complete but can be improved. Current score: {profileScore}.";
            }

            tracingService.Trace(
                $"Profile Complete: {isProfileComplete}"
            );

            tracingService.Trace(
                $"Profile Score: {profileScore}"
            );

            tracingService.Trace(
                $"Message: {evaluationMessage}"
            );

            context.OutputParameters[
                "harpi_IsProfileComplete"] =
                isProfileComplete;

            context.OutputParameters[
                "harpi_ProfileScore"] =
                profileScore;

            context.OutputParameters[
                "harpi_EvaluationMessage"] =
                evaluationMessage;

            tracingService.Trace(
                "Response created successfully."
            );
        }

        private static int GetRelatedRecordCount(
            IOrganizationService service,
            string tableName,
            string consultantLookup,
            Guid consultantId)
        {
            QueryExpression query =
                new QueryExpression(tableName)
                {
                    ColumnSet = new ColumnSet(false)
                };

            query.Criteria.AddCondition(
                consultantLookup,
                ConditionOperator.Equal,
                consultantId);

            return service.RetrieveMultiple(
                query).Entities.Count;
        }
    }
}