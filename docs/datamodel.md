# Data Model

## Overview

The solution uses Microsoft Dataverse as the primary data source.

---

## Consultant

Stores consultant profile information.

### Columns

- Name
- Title
- Department
- Office
- Seniority
- ProfessionalSummary

---

## Skill

Stores consultant competencies and technologies.

### Columns

- SkillName
- Category

---

## ConsultantSkill

Associates consultants with skills.

### Columns

- Consultant (Lookup)
- Skill (Lookup)
- Level
- YearsExperience

### Relationship

Consultant 1:N ConsultantSkill

Skill 1:N ConsultantSkill

---

## ProjectCase

Stores customer references and project experience.

### Columns

- CaseName
- Industry
- Customer
- Problem
- Solution

### Relationships

ProjectCase N:N Skill

---

## Certification

Stores certifications.

### Columns

- CertificationName
- Vendor
- CertificationLevel
- Description

---

## ConsultantCertification

Associates consultants with certifications.

### Columns

- Consultant (Lookup)
- Certification (Lookup)
- IssueDate
- ExpiryDate
- Status

---

## ConsultantProjectCase

Associates consultants with project cases.

### Columns

- Consultant (Lookup)
- ProjectCase (Lookup)
- Role
- Contribution

---

## Relationships

- Consultant 1:N ConsultantSkill
- Skill 1:N ConsultantSkill
- Consultant 1:N ConsultantProjectCase
- ProjectCase 1:N ConsultantProjectCase
- Consultant 1:N ConsultantCertification
- Certification 1:N ConsultantCertification
- ProjectCase N:N Skill
