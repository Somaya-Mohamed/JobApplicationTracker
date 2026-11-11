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
			if (candidate == null)
				return false;

			if (string.IsNullOrWhiteSpace(candidate.FullName))
				return false;

			if (string.IsNullOrWhiteSpace(candidate.Email))
				return false;

			if (_data.CandidateEmails.Contains(candidate.Email))
				return false;

			bool isAdded = _data.Candidates.Add(candidate);

			if (!isAdded)
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
			if (candidate == null)
				return false;

			if (string.IsNullOrWhiteSpace(candidate.FullName))
				return false;

			if (string.IsNullOrWhiteSpace(candidate.Email))
				return false;

			Candidate? existingCandidate =
				_data.Candidates.GetById(candidate.Id);

			if (existingCandidate == null)
				return false;

			bool isEmailChanged = !string.Equals(
				existingCandidate.Email,
				candidate.Email,
				StringComparison.OrdinalIgnoreCase
			);

			if (isEmailChanged &&
				_data.CandidateEmails.Contains(candidate.Email))
			{
				return false;
			}

			bool isUpdated = _data.Candidates.Update(candidate);

			if (!isUpdated)
				return false;

			if (isEmailChanged)
			{
				_data.CandidateEmails.Remove(existingCandidate.Email);
				_data.CandidateEmails.Add(candidate.Email);
			}

			return true;
		}

		public bool RemoveCandidate(int id)
		{
			Candidate? candidate = _data.Candidates.GetById(id);

			if (candidate == null)
				return false;

			bool isRemoved = _data.Candidates.RemoveById(id);

			if (!isRemoved)
				return false;

			_data.CandidateEmails.Remove(candidate.Email);

			return true;
		}
	}
}
