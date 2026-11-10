using JobApplicationTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplicationTracker.Models
{
	public class Candidate :IEntity
	{
		public int Id { get; set; }
		public string FullName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string? PhoneNumber { get; set; }
		public int YearsOfExperience { get; set; }
	}
}
