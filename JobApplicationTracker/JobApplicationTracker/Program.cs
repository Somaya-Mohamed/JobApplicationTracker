using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using JobApplicationTracker.Services;

////Console.WriteLine("بسم الله");
//// -----------------------------------------      Test the DataStore with Job entities :) ------------------------------------------
//DataStore<Job> jobs = new DataStore<Job>();
//Job job1 = new Job
//{
//	Id = 1,
//	Title = "Software Engineer",
//	CompanyId = 1,
//	Location = "Cairo",
//	Salary = 10000
//};

//Job job2 = new Job
//{
//	Id = 2,
//	Title = "Data Scientist",
//	CompanyId = 2,
//	Location = "Giza",
//	Salary = 8000
//};

//Console.WriteLine(jobs.Add(job1));
//Console.WriteLine(jobs.Add(job2));

//Console.WriteLine(jobs.Add(
//	new Job
//	{
//		Id = 1,
//		Title = "Duplicate Job",
//		CompanyId = 1,
//		Location = "Cairo",
//		Salary = 12000

//	}
//	));

//Job? foundJob = jobs.GetById(1);
//Console.WriteLine(foundJob?.Title);

//Job updatedJob = new Job
//{
//	Id = 1,
//	Title = "Software Engineer Updated",
//	CompanyId = 1,
//	Location = "Cairo",
//	Salary = 12000
//};
//Console.WriteLine(jobs.Update(updatedJob));

//foreach (var item in jobs.GetAll())
//{
//	Console.WriteLine(item.Title);
//}

//Console.WriteLine(jobs.RemoveById(2));

//Console.WriteLine(jobs.GetById(2) == null);

//AppData appData = new AppData();
//appData.Companies.Add(new Company { Id = 1, Name = "TechCorp" });


///               Test SeedData
//AppData data = new AppData();

//DataSeeder.Seed(data);
//                          // linq :))
//Console.WriteLine($"Companies: {data.Companies.GetAll().Count()}");
//Console.WriteLine($"Recruiters: {data.Recruiters.GetAll().Count()}");
//Console.WriteLine($"Jobs: {data.Jobs.GetAll().Count()}");
//Console.WriteLine($"Candidates: {data.Candidates.GetAll().Count()}"); 

//   -----------------------------------------      Test the JobService with Job entities :) ------------------------------------------

AppData data = new AppData();

DataSeeder.Seed(data);

JobService jobService = new JobService(data);

Console.WriteLine($"Jobs Store Count: {data.JobsById.Count}");

Job? foundJob = jobService.GetJobById(1);

Console.WriteLine($"Found Job: {foundJob?.Title}");


// Test Add
Job newJob = new Job
{
	Id = 7,
	Title = "Backend Developer",
	Salary = 15000,
	Location = "Cairo",
	IsOpen = true,
	DatePosted = DateTime.Today,
	CompanyId = 1,
	RecruiterId = 1
};

Console.WriteLine($"Add Job: {jobService.AddJob(newJob)}");

Console.WriteLine($"After Add: {data.JobsById.Count}");


// Test Update
newJob.Title = "Senior Backend Developer";

Console.WriteLine($"Update Job: {jobService.UpdateJob(newJob)}");

Console.WriteLine($"Updated Title: {jobService.GetJobById(7)?.Title}");


// Test Remove
Console.WriteLine($"Remove Job: {jobService.RemoveJobById(7)}");

Console.WriteLine($"After Remove: {data.JobsById.Count}");

Console.WriteLine($"Find Removed Job: {jobService.GetJobById(7) == null}");


// Test Pending Company
Job pendingCompanyJob = new Job
{
	Id = 8,
	Title = "Junior Developer",
	Salary = 8000,
	Location = "Mansoura",
	IsOpen = true,
	DatePosted = DateTime.Today,
	CompanyId = 3,
	RecruiterId = 1
};

Console.WriteLine($"Add Job To Pending Company: {jobService.AddJob(pendingCompanyJob)}");

