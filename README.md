# Job Application Tracker – Sprint 1

A console-based Job Application Tracker built with C# and .NET. The project manages companies, recruiters, jobs, candidates, and job applications using in-memory collections and generic data storage.

## Project Overview

The Job Application Tracker is designed to simulate a simple recruitment management system.

It allows users to manage recruitment data through a console menu while applying basic business rules and practicing C# collections, generics, and object-oriented programming.

**Sprint 1 focuses on:**
- Generic data storage.
- Managing entities using collections.
- Implementing basic CRUD operations.
- Applying business rules.
- Keeping related collections synchronized.
- Handling invalid user input safely.

## Technologies Used

- C#
- .NET
- Object-Oriented Programming (OOP)
- Generics
- Collections:
  - `List<T>`
  - `Dictionary<TKey, TValue>`
  - `HashSet<T>`
  - `Stack<T>`

## Features

### 1. Company Management
- Add, update, view, and remove companies.
- Manage company statuses:
  - Pending
  - Approved
  - Rejected
- Filter companies by status.
- Undo the last company status change using a Stack.

### 2. Recruiter Management
- Add, update, view, and remove recruiters.
- Associate recruiters with existing companies.

### 3. Job Management
- Add, update, view, and remove jobs.
- Find jobs by ID using a Dictionary.
- Keep the jobs DataStore and Dictionary synchronized.
- Prevent companies with Pending or Rejected status from posting new jobs.

### 4. Candidate Management
- Add, update, view, and remove candidates.
- Prevent duplicate email addresses.
- Email comparison is case-insensitive.

### 5. Application Management
- Apply for available jobs.
- Prevent duplicate applications for the same job and candidate.
- Allow applications only for open jobs belonging to Approved companies.
- Update application statuses.
- Remove applications while keeping the applied-jobs HashSet synchronized.

### 6. Input Validation
- Handle invalid numeric input safely.
- Validate required fields.
- Prevent invalid operations from crashing the application.

## Collections Usage

| Collection | Purpose |
|---|---|
| `List<T>` | Stores entities inside the generic DataStore. |
| `Dictionary<int, Job>` | Provides fast job lookup by ID. |
| `HashSet<string>` | Prevents duplicate candidate emails. |
| `HashSet<(int JobId, int CandidateId)>` | Prevents duplicate job applications. |
| `Stack<(int CompanyId, CompanyStatus OldStatus)>` | Stores previous company statuses to support undo. |

## Project Structure

```text
JobApplicationTracker/
│
├── Data/
│   ├── AppData.cs
│   ├── DataSeeder.cs
│   └── DataStore.cs
│
├── Enums/
│   ├── ApplicationStatus.cs
│   └── CompanyStatus.cs
│
├── Helpers/
│   └── ConsolePrinter.cs
│
├── Interfaces/
│   └── IEntity.cs
│
├── Models/
│   ├── Application.cs
│   ├── Candidate.cs
│   ├── Company.cs
│   ├── Job.cs
│   └── Recruiter.cs
│
├── Services/
│   ├── ApplicationService.cs
│   ├── CandidateService.cs
│   ├── CompanyService.cs
│   ├── JobService.cs
│   └── RecruiterService.cs
│
├── UI/
│   └── ConsoleUI.cs
│
└── Program.cs
```

## Seed Data

The application starts with predefined sample data:

- 3 Companies
- 3 Recruiters
- 6 Jobs
- 5 Candidates

This data is initialized through `DataSeeder` to make the application ready for testing.

## How to Run

1. Clone the repository:

```bash
git clone https://github.com/Somaya-Mohamed/JobApplicationTracker
```

2. Open the solution in Visual Studio.

3. Build the project.

4. Run the application.

The main console menu will appear, allowing you to navigate through the available operations.

## Sprint 1 Scope

This sprint focuses on in-memory data management and C# collections.

**Included:**
- E1 – Entity models and enums.
- E2 – Console menus and navigation.
- E3 – Basic entity operations.
- E5 – Job lookup using Dictionary.
- M1 – Generic DataStore.
- H1 – Prevent duplicate applications using HashSet.
- H2 – Undo company status changes using Stack.

**Out of Scope:**
- Database integration.
- Entity Framework Core.
- LINQ.
- Authentication and authorization.
- Web API implementation.

## Important Notes

- All application data is stored in memory.
- Data is reset when the application is restarted.
- No database is connected in this sprint.
- The project is developed incrementally through requirement-based Git commits.

## Author

**Somaya Mohamed**

.NET Backend Developer

[GitHub](https://github.com/Somaya-Mohamed) · [Portfolio](https://somaya-mohamed.github.io/My-portfolio/)
