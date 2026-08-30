# Solution Architecture

## Overview

CV & Case Intelligence Platform is a portfolio project built while preparing for the Microsoft PL-400 certification.

The purpose of the solution is to manage consultants, skills, certifications, and customer project references in a centralized platform.

## Architecture

Dataverse
↑
Power Apps
↑
Power Automate
↑
Copilot Studio

## Components

### Dataverse

Stores all business data and relationships.

Main tables:

- Consultant
- Skill
- ProjectCase
- Certification
- ConsultantSkill
- ConsultantProjectCase
- ConsultantCertification

### Power Apps

Provides the user interface for interacting with consultant profiles, project cases, skills, and certifications.

### Power Automate

Will be used for automation scenarios such as:

- Notifications
- Profile updates
- Certification expiry reminders

### Copilot Studio

Will be used to provide conversational search across consultants, skills, certifications, and project references.

## Design Decisions

### Why Dataverse?

Dataverse was selected as the primary data store because it supports:

- Relational data
- Security roles
- Business logic
- Integration with Power Platform

### Why ConsultantSkill?

A junction table was used because additional attributes are required:

- Level
- YearsExperience

### Why ProjectCase and Skill use a Many-to-Many relationship?

A project case can require multiple skills.

A skill can be used in multiple project cases.

No additional attributes are currently required on the relationship.

## Automation Layer

Power Automate is used to implement server-side business processes.

### Consultant Profile Review Flow

Trigger:
- Dataverse row modified
- Consultant table
- ProfileStatus changed

Validation:
- Name exists
- Title exists
- ProfessionalSummary exists

Outcomes:
- Approved
- Needs Update

Additional Functions:
- LastReviewed updated using utcNow()
- Error handling using TRY/CATCH scopes
- Teams notifications for failed executions

# Application Lifecycle Management (ALM)

## Development Workflow

The CV & Case Intelligence Platform follows a solution-first development approach.

```text
Pro Playground (DEV)
        ↓
 Power Platform Solution
        ↓
      PAC CLI
        ↓
 Source-Controlled Files
        ↓
        Git
        ↓
      GitHub

      # Client-Side Architecture

The Consultant table uses JavaScript Web Resources to extend the functionality of the Model-Driven App.

```text
Consultant Form
        ↓
    OnLoad
        ↓
 JavaScript Web Resource
        ↓
     Client API
        ↓
 Dynamic UI Logic
``

##Event Model
OnLoad
  ↓
Initial form state

OnChange
  ↓
Dynamic updates

OnSave
  ↓
Save event handling

## Current Client Logic
Profile Status is used to control the state of Professional Summary.
Ready for Review
        ↓
Disable Professional Summary

Professional Summary Empty
        ↓
Display Warning Notification
``