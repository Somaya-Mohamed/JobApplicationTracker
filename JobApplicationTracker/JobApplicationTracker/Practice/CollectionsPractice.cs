using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplicationTracker.Practice
{
	public static class CollectionsPractice
	{
		public static void Run(AppData appData)
		{
			Console.WriteLine("===== Collections Practice =====");

			PracticeList(appData);
			PracticeDictionary(appData);
			PracticeHashSet(appData);
			PracticeQueue(appData);
			PracticeStack();
		}

		// CL1: List<T>
		private static void PracticeList(AppData appData)
		{
			Console.WriteLine("\n--- CL1: List ---");

			// Get job titles from the existing Jobs DataStore.
			List<string> jobTitles = new();

			foreach (Job job in appData.Jobs.GetAll())
			{
				jobTitles.Add(job.Title);
			}

			// Add
			jobTitles.Add("Junior .NET Developer");

			Console.WriteLine("After Add:");
			DisplayList(jobTitles);

			// Search
			string searchTitle = "Junior .NET Developer";
			int foundIndex = -1;

			for (int i = 0; i < jobTitles.Count; i++)
			{
				if (jobTitles[i] == searchTitle)
				{
					foundIndex = i;
					break;
				}
			}

			if (foundIndex != -1)
				Console.WriteLine($"Found: {jobTitles[foundIndex]}");
			else
				Console.WriteLine("Job title not found.");

			// Update
			if (foundIndex != -1)
			{
				jobTitles[foundIndex] = "Senior .NET Developer";
				Console.WriteLine("After Update:");
				DisplayList(jobTitles);
			}

			// Remove
			bool removed = jobTitles.Remove("Senior .NET Developer");

			Console.WriteLine(removed
				? "Job title removed successfully."
				: "Job title was not found.");

			Console.WriteLine("After Remove:");
			DisplayList(jobTitles);
		}

		private static void DisplayList(List<string> items)
		{
			foreach (string item in items)
			{
				Console.WriteLine(item);
			}
		}

		// CL2: Dictionary<TKey, TValue>
		private static void PracticeDictionary(AppData appData)
		{
			Console.WriteLine("\n--- CL2: Dictionary ---");

			Console.Write("Enter Job ID to search: ");

			if (!int.TryParse(Console.ReadLine(), out int jobId))
			{
				Console.WriteLine("Invalid Job ID.");
				return;
			}

			if (appData.JobsById.TryGetValue(jobId, out Job? job))
			{
				Console.WriteLine($"Job found: {job.Title}");
			}
			else
			{
				Console.WriteLine("Job not found.");
			}
		}

		// CL3: HashSet<T>
		private static void PracticeHashSet(AppData appData)
		{
			Console.WriteLine("\n--- CL3: HashSet ---");

			HashSet<string> candidateEmails =
				new(StringComparer.OrdinalIgnoreCase);

			// Add existing candidate emails.
			foreach (Candidate candidate in appData.Candidates.GetAll())
			{
				candidateEmails.Add(candidate.Email);
			}

			Console.Write("Enter candidate email: ");
			string? email = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(email))
			{
				Console.WriteLine("Email cannot be empty.");
				return;
			}

			// Add returns false if the email already exists.
			bool added = candidateEmails.Add(email.Trim());

			if (added)
				Console.WriteLine("Email added successfully.");
			else
				Console.WriteLine("This email already exists.");
		}

		// CL4-A: Queue<T>
		private static void PracticeQueue(AppData appData)
		{
			Console.WriteLine("\n--- CL4: Queue ---");

			Queue<Job> pendingJobs = new();

			// Add jobs in their current traversal order.
			foreach (Job job in appData.Jobs.GetAll())
			{
				pendingJobs.Enqueue(job);
			}

			Console.WriteLine($"Pending jobs: {pendingJobs.Count}");

			// Peek: read the first job without removing it.
			if (pendingJobs.TryPeek(out Job? firstJob))
			{
				Console.WriteLine($"Next job: {firstJob.Title}");
			}

			// Dequeue: remove the first job.
			if (pendingJobs.TryDequeue(out Job? processedJob))
			{
				Console.WriteLine($"Processed job: {processedJob.Title}");
			}

			Console.WriteLine($"Remaining jobs: {pendingJobs.Count}");
		}

		// CL4-B: Stack<T>
		private static void PracticeStack()
		{
			Console.WriteLine("\n--- CL4: Stack ---");

			Stack<CompanyStatus> statusHistory = new();

			// Push: save status history.
			statusHistory.Push(CompanyStatus.Pending);
			statusHistory.Push(CompanyStatus.Approved);
			statusHistory.Push(CompanyStatus.Rejected);

			Console.WriteLine($"History count: {statusHistory.Count}");

			// Peek: read the latest status without removing it.
			if (statusHistory.TryPeek(out CompanyStatus currentStatus))
			{
				Console.WriteLine($"Latest status: {currentStatus}");
			}

			// Pop: retrieve and remove the latest status.
			if (statusHistory.TryPop(out CompanyStatus previousStatus))
			{
				Console.WriteLine($"Retrieved status: {previousStatus}");
			}

			Console.WriteLine($"Remaining history: {statusHistory.Count}");
		}
	}
}
