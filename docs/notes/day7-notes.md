# Day 7 – JavaScript, Client API and Form Events

## Objectives

- Learn JavaScript in Model-Driven Apps
- Understand Client API fundamentals
- Understand executionContext and formContext
- Learn OnLoad, OnChange and OnSave
- Implement UI logic with JavaScript
- Practice debugging with browser DevTools
- Understand client-side validation

---

## Environment Migration

Development was moved from the shared Pro Playground environment to a dedicated development environment.

Environment:

```text
dev-proto
```

Reason:

The shared environment did not allow creation of Web Resources due to missing security privileges.

Learning:

Development environments should provide sufficient permissions for customization and client-side development.

---
## JavaScript Web Resource

Created:

```text
harpi_consultant.js
```

Purpose:

Provide client-side business logic for the Consultant form.

Learning:

JavaScript in Model-Driven Apps is stored as a Web Resource and attached to forms through event handler registration.

---

## Namespace Pattern

Implemented:

```javascript
var CVCI = CVCI || {};
```

Learning:

Namespaces help organize logic, reduce global variables and improve maintainability.

---

## Client API Fundamentals

Used:

```javascript
executionContext
```

and

```javascript
formContext
```

Learning:

```text
executionContext
        ↓
formContext
        ↓
Attributes
Controls
Data
UI
```

formContext provides access to the current form and all associated data and controls.

---

## Attribute vs Control

### Attribute

Represents data.

Example:

```javascript
formContext.getAttribute(...)
```

### Control

Represents the user interface element.

Example:

```javascript
formContext.getControl(...)
```

Learning:

```text
Attribute = Data

Control = UI
```

---

## Form Events

Implemented three event types.

### OnLoad

Executed when the Consultant form opens.

Purpose:

Initialize form state.

### OnChange

Executed when Profile Status changes.

Purpose:

Update the user interface dynamically.

### OnSave

Executed when the record is saved.

Purpose:

Demonstrate save-event execution and event registration.

Learning:

```text
OnLoad
  ↓
Initialize UI

OnChange
  ↓
React to user changes

OnSave
  ↓
React to save operations
```

---

## Reading Dataverse Data

Retrieved Profile Status using Client API.

Example:

```javascript
formContext
    .getAttribute("harpi_profilestatus")
    .getValue();
```

Learning:

Choice columns return their internal numeric value rather than the display label.

Example:

```text
Ready for Review
=
312820001
```

---

## Dynamic UI Logic

Implemented:

```text
Profile Status = Ready for Review
        ↓
Disable Professional Summary
```

Implemented using:

```javascript
getControl(...)
setDisabled(...)
```

Learning:

Field values can dynamically drive user interface behavior.

---

## Client-Side Validation

Scenario:

```text
Profile Status = Ready for Review

Professional Summary = Empty
```

Result:

```text
Display warning notification
```

Implemented using:

```javascript
setFormNotification(...)
```

and

```javascript
clearFormNotification(...)
```

Learning:

Client-side validation provides immediate feedback to users before data is saved.

---

## Browser Debugging

Used browser DevTools (F12).

Practiced:

- console.log()
- Event testing
- Error troubleshooting
- Logical name verification
- Form event validation

Learning:

Console logging is a powerful mechanism for troubleshooting client-side scripts.

---

## Intentional Error Testing

Introduced a deliberate error:

```javascript
harpi_profilestatus_test
```

instead of:

```javascript
harpi_profilestatus
```

Result:

The field could not be found.

Learning:

Incorrect logical names are one of the most common causes of Client API errors.

---

## Defensive JavaScript

Implemented null checking.

Example:

```javascript
if (!statusAttribute
