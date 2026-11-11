using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplicationTracker.Services
{
	public class RecruiterService
	{
		private readonly AppData _data;

		public RecruiterService(AppData data)
		{
			_data = data;
		}

		public bool AddRecruiter(Recruiter recruiter)
		{
			if (recruiter == null || string.IsNullOrWhiteSpace(recruiter.Name) || string.IsNullOrWhiteSpace(recruiter.Email))
				return false;

			Company? company = _data.Companies.GetById(recruiter.CompanyId);
			if(company == null)
				return false;

			return _data.Recruiters.Add(recruiter);
		}

		public Recruiter? GetRecruiterById(int id)
		{
			return _data.Recruiters.GetById(id);
		}

		public IEnumerable<Recruiter> GetAllRecruiters()
		{
			return _data.Recruiters.GetAll();
		}

		public bool UpdateRecruiter(Recruiter recruiter)
		{
			if (recruiter == null || string.IsNullOrWhiteSpace(recruiter.Name) || string.IsNullOrWhiteSpace(recruiter.Email))
				return false;

			Company? company = _data.Companies.GetById(recruiter.CompanyId);
			if (company == null)
				return false;

			return _data.Recruiters.Update(recruiter);
		}

		public bool RemoveRecruiterById(int id)
		{
			return _data.Recruiters.RemoveById(id);
		}
	}
}
