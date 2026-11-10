using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplicationTracker.Data
{
	public class AppData
	{
		public DataStore<Company> Companies { get; }
		public DataStore<Recruiter> Recruiters { get; }
		public DataStore<Job> Jobs { get; }
		public DataStore<Candidate> Candidates { get; }
		public DataStore<Application> Applications { get; }

		public AppData()
		{
			Companies = new DataStore<Company>();
			Recruiters = new DataStore<Recruiter>();
			Jobs = new DataStore<Job>();
			Candidates = new DataStore<Candidate>();
			Applications = new DataStore<Application>();
		}
	}
}
