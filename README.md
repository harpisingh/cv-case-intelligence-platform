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

- ## Day 4 Progress

### Completed

- Created first Canvas App: CV & Case Finder
- Connected Canvas App to Dataverse
- Displayed consultant records in a Gallery
- Implemented consultant search using Power Fx
- Implemented title-based filtering
- Added alphabetical sorting of consultant records
- Created Consultant Detail screen
- Implemented navigation between screens
- Explored delegation warnings and query scalability considerations
- Investigated differences between Choice and Choices columns in Dataverse

### Key Learnings

- Canvas Apps provide a customizable user experience on top of Dataverse
- Power Fx controls application behavior through formulas and control properties
- Delegation impacts scalability and query performance
- Choice and multi-select Choices columns behave differently in Canvas Apps

## Latest Progress (Day 5)

Implemented the first business process automation using Power Automate.

### Consultant Profile Review Workflow

A Dataverse-triggered cloud flow was created to automate consultant profile reviews.

Process:

Ready for Review
→ Validation
→ Approved / Needs Update

Implemented features:

- Dataverse trigger
- Trigger filtering
- Choice field handling
- Automatic status updates
- Automatic review timestamp updates
- Error handling using TRY/CATCH pattern
- Teams-based error notifications

This marks the first end-to-end business process automation in the solution.

## Day 6

Git, VS Code and Power Platform CLI setup completed.

Implemented Application Lifecycle Management (ALM) foundations for the CV & Case Intelligence Platform.

### Key Achievements

- Introduced Solution-based development
- Explored managed and unmanaged solutions
- Investigated solution dependencies
- Created Environment Variables
- Investigated Connection References
- Installed and configured Power Platform CLI (PAC)
- Connected the solution to source control
- Cloned the Dataverse solution into source-controlled files
- Configured Git and GitHub workflow
- Created the first GitHub Actions pipeline

### Outcome

The solution is now version-controlled and aligned with modern Power Platform development practices, enabling future CI/CD and deployment automation.

## Latest Progress (Day 7)

Implemented client-side scripting in the CV & Case Intelligence Platform using JavaScript and the Power Platform Client API.

### Key Achievements

- Created first JavaScript Web Resource
- Implemented namespace-based JavaScript structure
- Registered form event handlers
- Implemented OnLoad logic
- Implemented OnChange logic
- Implemented OnSave logic
- Used executionContext and formContext
- Read Dataverse field values through Client API
- Manipulated form controls dynamically
- Implemented client-side validation
- Displayed form notifications
- Practiced browser debugging using DevTools
- Implemented defensive JavaScript techniques
- Migrated development to a dedicated environment (dev-proto)
- Synced solution changes back into source control using PAC CLI

### Outcome

The Consultant form now contains client-side business logic that reacts dynamically to user actions and demonstrates core Power Platform Client API concepts.

## Latest Progress (Day 8)

Extended the solution using Dataverse Web API and Xrm.WebApi.

### Key Achievements

- Learned REST and CRUD fundamentals
- Implemented Dataverse Web API queries
- Used Xrm.WebApi.retrieveMultipleRecords()
- Worked with JSON responses
- Applied OData query options:
  - $select
  - $filter
  - $orderby
- Implemented Consultant search scenarios
- Practiced API debugging and error handling
- Explored authentication, authorization, alternate keys and Upsert concepts

### Outcome

The solution can now retrieve and process Dataverse data dynamically through client-side JavaScript, extending functionality beyond the data already loaded on the form.