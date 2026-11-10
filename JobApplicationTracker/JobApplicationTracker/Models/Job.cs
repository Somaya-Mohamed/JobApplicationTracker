using JobApplicationTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplicationTracker.Models
{
	public class Job :IEntity
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string? Description { get; set; }
		public string? Location { get; set; }
		public decimal Salary { get; set; }
		public bool IsOpen { get; set; } = true;
		public DateTime DatePosted { get; set; }
		public int CompanyId { get; set; }
		public int RecruiterId { get; set; }
	}
}
