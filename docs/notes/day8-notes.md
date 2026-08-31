# Day 8 – Dataverse Web API, REST, JSON and OData

## Objectives

- Understand API concepts
- Learn REST fundamentals
- Understand HTTP methods and status codes
- Learn JSON structures
- Work with Dataverse Web API
- Use Xrm.WebApi
- Build OData queries
- Implement filtering and sorting
- Practice API debugging

---

## API Fundamentals

Reviewed the purpose of APIs as communication mechanisms between applications and services.

Learning:

```text
Application
        ↓
        API
        ↓
     Dataverse
```

---

## REST and CRUD

Reviewed REST concepts and CRUD operations.

### CRUD

```text
Create  → POST
Read    → GET
Update  → PATCH
Delete  → DELETE
```

Learning:

Power Platform abstracts many HTTP operations through Xrm.WebApi methods.

---

## HTTP Status Codes

Reviewed common API response codes.

```text
200 → OK
201 → Created
204 → No Content
400 → Bad Request
401 → Unauthorized
403 → Forbidden
404 → Not Found
429 → Too Many Requests
500 → Server Error
```

Learning:

400-series errors are typically caused by request, authentication or permission issues.

---

## JSON

Worked with JSON responses returned from Dataverse Web API.

Learning:

Identify:

- Objects
- Properties
- Values
- Arrays

Example:

```json
{
  "harpi_name": "Harpartap Randhawa"
}
```

---

## Dataverse Metadata

Identified metadata for the Consultant table.

```text
Display Name:
Consultant

Logical Name:
harpi_consultant

Entity Set Name:
harpi_consultants

Primary Name:
harpi_Name

Primary ID:
harpi_ConsultantId
```

Learning:

Display names are not the same as logical names.

---

## Xrm.WebApi

Implemented:

```javascript
Xrm.WebApi.retrieveMultipleRecords(...)
```

Purpose:

Retrieve Consultant data directly from Dataverse.

Learning:

Client-side JavaScript can retrieve data beyond what is currently loaded on the form.

---

## OData Query Options

### $select

Implemented:

```javascript
?$select=harpi_name
```

Learning:

Only request the columns that are needed.

---

### Multiple Columns

Implemented:

```javascript
?$select=harpi_name,harpi_professionalsummary
```

Learning:

Responses can be optimized while still returning required data.

---

### $filter

Implemented:

```javascript
&$filter=harpi_title eq 312820001
```

Purpose:

Return only Senior Consultants.

Learning:

Server-side filtering is more efficient than filtering client-side.

---

### $orderby

Implemented:

```javascript
&$orderby=harpi_name asc
```

Learning:

Sorting should be delegated to Dataverse.

---

## Senior Consultant Query

Built a practical business query.

Purpose:

Identify relevant Senior Consultants.

Example result:

```text
Harpartap Randhawa
Jeremy Sáenz
```

Learning:

Dataverse Web API can support real business scenarios such as staffing and resource matching.

---

## Error Handling

Created a deliberate query error.

Example:

```javascript
harpi_name_invalid
```

Result:

```text
400 Bad Request
```

Error:

```text
Could not find a property named
'harpi_name_invalid'
```

Learning:

API errors should be analyzed systematically to identify request, syntax or metadata issues.

---

## Debugging

Used browser DevTools.

Worked with:

```text
Console
Network
Error Messages
```

Learning:

Console logging and HTTP responses are key troubleshooting tools when working with client-side API calls.

---

## Authentication vs Authorization

Reviewed:

### Authentication

```text
Who are you?
```

### Authorization

```text
What are you allowed to do?
```

Examples:

```text
401 → Authentication issue
403 → Permission issue
```

---

## API Performance

Learning:

Avoid:

```text
Retrieve all records
Retrieve all columns
Filter locally
```

Prefer:

```text
$select
$filter
$orderby
```

Conceptually connected this to delegation principles from Canvas Apps.

---

## Alternate Keys

Reviewed the purpose of Alternate Keys.

Learning:

```text
GUID
=
Technical Identifier

Alternate Key
=
Business Identifier
```

Examples:

```text
Employee Number
Consultant Number
Email Address
```

---

## Upsert

Reviewed Upsert concept.

```text
Record Exists?
      ↓
Yes → Update

No  → Create
```

Learning:

Upsert simplifies integrations and is commonly used together with Alternate Keys.

---

## Key Learnings

- Dataverse Web API exposes Dataverse data through REST principles.
- Xrm.WebApi simplifies Web API usage inside Model-Driven Apps.
- OData query options improve efficiency and performance.
- API filtering should happen server-side.
- Metadata awareness is essential when working with Dataverse APIs.
- Debugging skills are critical when building integrations.
- Alternate Keys and Upsert are important integration concepts.

---

## Outcome

The solution now includes client-side Dataverse queries using:

```text
JavaScript
        ↓
Xrm.WebApi
        ↓
Dataverse Web API
```

Successfully retrieved, filtered and sorted Consultant data while applying REST, OData and API performance best practices.