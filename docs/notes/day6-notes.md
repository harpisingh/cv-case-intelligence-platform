# Day 6 – ALM, Solutions, Git and Power Platform CLI

## Objectives

- Understand ALM fundamentals
- Learn Solution-based development
- Understand managed and unmanaged solutions
- Learn Environment Variables
- Learn Connection References
- Learn Power Platform CLI
- Move solution into source control
- Understand Git, GitHub and CI/CD

---

## Solution Audit

Verified that all major solution components are included in the solution:

### Tables

- Consultant
- Skill
- Certification
- ConsultantSkill
- ConsultantCertification
- ProjectCase
- ConsultantProjectCase

### Apps

- CV & Case Finder (Canvas App)
- CV & Case Intelligence (Model-Driven App)

### Automation

- Consultant Profile Review Flow

### Supporting Components

- ProfileStatusChoice
- Connection References
- Environment Variables

---

## Dependencies

Investigated dependencies for the Consultant Profile Review flow.

The flow depends on:

- Consultant table
- ProfileStatus column
- Dataverse Connection Reference
- Teams Connection Reference

Learning:

A component rarely exists in isolation. Dependencies determine what must be included during deployment.

---

## Managed vs Unmanaged

### Development

Unmanaged Solution

Reason:

Allows active modification of all solution components.

### Test and Production

Managed Solution

Reason:

Prevents uncontrolled modifications and improves deployment consistency.

---

## Environment Variables

Created:

CV SharePoint Folder URL

Purpose:

Demonstrate separation of configuration from business logic.

Learning:

The same solution can operate in multiple environments using different variable values.

---

## Connection References

Investigated Dataverse and Teams connection references.

Learning:

Flows do not connect directly to user connections.

Instead:

Flow
→ Connection Reference
→ Actual Connection

This enables solution portability across environments.

---

## Power Platform CLI

Installed and configured:

- PAC CLI
- Authentication Profile
- Environment Selection

Verified connection to:

Pro Playground

Commands explored:

```bash
pac auth
pac env
pac solution
```

---

## Source Control

Solution cloned using:

```bash
pac solution clone
```

Result:

The solution was converted into source-controlled files and added to Git.

Structure:

```text
src/
└── CVCaseIntelligencePlatform
```

---

## Git and GitHub

Completed:

```bash
git add .
git commit
git push
```

Learning:

Git stores local checkpoints.

GitHub stores and shares repository history.

---

## GitHub Actions

Created first workflow:

```yaml
Validate Repository
```

Trigger:

```yaml
on:
  push:
    branches:
      - main
```

Purpose:

Demonstrate the relationship between:

Git Push
→ GitHub
→ Pipeline
→ Workflow Execution

---

## Key Learnings

- Environment != Solution
- Managed != Unmanaged
- Dependencies affect deployment
- Environment Variables separate configuration from logic
- Connection References separate flows from physical connections
- Power Platform solutions can be stored in Git
- GitHub Actions provide the foundation for CI/CD
- Pipelines automate deployment between environments

---

## Outcome

The project has now transitioned from a Power Platform application to a version-controlled Power Platform solution prepared for modern ALM practices.