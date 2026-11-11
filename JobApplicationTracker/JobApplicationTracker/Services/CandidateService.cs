using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplicationTracker.Services
{
	public class CandidateService
	{
		private readonly AppData _data;

		public CandidateService(AppData data)
		{
			_data = data;
		}

		public bool AddCandidate(Candidate candidate)
		{
			if (candidate == null || string.IsNullOrWhiteSpace(candidate.FullName) || string.IsNullOrWhiteSpace(candidate.Email))
				return false;

			if (_data.CandidateEmails.Contains(candidate.Email))
				return false;

			bool IsAdded = _data.Candidates.Add(candidate);
			
			if (!IsAdded)
				return false;

			_data.CandidateEmails.Add(candidate.Email);

			return true;
		}

		public Candidate? GetCandidateById(int id)
		{
			return _data.Candidates.GetById(id);
		}

		public IEnumerable<Candidate> GetAllCandidates()
		{
			return _data.Candidates.GetAll();
		}

		public bool UpdateCandidate(Candidate candidate)
		{
			if(candidate == null || string.IsNullOrWhiteSpace(candidate.FullName) || string.IsNullOrWhiteSpace(candidate.Email))
				return false;

			Candidate? ExistingCandidate = _data.Candidates.GetById(candidate.Id);

			if (ExistingCandidate == null)
				return false;

			bool IsEmailChanged = !string.Equals(candidate.Email, ExistingCandidate.Email, StringComparison.OrdinalIgnoreCase);

			if (IsEmailChanged && _data.CandidateEmails.Contains(candidate.Email))
				return false;

			bool IsUpdated = _data.Candidates.Update(candidate);

			if(IsEmailChanged && IsUpdated)
			{
				_data.CandidateEmails.Remove(ExistingCandidate.Email);
				_data.CandidateEmails.Add(candidate.Email);
			}

			return true;
		}

		public bool RemoveCandidateById(int id)
		{
			Candidate? candidate = _data.Candidates.GetById(id);

			if (candidate == null)
				return false;

			bool IsRemoved = _data.Candidates.RemoveById(id);

			if (!IsRemoved)
				return false;

			_data.CandidateEmails.Remove(candidate.Email);

			return true;
		}
	}
}
