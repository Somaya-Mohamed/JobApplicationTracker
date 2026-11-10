using JobApplicationTracker.Enums;
using JobApplicationTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplicationTracker.Models
{
	public class Application :IEntity
	{
		public int Id { get; set; }
		public int JobId { get; set; }
		public int CandidateId { get; set; }
		public DateTime ApplicationDate { get; set; }
		public ApplicationStatus Status { get; set; } = ApplicationStatus.Submitted;
	}
}
