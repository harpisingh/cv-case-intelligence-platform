# CV & Case Intelligence Platform

Portfolio project developed while studying for the Microsoft PL-400 certification.

## Purpose

The purpose of this solution is to manage consultants, skills, certifications, and project references using Microsoft Power Platform.

The project is designed to simulate a real-world consulting solution and follows the same approach that would typically be used in an enterprise implementation.

## Technologies

- Microsoft Dataverse
- Power Apps
- Power Automate
- Copilot Studio
- GitHub

## Solution Architecture

Dataverse serves as the system of record and stores all business data.

The solution is built using the following architecture:

Dataverse  
↑  
Power Apps  
↑  
Power Automate  
↑  
Copilot Studio

## Data Model

Current entities include:

- Consultant
- Skill
- ConsultantSkill
- ProjectCase
- ConsultantProjectCase
- Certification
- ConsultantCertification

Key relationships:

- Consultant ↔ Skill
- Consultant ↔ ProjectCase
- Consultant ↔ Certification
- ProjectCase ↔ Skill

## Project Goals

- Learn Dataverse data modeling
- Learn Power Apps development
- Learn Power Automate integration
- Learn Copilot Studio
- Learn Application Lifecycle Management (ALM)
- Learn GitHub documentation practices
- Prepare for Microsoft PL-400

## Current Status

### Completed

- Solution created
- Dataverse tables created
- Relationships configured
- Initial GitHub repository created
- Documentation started

### Planned

- Model-Driven App
- Canvas App
- Power Automate flows
- Copilot Studio integration
- ALM and deployment strategy
- Solution export and source control

## Repository Structure

```text
docs/
├── architecture.md
└── datamodel.md

README.md
```

## Author

Created as a personal learning project while preparing for the Microsoft Power Platform Developer (PL-400) certification.


### Day 2
 
Completed:
 
- Created model-driven application
- Added consultant records
- Added skills
- Added certifications
- Added project references
- Configured lookup relationships
- Configured many-to-many relationships
- Customized associated views

## Day 3 Progress

### Completed

- Customized Consultant Main Form
- Organized consultant information into logical sections
- Customized Active Consultants view
- Customized ConsultantSkill associated views
- Implemented and tested Business Rules
- Improved consultant search experience through relationship views
- Evaluated user journey for finding consultants based on skills and project experience
- Identified opportunities for Canvas Apps to improve search and navigation
