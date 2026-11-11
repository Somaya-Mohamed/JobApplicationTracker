Job Application Tracker — Sprint 1
A C# Console Application for managing companies, recruiters, job vacancies, candidates, and job applications using in-memory collections and generic programming.
Project Overview
This is Sprint 1 of the Job Application Tracker. It focuses on C# fundamentals, Collections, Generics, service-based organization, and safe console interaction.

All data is stored in memory. Data is reset when the application restarts.
Features
Companies
- Add, update, list, and remove companies.
- Change company status: Pending, Approved, or Rejected.
- List companies by status.
- Undo the most recent status change using a Stack.
- Prevent adding jobs to companies that are not Approved.
Recruiters
- Add, update, list, and remove recruiters.
- Associate recruiters with existing companies.
Jobs
- Add, update, list, find, and remove jobs.
- Find jobs by ID using a Dictionary.
- Keep the Jobs DataStore and Dictionary synchronized.
- Prevent adding jobs to companies that are not Approved.
Candidates
- Add, update, list, and remove candidates.
- Prevent duplicate email addresses.
- Compare emails case-insensitively using a HashSet.
Applications
- Apply for an open job.
- Validate candidate and job existence.
- Allow applications only when the job's company is Approved.
- Prevent the same candidate from applying to the same job more than once.
- List, update application status, and remove applications.
- Keep the applied-jobs HashSet synchronized when applications are removed.
Console User Interface
- Main menu and separate menus for each entity.
- Colored titles, prompts, success messages, warnings, and errors.
- Centralized console formatting through ConsolePrinter.
- Safe input handling for integers, decimals, text, Boolean values, and enum values.
Technologies & Concepts
- C# and .NET Console Application
- Object-Oriented Programming (OOP)
- Interfaces and Generic Constraints
- Generic DataStore
- List, Dictionary, HashSet, and Stack
- IEnumerable
- In-memory data storage
- Service-based organization
- Console input validation
Project Structure
JobApplicationTracker/
├── Data/
│   ├── AppData.cs
│   ├── DataSeeder.cs
│   └── DataStore.cs
├── Enums/
│   ├── ApplicationStatus.cs
│   └── CompanyStatus.cs
├── Helpers/
│   └── ConsolePrinter.cs
├── Interfaces/
│   └── IEntity.cs
├── Models/
│   ├── Application.cs
│   ├── Candidate.cs
│   ├── Company.cs
│   ├── Job.cs
│   └── Recruiter.cs
├── Practice/
│   ├── CollectionsPractice.cs
│   └── GenericMethods.cs
├── Services/
│   ├── ApplicationService.cs
│   ├── CandidateService.cs
│   ├── CompanyService.cs
│   ├── JobService.cs
│   └── RecruiterService.cs
├── UI/
│   └── ConsoleUI.cs
└── Program.cs
Getting Started
Prerequisites
- Visual Studio or another C# IDE.
- A .NET SDK compatible with the project's target framework.
Run the Application
1. Clone the repository:
git clone YOUR_REPOSITORY_URL
2. Open the solution in Visual Studio.
3. Build the solution.
4. Run the project.
The application seeds initial data automatically when it starts.
Sprint 1 Scope
- Models and enums.
- Generic DataStore implementation.
- Seed data.
- Basic entity operations.
- Dictionary-based job lookup.
- Case-insensitive candidate email uniqueness.
- Duplicate application prevention.
- Undo company status changes.
- Console menus and colored output.
- Safe input handling.
Git Workflow
Check the current working tree:
git status
Stage and commit completed work:
git add .
git commit -m "E2: add console menus and colored output"
Push commits:
git push
After all Sprint 1 scenarios pass, create and push the sprint tag:
git tag sprint-1
git push origin sprint-1
Important Notes
- No database or Entity Framework is used in this sprint.
- LINQ is not used in the project implementation.
- All data is stored in memory and is reset when the application restarts.
Sprint 1 — Job Application Tracker