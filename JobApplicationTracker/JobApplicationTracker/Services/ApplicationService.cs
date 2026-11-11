using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplicationTracker.Services
{
	public class ApplicationService
	{
		private readonly AppData _data;

		public ApplicationService(AppData data)
		{
			_data = data;
		}

		public bool ApplyForJob(int jobId, int candidateId)
		{
			Candidate? candidate = _data.Candidates.GetById(candidateId);

			Job? job = _data.JobsById.ContainsKey(jobId) ? _data.JobsById[jobId] : null;

			if (candidate == null || job == null || !job.IsOpen)
				return false;

			Company? company = _data.Companies.GetById(job.CompanyId);

			if (company == null || company.Status != CompanyStatus.Approved)
				return false;

			var applicationKey = (JobId: jobId, CandidateId: candidateId);
			if (_data.AppliedJobs.Contains(applicationKey))
				return false;

			Application application = new Application
			{
				Id = GetNextApplicationId(),
				JobId = jobId,
				CandidateId = candidateId,
				ApplicationDate = DateTime.Now,
				Status = ApplicationStatus.Submitted
			};

			bool IsAdded = _data.Applications.Add(application);
			if (!IsAdded)
				return false;

			_data.AppliedJobs.Add(applicationKey);
			return true;

		}
		
		private int GetNextApplicationId()
		{
			int maxId = 0;
			foreach (var application in _data.Applications.GetAll())
			{
				if (application.Id > maxId)
					maxId = application.Id;
			}

			return maxId + 1;
		}

		public bool RemoveApplicationById(int id)
		{
			Application? application = _data.Applications.GetById(id);

			if (application == null)
				return false;

			bool IsRemoved = _data.Applications.RemoveById(id);

			if (!IsRemoved)
				return false;

			_data.AppliedJobs.Remove((application.JobId, application.CandidateId));

			return true;

		}

	}
}
