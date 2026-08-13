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
