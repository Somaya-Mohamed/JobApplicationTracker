using JobApplicationTracker.Enums;
using JobApplicationTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplicationTracker.Models
{
	public class Company :IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string? Industry { get; set; }
		public string? City { get; set; }
		public CompanyStatus Status { get; set; } = CompanyStatus.Pending;
	}
}
