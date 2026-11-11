using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;
using JobApplicationTracker.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplicationTracker.Data
{
	public class DataSeeder
	{

		public static void Seed(AppData data)
		{
			// Seed Companies
			data.Companies.Add(new Company
			{
				Id = 1,
				Name = "Tech Solutions",
				Industry = "Software",
				City = "Cairo",
				Status = CompanyStatus.Approved
			});

			data.Companies.Add(new Company
			{
				Id = 2,
				Name = "Digital Future",
				Industry = "IT",
				City = "Tanta",
				Status = CompanyStatus.Approved
			});

			data.Companies.Add(new Company
			{
				Id = 3,
				Name = "Smart Systems",
				Industry = "Technology",
				City = "Mansoura",
				Status = CompanyStatus.Pending
			});

			RecruiterService recruiterService = new RecruiterService(data);
			// Seed Recruiters
			recruiterService.AddRecruiter(new Recruiter
			{
				Id = 1,
				Name = "Ahmed Hassan",
				Email = "ahmed@techsolutions.com",
				CompanyId = 1
			});

			recruiterService.AddRecruiter(new Recruiter
			{
				Id = 2,
				Name = "Mona Ali",
				Email = "mona@techsolutions.com",
				CompanyId = 1
			});

			recruiterService.AddRecruiter(new Recruiter
			{
				Id = 3,
				Name = "Omar Khaled",
				Email = "omar@digitalfuture.com",
				CompanyId = 2
			});

			JobService jobService = new JobService(data);
			// Seed Jobs
			jobService.AddJob(new Job
			{
				Id = 1,
				Title = "Junior Backend .NET Developer",
				Description = "Develop and maintain backend services using ASP.NET Core.",
				Salary = 10000,
				Location = "Cairo",
				IsOpen = true,
				DatePosted = DateTime.Today.AddDays(-10),
				CompanyId = 1,
				RecruiterId = 1
			});

			jobService.AddJob(new Job
			{
				Id = 2,
				Title = "Software Engineer",
				Description = "Work on software development and system maintenance.",
				Salary = 12000,
				Location = "Cairo",
				IsOpen = true,
				DatePosted = DateTime.Today.AddDays(-8),
				CompanyId = 1,
				RecruiterId = 1
			});

			jobService.AddJob(new Job
			{
				Id = 3,
				Title = "Database Developer",
				Description = "Design and maintain SQL Server databases.",
				Salary = 11000,
				Location = "Cairo",
				IsOpen = false,
				DatePosted = DateTime.Today.AddDays(-5),
				CompanyId = 1,
				RecruiterId = 2
			});

			jobService.AddJob(new Job
			{
				Id = 4,
				Title = "Junior .NET Developer",
				Description = "Build and maintain web APIs using C# and .NET.",
				Salary = 9000,
				Location = "Tanta",
				IsOpen = true,
				DatePosted = DateTime.Today.AddDays(-7),
				CompanyId = 2,
				RecruiterId = 3
			});

			jobService.AddJob(new Job
			{
				Id = 5,
				Title = "Frontend Developer",
				Description = "Build responsive user interfaces for web applications.",
				Salary = 8500,
				Location = "Tanta",
				IsOpen = true,
				DatePosted = DateTime.Today.AddDays(-4),
				CompanyId = 2,
				RecruiterId = 3
			});

			jobService.AddJob(new Job
			{
				Id = 6,
				Title = "QA Engineer",
				Description = "Test applications and report software defects.",
				Salary = 8000,
				Location = "Tanta",
				IsOpen = false,
				DatePosted = DateTime.Today.AddDays(-2),
				CompanyId = 2,
				RecruiterId = 3
			});

			CandidateService candidateService = new CandidateService(data);
			// Seed Candidates
			candidateService.AddCandidate(new Candidate
			{
				Id = 1,
				FullName = "Sara Mohamed",
				Email = "sara.mohamed@example.com",
				PhoneNumber = "01012345678",
				YearsOfExperience = 1
			});

			candidateService.AddCandidate(new Candidate
			{
				Id = 2,
				FullName = "Ali Hassan",
				Email = "ali.hassan@example.com",
				PhoneNumber = "01112345678",
				YearsOfExperience = 2
			});

			candidateService.AddCandidate(new Candidate
			{
				Id = 3,
				FullName = "Nour Ahmed",
				Email = "nour.ahmed@example.com",
				PhoneNumber = "01212345678",
				YearsOfExperience = 0
			});

			candidateService.AddCandidate(new Candidate
			{
				Id = 4,
				FullName = "Youssef Adel",
				Email = "youssef.adel@example.com",
				PhoneNumber = "01512345678",
				YearsOfExperience = 3
			});

			candidateService.AddCandidate(new Candidate
			{
				Id = 5,
				FullName = "Mariam Samir",
				Email = "mariam.samir@example.com",
				PhoneNumber = "01098765432",
				YearsOfExperience = 1
			});
		}



	}
}