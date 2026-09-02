# Day 10 – Dataverse Custom APIs and Reusable Server-Side Logic

## Objectives

- Understand Dataverse Custom APIs
- Compare Plug-ins and Custom APIs
- Design reusable business operations
- Work with InputParameters and OutputParameters
- Build and deploy a Custom API solution
- Consume Custom APIs from Power Automate

---

## What Is a Custom API?

A Dataverse Custom API exposes reusable business logic as a platform operation.

Concept:

```text
Consumer
    ↓
Custom API
    ↓
Plug-in
    ↓
Business Logic
    ↓
Response
```

Unlike event-triggered Plug-ins, a Custom API is called explicitly by a consumer.

Examples:

- Power Automate
- JavaScript
- Model-Driven Apps
- Future AI Agents
- Integrations

---

## Event Plug-in vs Custom API

### Event Plug-in

```text
Dataverse Event
    ↓
Plug-in executes automatically
```

Example:

```text
Update Consultant
```

Used when logic should execute because something happened.

---

### Custom API

```text
Consumer requests operation
    ↓
Custom API executes
```

Example:

```text
Evaluate Consultant Profile
```

Used when consumers explicitly request a business operation.

---

## API Contract Design

Operation:

```text
EvaluateConsultantProfile
```

---

### Input

Entity-bound Consultant context.

The operation receives the Consultant through:

```csharp
context.InputParameters["Target"]
```

Input Type:

```text
EntityReference
```

---

### Outputs

```text
IsProfileComplete
ProfileScore
EvaluationMessage
```

Purpose:

- IsProfileComplete → Profile completeness validation
- ProfileScore → Profile quality score
- EvaluationMessage → Human-readable result

---

## Bound vs Unbound

Selected:

```text
Entity Bound
```

Bound Entity:

```text
harpi_consultant
```

Reason:

The operation always evaluates a specific Consultant.

Learning:

Entity-bound operations provide context automatically and simplify API consumption.

---

## Function vs Action

Selected:

```text
Action
```

Reason:

The operation should be available to Power Automate and future consumers.

Learning:

Function and Action express intent and influence platform capabilities.

---

## Response Properties

Created:

```text
harpi_IsProfileComplete
harpi_ProfileScore
harpi_EvaluationMessage
```

Learning:

Custom APIs return structured output through Response Properties and OutputParameters.

---

## Plugin Implementation

Created:

```text
EvaluateConsultantProfilePlugin
```

Purpose:

Evaluate profile completeness and profile quality.

Implementation areas:

- InputParameters
- IOrganizationService
- Dataverse Retrieval
- Business Logic
- OutputParameters
- Tracing

---

## InputParameters

Testing revealed:

```text
Target
```

Type:

```text
EntityReference
```

Trace Output:

```text
Input Parameter: Target
Input Parameter Type: Microsoft.Xrm.Sdk.EntityReference
```

Learning:

Entity-bound APIs provide the target record through InputParameters.

---

## Consultant Retrieval

Implemented using:

```csharp
IOrganizationService
```

and:

```csharp
service.Retrieve(...)
```

Retrieved fields:

```text
Name
Title
Seniority
Office
Department
Professional Summary
```

Learning:

Retrieve only necessary data required by the business operation.

---

## Profile Complete Rules

A profile is considered complete when all General information is populated.

Required:

```text
Name
Title
Seniority
Office
Department
Professional Summary
```

Output:

```text
IsProfileComplete = true/false
```

---

## Profile Score Rules

Categories:

```text
Name
Title
Seniority
Office
Department
Professional Summary
Skills
Certifications
Project Cases
```

Weights:

```text
Name                    10
Title                   10
Seniority               10
Office                  10
Department              10
Professional Summary    20
Skills                  10
Certifications          10
Project Cases           10
```

Maximum:

```text
100
```

Learning:

Profile completeness and profile quality represent different business concepts.

---

## OutputParameters

Implemented:

```csharp
context.OutputParameters
```

Outputs:

```text
harpi_IsProfileComplete
harpi_ProfileScore
harpi_EvaluationMessage
```

Learning:

Custom APIs expose results through OutputParameters.

---

## Power Automate Consumer

Created:

```text
Manual Trigger
    ↓
Perform Bound Action
    ↓
harpi_EvaluateConsultantProfile
```

Learning:

Power Automate can consume Dataverse Custom APIs directly.

---

## Troubleshooting

### Office and Department Data Types

Issue:

```text
Invalid cast exceptions
```

Root Cause:

Field types did not match implementation assumptions.

Actual types:

```text
Office      = OptionSetValue
Department  = OptionSetValueCollection
```

Resolution:

Updated implementation to use correct Dataverse SDK types.

---

## Testing Results

### Complete Consultant Profile

Result:

```text
Profile Complete: True
Profile Score: 100
Profile is staffing ready.
```

Pass.

---

### Missing Department

Result:

```text
Profile Complete: False
Profile Score: 90
Profile is incomplete.
```

Pass.

---

## Architecture

```text
Power Automate
        ↓
EvaluateConsultantProfile
        ↓
Dataverse Custom API
        ↓
EvaluateConsultantProfilePlugin
        ↓
Dataverse
        ↓
Consultant Evaluation Logic
        ↓
Response Properties
```

---

## Key Learnings

- Custom APIs expose reusable business operations.
- API contracts should be designed before implementation.
- Entity-bound APIs provide context automatically.
- InputParameters deliver request data.
- OutputParameters return API results.
- One implementation can serve multiple consumers.
- Power Automate integrates naturally with Custom APIs.
- Dataverse provides a central business logic layer.

---

## Outcome

Successfully designed, implemented, deployed and tested a Dataverse Custom API for consultant profile evaluation.

The solution now provides reusable business logic that can be consumed by:

- Power Automate
- JavaScript
- Model-Driven Apps
- Future AI Agents
- External integrations

without duplicating business rules across consumers.