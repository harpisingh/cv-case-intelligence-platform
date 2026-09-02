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

## Latest Progress (Day 9)

Implemented server-side validation using a Dataverse Plug-in.

### Key Achievements

- Learned Dataverse Plug-in architecture
- Implemented C# Plug-in development
- Used IPlugin and Execute()
- Worked with IPluginExecutionContext
- Used Target entities and PreEntityImages
- Implemented ITracingService logging
- Applied Filtering Attributes
- Worked with Event Execution Pipeline stages
- Registered and deployed a Plug-in Assembly
- Registered Plug-in Steps and Images
- Implemented server-side approval validation

### Consultant Approval Validation

Business Rule:

Approved Consultants must always contain:

- Title
- Professional Summary

The validation is enforced server-side using a Dataverse Plug-in and applies regardless of whether updates originate from:

- Model-Driven Apps
- Canvas Apps
- Power Automate
- Dataverse APIs
- External integrations

### Outcome

The solution now contains both client-side and server-side validation layers:

## Latest Progress (Day 9) 
Extended the solution using Dataverse Plug-ins and server-side business logic. 

### Key Achievements 
- Learned Dataverse Plug-in architecture 
- Built and deployed a C# Plug-in 
- Implemented IPlugin and Execute() 
- Worked with IPluginExecutionContext 
- Used Target entities and PreEntityImages 
- Implemented ITracingService logging 
- Applied Filtering Attributes 
- Registered Plug-in Assembly, Step and Image 
- Implemented server-side validation logic 
- Debugged runtime issues using Plugin Trace Logs 
- Resolved OptionSetValue vs String datatype issues 
- Applied Strong Name Signing for Dataverse deployment 
### Consultant Approval Validation 
Business Rule: Approved Consultants must always contain: 
- Title 
- Professional Summary 

The validation is enforced server-side and therefore applies regardless of whether updates originate from: 
- Model-Driven Apps 
- Canvas Apps 
- Power Automate 
- Dataverse Web API 
- Imports 
- External integrations 

### Important Design Lesson 
The first implementation only validated updates when Profile Status changed. 

A design review identified an important business rule gap: 

Approved 
↓ 
Title removed later 
↓ 
Profile becomes invalid

The solution was redesigned to use:
Target
+
PreImage
↓
Effective Record State
↓
Validation

This ensures that Approved Consultants remain valid regardless of which relevant field is modified.

### Outcome
The solution now contains multiple validation layers:
JavaScript
        ↓
Immediate client-side feedback

Dataverse Plug-in
        ↓
Server-side business rule enforcement

The Consultant approval process is now enforced directly within Dataverse, ensuring consistent data quality across the entire platform.

## Latest Progress (Day 10)

Extended the platform using a Dataverse Custom API and reusable server-side business logic.

### Key Achievements

- Learned Dataverse Custom API architecture
- Understood Custom API vs Plug-ins
- Implemented a bound Custom API
- Designed a reusable API contract
- Worked with Request and Response concepts
- Implemented InputParameters and OutputParameters
- Used IOrganizationService to retrieve Dataverse data
- Consumed the Custom API from Power Automate
- Applied server-side profile evaluation logic
- Returned calculated results through API response properties
- Debugged and resolved Dataverse data type issues

### Evaluate Consultant Profile

Custom API:

```text
harpi_EvaluateConsultantProfile

Purpose:
Evaluate whether a consultant profile is complete and calculate an overall profile quality score.

### Outputs
IsProfileComplete
ProfileScore
EvaluationMessage

Profile Complete Evaluation

The profile is considered complete when the following General information is populated:

Name
Title
Seniority
Office
Department
Professional Summary
Profile Score Evaluation

The score is calculated from profile information and related records.

Categories:

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

### Architecture
Power Automate
        ↓
EvaluateConsultantProfile
        ↓
Dataverse Custom API
        ↓
EvaluateConsultantProfilePlugin
        ↓
Consultant Evaluation Logic
        ↓
Response Properties

Outcome

The solution now exposes reusable consultant profile evaluation logic through a Dataverse Custom API.

The API can be consumed by:

Power Automate
JavaScript
Model-Driven Apps
Future AI Agents
External integrations

This prevents duplication of business logic across consumers and ensures consistent evaluation results throughout the platform.