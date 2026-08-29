# Day 4 Notes

## Canvas App vs Model-Driven App

Model-Driven Apps are well suited for managing and maintaining data.

Canvas Apps provide a custom user experience tailored to specific business processes.

The Consultant Finder Canvas App was created to provide a faster and more intuitive consultant search experience than navigating Dataverse relationships directly.

---

## Delegation

A delegation warning was identified when filtering consultant records by title.

Current dataset size is approximately 100 consultants, which means the warning does not currently impact functionality.

However, larger datasets could result in incomplete results if filtering is performed locally rather than by Dataverse.

---

## Choice vs Choices

Department was implemented as a multi-select Choice column.

This resulted in more complex behavior in Canvas Apps compared to single Choice columns such as Office and Title.

The design was intentionally retained as a learning exercise to better understand Dataverse data types and Power Fx behavior.
