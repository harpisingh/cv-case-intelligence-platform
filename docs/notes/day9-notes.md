# Day 9 – Dataverse Plug-ins, C#, Execution Pipeline and Server-Side Validation

## Objectives

- Understand Dataverse Plug-ins
- Learn server-side business logic
- Understand Event Execution Pipeline
- Implement a Plug-in using C#
- Register Plug-ins in Dataverse
- Validate Consultant approval requirements

---

## Why Plug-ins?

Client-side JavaScript only runs in Model-Driven Apps.

The Consultant approval rule must apply regardless of entry point.

```text
Model-Driven App
Canvas App
Power Automate
Dataverse API
Imports
Integrations
        ↓
     Dataverse
        ↓
       Plug-in
```

Learning:

Critical business rules should be enforced server-side.

---

## Client-Side vs Server-Side Validation

### JavaScript

Purpose:

- User experience
- Form behavior
- Immediate feedback

### Plug-ins

Purpose:

- Data integrity
- Critical validation
- Consistent enforcement

Learning:

JavaScript can warn users.

Plug-ins can prevent invalid operations.

---

## Event Execution Pipeline

Reviewed:

```text
Request
   ↓
PreValidation
   ↓
PreOperation
   ↓
Main Dataverse Operation
   ↓
PostOperation
   ↓
Response
```

Learning:

PreValidation is appropriate for blocking invalid approval attempts.

---

## Execution Context

Worked with:

```text
MessageName
Stage
Depth
InputParameters
Target
PreEntityImages
```

Learning:

Execution Context provides information about the Dataverse operation currently being processed.

---

## Target and PreImage

### Initial Design

```text
Profile Status changed
↓
Validate
```

### Design Issue Discovered

```text
Approved
↓
Title removed later
↓
Profile becomes invalid
```

### Final Design

```text
Target
+
PreImage
↓
Effective Record State
↓
Validation
```

Learning:

Validation should evaluate the resulting record state instead of only the triggering event.

This became the most important design lesson from Day 9.

---

## ITracingService

Implemented:

```csharp
tracingService.Trace(...)
```

Learning:

Tracing provides server-side diagnostics similar to console.log().

---

## Depth Protection

Implemented:

```csharp
if (context.Depth > 1)
{
    return;
}
```

Learning:

Depth helps prevent recursive execution.

---

## Filtering Attributes

Configured:

```text
harpi_profilestatus
harpi_title
harpi_professionalsummary
```

Learning:

The Plug-in only executes for relevant changes.

Updates to unrelated fields such as Office do not trigger the Step.

---

## Consultant Approval Validation

Business Rule:

```text
Approved Consultants must have:

- Title
- Professional Summary
```

Implemented using:

```csharp
InvalidPluginExecutionException
```

---

## Dataverse Registration

Completed:

### Assembly

```text
CVCI.Plugins.dll
```

### Plugin

```text
ConsultantApprovalValidationPlugin
```

### Step

```text
Message:
Update

Entity:
harpi_consultant

Stage:
PreValidation

Mode:
Synchronous
```

### Pre Image

```text
Name:
PreImage
```

Columns:

```text
harpi_profilestatus
harpi_title
harpi_professionalsummary
```

---

## Troubleshooting

### Assembly Signing

Issue:

```text
Assemblies containing Plugins must be strongly signed.
```

Resolution:

```text
Created SNK key
Enabled assembly signing
Rebuilt solution
```

---

### Runtime Error

Issue:

```text
Unable to cast object of type
'Microsoft.Xrm.Sdk.OptionSetValue'
to type 'System.String'
```

Root Cause:

```text
harpi_title
```

is a Choice column.

Resolution:

```text
OptionSetValue
```

used instead of:

```text
string
```

---

## Testing Results

### Approved + Missing Title

Result:

Blocked.

---

### Approved + Missing Professional Summary

Result:

Blocked.

---

### Approved + Valid Data

Result:

Save successful.

---

### Approved + Title Removed Later

Result:

Blocked.

Learning:

Target + PreImage successfully handled the identified edge case.

---

## Key Learnings

- Plug-ins enforce critical business rules server-side.
- Target contains changed values.
- PreImage contains existing values.
- Business validation should be based on resulting record state.
- Strong Name Signing is required for Dataverse Plug-ins.
- Tracing is essential for troubleshooting.
- InvalidPluginExecutionException blocks invalid operations.

---

## Outcome

Successfully designed, built, deployed and tested a Dataverse Plug-in enforcing Consultant approval requirements directly within Dataverse.

```text
Model-Driven App
Canvas App
Power Automate
API
Integrations
        ↓
     Dataverse
        ↓
ConsultantApprovalValidationPlugin
        ↓
Server-Side Validation
```