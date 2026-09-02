# Architecture Decisions

This document captures key architectural decisions made during the development of the CV & Case Intelligence Platform.

---

## Decision 001: Use Dataverse as the Primary Data Store

### Decision

Dataverse was selected as the system of record for the solution.

### Reason

Dataverse provides:

- Relational data modeling
- Security and role management
- Integration with Power Apps
- Integration with Power Automate
- Support for business logic

### Alternatives Considered

- SharePoint Lists
- SQL Server
- Excel

### Outcome

Approved

---

## Decision 002: Create a Separate Skill Table

### Decision

Skills are stored in a dedicated Skill table.

### Reason

Skills can be reused across multiple consultants and project cases.

Examples:

- Blue Prism
- Power Automate
- Dataverse
- Azure
- REST API

This prevents duplication and supports future reporting.

### Outcome

Approved

---

## Decision 003: Use ConsultantSkill as a Junction Table

### Decision

A separate ConsultantSkill table was created between Consultant and Skill.

### Reason

The relationship requires additional attributes:

- Skill Level
- Years of Experience

A direct many-to-many relationship would not support these attributes.

### Outcome

Approved

---

## Decision 004: Use ProjectCase and Skill Many-to-Many Relationship

### Decision

ProjectCase and Skill were connected using a native Dataverse many-to-many relationship.

### Reason

A project can use multiple skills.

A skill can be used in multiple projects.

No additional attributes are currently needed on the relationship.

### Outcome

Approved

---

## Decision 005: Use Choice Fields for Controlled Vocabulary

### Decision

Several fields were implemented as Choice columns.

### Reason

Ensures consistent data entry and simplifies filtering and reporting.

Examples:

- Industry
- Seniority
- Department
- Skill Category
- Certification Level

### Outcome

Approved

---

## Decision 006: Use Lookup Columns for Entity Relationships

### Decision

Lookup columns were used to connect related records.

### Reason

Provides normalized data structures and enables relational modeling within Dataverse.

Examples:

- Consultant → Certification
- Consultant → Project Case
- Consultant → Skill

### Outcome

Approved

---

## Future Decisions

The following areas may require architectural decisions later:

- Security model
- Power Automate strategy
- Copilot Studio integration
- Environment strategy
- ALM and deployment
- Source control for solutions

## Decision 007: Simplify User Experience in Junction Tables

### Decision

Associated views were customized to display business-relevant information instead of technical primary columns.

### Reason

Users are interested in:

- Skill and Level
- Project Case and Role
- Certification and Issue Date

rather than internal record names.

### Outcome

Approved

## Decision 008: Professional Summary Recommendation Strategy

### Decision

ProfessionalSummary is configured as "Recommended" by default.

A business rule removes the recommendation when:

- Title = Consultant
- Seniority = Junior

### Reason

Most consultant profiles benefit from having a professional summary, as it helps sales managers and staffing coordinators evaluate consultant experience and expertise.

However, junior consultants may have limited project and consulting experience and should not be encouraged to provide detailed profile summaries before sufficient experience has been gained.

### Outcome

Approved

# Architectural Decisions

## AD-005: Trigger Filtering in Power Automate

Decision:
The Consultant Profile Review flow uses trigger filtering instead of post-trigger conditions.

Reason:
Reduces unnecessary flow executions and prevents additional flow runs when records are updated by the flow itself.

Result:
Improved performance and reduced flow consumption.

---

## AD-006: Profile Review Status Automation

Decision:
ProfileStatus is automatically updated by Power Automate.

Business Rules:

Ready for Review
→ Approved

Ready for Review
→ Needs Update

Reason:
Ensures profile quality is validated consistently.

---

## AD-007: Teams-Based Error Notifications

Decision:
Microsoft Teams notifications are used instead of email notifications.

Reason:
Dataverse and Outlook connectors were blocked by tenant DLP policies.

Result:
Error information is delivered directly in Teams while remaining compliant with platform governance policies.

## AD-009: Environment Variables for Configuration

### Decision
Environment-specific configuration values must be stored in Environment Variables instead of hardcoded values.

### Reason 
The same solution should be deployable across Development, Test and Production environments without requiring solution changes. 

### Consequences 
- Configuration is separated from business logic. 
- Deployments become more predictable. 
- Environment-specific values can be maintained independently.

## AD-011: Client-Side Logic with JavaScript

### Decision

Dynamic user interface behavior in the Consultant Model-Driven App form will be implemented using JavaScript Web Resources and the Power Platform Client API.

### Reason

Business Rules are suitable for simple scenarios, but JavaScript provides greater flexibility for:

- Dynamic UI behavior
- Event-driven logic
- Client-side validation
- Form notifications
- Advanced form interactions

The solution requires responsive behavior based on field values and user actions.

### Consequences

- JavaScript is used for client-side user experience.
- Form logic is organized using namespaces.
- Logic is triggered through OnLoad, OnChange and OnSave events.
- Client API is used to interact with Dataverse form data and UI controls.
- Defensive programming practices should be used to handle missing fields and controls gracefully.

## AD-012: Dataverse Queries Should Be Optimized

### Decision

Dataverse Web API queries should use OData query options such as `$select`, `$filter` and `$orderby` to reduce payload size and improve performance.

### Reason

Retrieving only the required records and columns reduces network traffic, improves response times and minimizes client-side processing.

### Consequences

- All Web API queries should explicitly request only required columns.
- Filtering should be performed server-side whenever possible.
- Sorting should be delegated to Dataverse instead of local JavaScript processing.

## AD-013: Critical Approval Validation Must Be Enforced Server-Side

### Decision

Consultant approval validation must be implemented as a Dataverse Plug-in running server-side.

### Reason

The approval rule applies regardless of how Consultant data is modified.

Data may originate from:

- Model-Driven Apps
- Canvas Apps
- Power Automate
- Dataverse Web API
- Imports
- External integrations

Client-side JavaScript alone cannot guarantee enforcement across all entry points.

### Consequences

- Approved Consultants must always contain mandatory profile information.
- Validation is executed in the Dataverse Event Execution Pipeline.
- Invalid approval attempts are blocked before the operation is completed.
- The rule is enforced consistently across the entire solution landscape.

## AD-014: Consultant Profile Evaluation Must Be Exposed Through a Custom API

### Decision

Consultant profile evaluation is implemented as a Dataverse Custom API with a dedicated Plug-in implementation.

### Reason

Multiple consumers require access to the same profile evaluation logic.

Examples include:

- Power Automate
- Model-Driven Apps
- JavaScript
- Future AI Agents
- External integrations

Implementing the logic separately in each consumer would create duplication, increase maintenance effort and risk inconsistent evaluation results.

A reusable Custom API provides a single implementation and a clearly defined API contract.

### Consequences

- Profile evaluation logic is maintained in one place.
- Multiple consumers can use the same operation.
- Consistent evaluation results are returned regardless of the caller.
- The API can evolve without requiring changes across all consumers.
- Dataverse becomes the central business logic layer.

### API Contract

Operation:

```text
EvaluateConsultantProfile

### Outputs
IsProfileComplete
ProfileScore
EvaluationMessage

Evaluation Rules
Profile Complete

A profile is considered complete when all General profile fields are populated:

Name
Title
Seniority
Office
Department
Professional Summary
Profile Score

The score is calculated from both Consultant information and related profile data:

Name
Title
Seniority
Office
Department
Professional Summary
Skills
Certifications
Project Cases

Maximum score:
100

