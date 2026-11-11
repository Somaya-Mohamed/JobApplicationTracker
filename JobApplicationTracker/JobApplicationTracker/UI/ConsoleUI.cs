using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Interfaces;
using JobApplicationTracker.Helpers;
using JobApplicationTracker.Models;
using JobApplicationTracker.Services;
using System;
using System.Collections.Generic;

namespace JobApplicationTracker.UI
{

	public class ConsoleUI
	{
		private readonly AppData _data;
		private readonly CompanyService _companyService;
		private readonly RecruiterService _recruiterService;
		private readonly JobService _jobService;
		private readonly CandidateService _candidateService;
		private readonly ApplicationService _applicationService;

		public ConsoleUI(AppData data)
		{
			_data = data;

			_companyService = new CompanyService(data);
			_recruiterService = new RecruiterService(data);
			_jobService = new JobService(data);
			_candidateService = new CandidateService(data);
			_applicationService = new ApplicationService(data);
		}

		// ==================== Main Menu ====================

		public void Run()
		{
			bool isRunning = true;

			while (isRunning)
			{
				ConsolePrinter.WriteTitle("\n========== JOB APPLICATION TRACKER ==========");
				Console.WriteLine("1. Companies");
				Console.WriteLine("2. Recruiters");
				Console.WriteLine("3. Jobs");
				Console.WriteLine("4. Candidates");
				Console.WriteLine("5. Applications");
				Console.WriteLine("0. Exit");

				int choice = ReadInt("Choose an option: ");

				switch (choice)
				{
					case 1:
						CompaniesMenu();
						break;

					case 2:
						RecruitersMenu();
						break;

					case 3:
						JobsMenu();
						break;

					case 4:
						CandidatesMenu();
						break;

					case 5:
						ApplicationsMenu();
						break;

					case 0:
						isRunning = false;
						ConsolePrinter.WriteSuccess("Goodbye!");
						break;

					default:
						ConsolePrinter.WriteWarning("Invalid option. Try again.");
						break;
				}
			}
		}

		// ==================== Companies ====================

		private void CompaniesMenu()
		{
			bool back = false;

			while (!back)
			{
				ConsolePrinter.WriteTitle("\n========== COMPANIES ==========");
				Console.WriteLine("1. Add Company");
				Console.WriteLine("2. Update Company");
				Console.WriteLine("3. List Companies");
				Console.WriteLine("4. Remove Company");
				Console.WriteLine("5. Change Company Status");
				Console.WriteLine("6. List Companies By Status");
				Console.WriteLine("7. Undo Last Status Change");
				Console.WriteLine("0. Back");

				int choice = ReadInt("Choose an option: ");

				switch (choice)
				{
					case 1:
						AddCompany();
						break;

					case 2:
						UpdateCompany();
						break;

					case 3:
						ListCompanies();
						break;

					case 4:
						RemoveCompany();
						break;

					case 5:
						ChangeCompanyStatus();
						break;

					case 6:
						ListCompaniesByStatus();
						break;

					case 7:
						ConsolePrinter.WriteResult(
				_companyService.UndoLastStatusChange(),
				"Status change undone successfully.",
				"No status changes to undo."
			);
						break;

					case 0:
						back = true;
						break;

					default:
						ConsolePrinter.WriteWarning("Invalid option.");
						break;
				}
			}
		}

		private void AddCompany()
		{
			Company company = new Company
			{
				Id = GetNextId(_data.Companies.GetAll()),
				Name = ReadRequiredString("Company name: "),
				Industry = ReadOptionalString("Industry: "),
				City = ReadOptionalString("City: ")
			};

			bool result = _companyService.AddCompany(company);

			ConsolePrinter.WriteResult(
				result,
				"Company added successfully.",
				"Could not add company."
			);
		}

		private void UpdateCompany()
		{
			int id = ReadInt("Company ID: ");
			Company? company = _companyService.GetCompanyById(id);

			if (company == null)
			{
				ConsolePrinter.WriteWarning("Company not found.");
				return;
			}

			company.Name = ReadRequiredString("New name: ");
			company.Industry = ReadOptionalString("New industry: ");
			company.City = ReadOptionalString("New city: ");

			ConsolePrinter.WriteResult(
				_companyService.UpdateCompany(company),
				"Company updated successfully.",
				"Could not update company."
			);
		}

		private void ListCompanies()
		{
			Console.WriteLine("\nID   Name                  City          Status");
			Console.WriteLine("----------------------------------------------------");

			foreach (Company company in _companyService.GetAllCompanies())
			{
				Console.WriteLine(
					$"{company.Id,-4} {company.Name,-21} " +
					$"{company.City,-13} {company.Status}"
				);
			}
		}

		private void RemoveCompany()
		{
			int id = ReadInt("Company ID to remove: ");

			ConsolePrinter.WriteResult(
				_companyService.RemoveCompanyById(id),
				"Company removed successfully.",
				"Company not found."
			);
		}

		private void ChangeCompanyStatus()
		{
			int id = ReadInt("Company ID: ");

			ConsolePrinter.WriteInfo("Available statuses:");
			Console.WriteLine("0. Pending");
			Console.WriteLine("1. Approved");
			Console.WriteLine("2. Rejected");

			CompanyStatus status = ReadEnum<CompanyStatus>("New status: ");

			ConsolePrinter.WriteResult(
				_companyService.ChangeCompanyStatus(id, status),
				"Company status changed successfully.",
				"Could not change company status."
			);
		}

		private void ListCompaniesByStatus()
		{
			CompanyStatus status = ReadEnum<CompanyStatus>(
				"Enter status (Pending, Approved, Rejected): "
			);

			ConsolePrinter.WriteInfo($"\nCompanies with status {status}:");

			foreach (Company company in
					 _companyService.GetCompaniesByStatus(status))
			{
				Console.WriteLine(
					$"{company.Id} - {company.Name} - {company.City}"
				);
			}
		}

		// ==================== Recruiters ====================

		private void RecruitersMenu()
		{
			bool back = false;

			while (!back)
			{
				ConsolePrinter.WriteTitle("\n========== RECRUITERS ==========");
				Console.WriteLine("1. Add Recruiter");
				Console.WriteLine("2. Update Recruiter");
				Console.WriteLine("3. List Recruiters");
				Console.WriteLine("4. Remove Recruiter");
				Console.WriteLine("0. Back");

				int choice = ReadInt("Choose an option: ");

				switch (choice)
				{
					case 1:
						AddRecruiter();
						break;

					case 2:
						UpdateRecruiter();
						break;

					case 3:
						ListRecruiters();
						break;

					case 4:
						RemoveRecruiter();
						break;

					case 0:
						back = true;
						break;

					default:
						ConsolePrinter.WriteWarning("Invalid option.");
						break;
				}
			}
		}

		private void AddRecruiter()
		{
			Recruiter recruiter = new Recruiter
			{
				Id = GetNextId(_data.Recruiters.GetAll()),
				Name = ReadRequiredString("Recruiter name: "),
				Email = ReadRequiredString("Email: "),
				CompanyId = ReadInt("Company ID: ")
			};

			ConsolePrinter.WriteResult(
				_recruiterService.AddRecruiter(recruiter),
				"Recruiter added successfully.",
				"Could not add recruiter. Check the company ID and data."
			);
		}

		private void UpdateRecruiter()
		{
			int id = ReadInt("Recruiter ID: ");
			Recruiter? recruiter = _recruiterService.GetRecruiterById(id);

			if (recruiter == null)
			{
				ConsolePrinter.WriteWarning("Recruiter not found.");
				return;
			}

			recruiter.Name = ReadRequiredString("New name: ");
			recruiter.Email = ReadRequiredString("New email: ");
			recruiter.CompanyId = ReadInt("New company ID: ");

			ConsolePrinter.WriteResult(
				_recruiterService.UpdateRecruiter(recruiter),
				"Recruiter updated successfully.",
				"Could not update recruiter."
			);
		}

		private void ListRecruiters()
		{
			Console.WriteLine("\nID   Name                  Email                         Company ID");
			Console.WriteLine("---------------------------------------------------------------------");

			foreach (Recruiter recruiter in _recruiterService.GetAllRecruiters())
			{
				Console.WriteLine(
					$"{recruiter.Id,-4} {recruiter.Name,-21} " +
					$"{recruiter.Email,-29} {recruiter.CompanyId}"
				);
			}
		}

		private void RemoveRecruiter()
		{
			int id = ReadInt("Recruiter ID to remove: ");

			ConsolePrinter.WriteResult(
				_recruiterService.RemoveRecruiterById(id),
				"Recruiter removed successfully.",
				"Recruiter not found."
			);
		}

		// ==================== Jobs ====================

		private void JobsMenu()
		{
			bool back = false;

			while (!back)
			{
				ConsolePrinter.WriteTitle("\n========== JOBS ==========");
				Console.WriteLine("1. Add Job");
				Console.WriteLine("2. Update Job");
				Console.WriteLine("3. List Jobs");
				Console.WriteLine("4. Find Job By ID");
				Console.WriteLine("5. Remove Job");
				Console.WriteLine("0. Back");

				int choice = ReadInt("Choose an option: ");

				switch (choice)
				{
					case 1:
						AddJob();
						break;

					case 2:
						UpdateJob();
						break;

					case 3:
						ListJobs();
						break;

					case 4:
						FindJob();
						break;

					case 5:
						RemoveJob();
						break;

					case 0:
						back = true;
						break;

					default:
						ConsolePrinter.WriteWarning("Invalid option.");
						break;
				}
			}
		}

		private void AddJob()
		{
			Job job = new Job
			{
				Id = GetNextId(_data.Jobs.GetAll()),
				Title = ReadRequiredString("Job title: "),
				Description = ReadOptionalString("Description: "),
				Location = ReadOptionalString("Location: "),
				Salary = ReadDecimal("Salary: "),
				IsOpen = ReadBool("Is the job open? (y/n): "),
				DatePosted = DateTime.Today,
				CompanyId = ReadInt("Company ID: "),
				RecruiterId = ReadInt("Recruiter ID: ")
			};

			ConsolePrinter.WriteResult(
				_jobService.AddJob(job),
				"Job added successfully.",
				"Could not add job. Make sure the company exists and is Approved."
			);
		}

		private void UpdateJob()
		{
			int id = ReadInt("Job ID: ");
			Job? job = _jobService.GetJobById(id);

			if (job == null)
			{
				ConsolePrinter.WriteWarning("Job not found.");
				return;
			}

			job.Title = ReadRequiredString("New title: ");
			job.Description = ReadOptionalString("New description: ");
			job.Location = ReadOptionalString("New location: ");
			job.Salary = ReadDecimal("New salary: ");
			job.IsOpen = ReadBool("Is the job open? (y/n): ");

			ConsolePrinter.WriteResult(
				_jobService.UpdateJob(job),
				"Job updated successfully.",
				"Could not update job."
			);
		}

		private void ListJobs()
		{
			Console.WriteLine("\nID   Title                       Salary       Open   Company");
			Console.WriteLine("----------------------------------------------------------------");

			foreach (Job job in _data.Jobs.GetAll())
			{
				Console.WriteLine(
					$"{job.Id,-4} {job.Title,-27} {job.Salary,-12} " +
					$"{job.IsOpen,-6} {job.CompanyId}"
				);
			}
		}

		private void FindJob()
		{
			int id = ReadInt("Job ID: ");
			Job? job = _jobService.GetJobById(id);

			if (job == null)
			{
				ConsolePrinter.WriteWarning("Job not found.");
				return;
			}

			Console.WriteLine($"ID: {job.Id}");
			Console.WriteLine($"Title: {job.Title}");
			Console.WriteLine($"Salary: {job.Salary}");
			Console.WriteLine($"Location: {job.Location}");
			Console.WriteLine($"Open: {job.IsOpen}");
			Console.WriteLine($"Company ID: {job.CompanyId}");
			Console.WriteLine($"Recruiter ID: {job.RecruiterId}");
		}

		private void RemoveJob()
		{
			int id = ReadInt("Job ID to remove: ");

			ConsolePrinter.WriteResult(
				_jobService.RemoveJobById(id),
				"Job removed successfully.",
				"Job not found."
			);
		}

		// ==================== Candidates ====================

		private void CandidatesMenu()
		{
			bool back = false;

			while (!back)
			{
				ConsolePrinter.WriteTitle("\n========== CANDIDATES ==========");
				Console.WriteLine("1. Add Candidate");
				Console.WriteLine("2. Update Candidate");
				Console.WriteLine("3. List Candidates");
				Console.WriteLine("4. Remove Candidate");
				Console.WriteLine("0. Back");

				int choice = ReadInt("Choose an option: ");

				switch (choice)
				{
					case 1:
						AddCandidate();
						break;

					case 2:
						UpdateCandidate();
						break;

					case 3:
						ListCandidates();
						break;

					case 4:
						RemoveCandidate();
						break;

					case 0:
						back = true;
						break;

					default:
						ConsolePrinter.WriteWarning("Invalid option.");
						break;
				}
			}
		}

		private void AddCandidate()
		{
			Candidate candidate = new Candidate
			{
				Id = GetNextId(_data.Candidates.GetAll()),
				FullName = ReadRequiredString("Full name: "),
				Email = ReadRequiredString("Email: "),
				PhoneNumber = ReadOptionalString("\t\t\t\tPhoneNumber = ReadOptionalString(\"Phone: \"),\r\n: "),
				YearsOfExperience = ReadInt("Years of experience: ")
			};

			ConsolePrinter.WriteResult(
				_candidateService.AddCandidate(candidate),
				"Candidate added successfully.",
				"Could not add candidate. The email may already exist."
			);
		}

		private void UpdateCandidate()
		{
			int id = ReadInt("Candidate ID: ");
			Candidate? candidate = _candidateService.GetCandidateById(id);

			if (candidate == null)
			{
				ConsolePrinter.WriteWarning("Candidate not found.");
				return;
			}

			candidate.FullName = ReadRequiredString("New full name: ");
			candidate.Email = ReadRequiredString("New email: ");
			candidate.PhoneNumber = ReadOptionalString("New PhoneNumber: ");
			candidate.YearsOfExperience = ReadInt("New years of experience: ");

			ConsolePrinter.WriteResult(
				_candidateService.UpdateCandidate(candidate),
				"Candidate updated successfully.",
				"Could not update candidate. The email may already exist."
			);
		}

		private void ListCandidates()
		{
			Console.WriteLine("\nID   Full Name                 Email                         Experience");
			Console.WriteLine("-----------------------------------------------------------------------");

			foreach (Candidate candidate in _candidateService.GetAllCandidates())
			{
				Console.WriteLine(
					$"{candidate.Id,-4} {candidate.FullName,-25} " +
					$"{candidate.Email,-29} {candidate.YearsOfExperience}"
				);
			}
		}

		private void RemoveCandidate()
		{
			int id = ReadInt("Candidate ID to remove: ");

			ConsolePrinter.WriteResult(
				_candidateService.RemoveCandidateById(id),
				"Candidate removed successfully.",
				"Candidate not found."
			);
		}

		// ==================== Applications ====================

		private void ApplicationsMenu()
		{
			bool back = false;

			while (!back)
			{
				ConsolePrinter.WriteTitle("\n========== APPLICATIONS ==========");
				Console.WriteLine("1. Apply For Job");
				Console.WriteLine("2. List Applications");
				Console.WriteLine("3. Update Application Status");
				Console.WriteLine("4. Remove Application");
				Console.WriteLine("0. Back");

				int choice = ReadInt("Choose an option: ");

				switch (choice)
				{
					case 1:
						ApplyForJob();
						break;

					case 2:
						ListApplications();
						break;

					case 3:
						UpdateApplicationStatus();
						break;

					case 4:
						RemoveApplication();
						break;

					case 0:
						back = true;
						break;

					default:
						ConsolePrinter.WriteWarning("Invalid option.");
						break;
				}
			}
		}

		private void ApplyForJob()
		{
			int candidateId = ReadInt("Candidate ID: ");
			int jobId = ReadInt("Job ID: ");

			ConsolePrinter.WriteResult(
				_applicationService.ApplyForJob(jobId, candidateId),
				"Application submitted successfully.",
				"Application failed. Check candidate, job, company status, and duplicate application."
			);
		}

		private void ListApplications()
		{
			Console.WriteLine("\nID   Job ID   Candidate ID   Date                  Status");
			Console.WriteLine("--------------------------------------------------------------");

			foreach (Application application in _data.Applications.GetAll())
			{
				Console.WriteLine(
					$"{application.Id,-4} {application.JobId,-8} " +
					$"{application.CandidateId,-14} " +
					$"{application.ApplicationDate,-21:g} {application.Status}"
				);
			}
		}

		private void UpdateApplicationStatus()
		{
			int id = ReadInt("Application ID: ");
			Application? application = _data.Applications.GetById(id);

			if (application == null)
			{
				ConsolePrinter.WriteWarning("Application not found.");
				return;
			}

			ApplicationStatus status =
				ReadEnum<ApplicationStatus>("New status: ");

			application.Status = status;

			ConsolePrinter.WriteResult(
				_data.Applications.Update(application),
				"Application status updated successfully.",
				"Could not update application."
			);
		}

		private void RemoveApplication()
		{
			int id = ReadInt("Application ID to remove: ");

			ConsolePrinter.WriteResult(
				_applicationService.RemoveApplicationById(id),
				"Application removed successfully.",
				"Application not found."
			);
		}

		// ==================== Input Helpers ====================

		private int ReadInt(string message)
		{
			while (true)
			{
				ConsolePrinter.WritePrompt(message);

				string? input = Console.ReadLine();

				if (int.TryParse(input, out int value))
					return value;

				Console.WriteLine("Please enter a valid whole number.");
			}
		}

		private decimal ReadDecimal(string message)
		{
			while (true)
			{
				ConsolePrinter.WritePrompt(message);

				string? input = Console.ReadLine();

				if (decimal.TryParse(input, out decimal value) && value > 0)
					return value;

				Console.WriteLine("Please enter a valid positive salary.");
			}
		}

		private string ReadRequiredString(string message)
		{
			while (true)
			{
				ConsolePrinter.WritePrompt(message);

				string? input = Console.ReadLine();

				if (!string.IsNullOrWhiteSpace(input))
					return input.Trim();

				ConsolePrinter.WriteWarning("This field cannot be empty.");
			}
		}

		private string? ReadOptionalString(string message)
		{
			ConsolePrinter.WritePrompt(message);
			string? input = Console.ReadLine();

			return string.IsNullOrWhiteSpace(input)
				? null
				: input.Trim();
		}

		private bool ReadBool(string message)
		{
			while (true)
			{
				ConsolePrinter.WritePrompt(message);
				string? input = Console.ReadLine()?.Trim().ToLower();

				if (input == "y" || input == "yes")
					return true;

				if (input == "n" || input == "no")
					return false;

				Console.WriteLine("Please enter y or n.");
			}
		}

		private TEnum ReadEnum<TEnum>(string message)
			where TEnum : struct, Enum
		{
			while (true)
			{
				ConsolePrinter.WritePrompt(message);
				string? input = Console.ReadLine();

				if (Enum.TryParse(input, true, out TEnum value) &&
					Enum.IsDefined(typeof(TEnum), value))
				{
					return value;
				}

				ConsolePrinter.WriteWarning("Invalid value. Please enter a valid option.");
			}
		}

		private int GetNextId<T>(IEnumerable<T> items)
			where T : IEntity
		{
			int maxId = 0;

			foreach (T item in items)
			{
				if (item.Id > maxId)
					maxId = item.Id;
			}

			return maxId + 1;
		}
	}
}
