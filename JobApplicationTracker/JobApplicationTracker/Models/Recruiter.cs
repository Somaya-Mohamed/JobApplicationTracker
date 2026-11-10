using JobApplicationTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplicationTracker.Models
{
	public class Recruiter :IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;	
		public int CompanyId { get; set; }
	}
}
