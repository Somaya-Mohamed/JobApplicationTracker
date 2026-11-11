using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;
using JobApplicationTracker.Practice;
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


AppData data = new AppData();

DataSeeder.Seed(data);

////   -----------------------------------------      Test the JobService with Job entities :) ------------------------------------------


//JobService jobService = new JobService(data);

//Console.WriteLine($"Jobs Store Count: {data.JobsById.Count}");

//Job? foundJob = jobService.GetJobById(1);

//Console.WriteLine($"Found Job: {foundJob?.Title}");


//// Test Add
//Job newJob = new Job
//{
//	Id = 7,
//	Title = "Backend Developer",
//	Salary = 15000,
//	Location = "Cairo",
//	IsOpen = true,
//	DatePosted = DateTime.Today,
//	CompanyId = 1,
//	RecruiterId = 1
//};

//Console.WriteLine($"Add Job: {jobService.AddJob(newJob)}");

//Console.WriteLine($"After Add: {data.JobsById.Count}");


//// Test Update
//newJob.Title = "Senior Backend Developer";

//Console.WriteLine($"Update Job: {jobService.UpdateJob(newJob)}");

//Console.WriteLine($"Updated Title: {jobService.GetJobById(7)?.Title}");


//// Test Remove
//Console.WriteLine($"Remove Job: {jobService.RemoveJobById(7)}");

//Console.WriteLine($"After Remove: {data.JobsById.Count}");

//Console.WriteLine($"Find Removed Job: {jobService.GetJobById(7) == null}");


//// Test Pending Company
//Job pendingCompanyJob = new Job
//{
//	Id = 8,
//	Title = "Junior Developer",
//	Salary = 8000,
//	Location = "Mansoura",
//	IsOpen = true,
//	DatePosted = DateTime.Today,
//	CompanyId = 3,
//	RecruiterId = 1
//};

//Console.WriteLine($"Add Job To Pending Company: {jobService.AddJob(pendingCompanyJob)}");

////   -----------------------------------------      Test the companyService  :) ------------------------------------------


//CompanyService companyService = new CompanyService(data);

//// 1. Get All Companies
//Console.WriteLine("All Companies:");

//foreach (var company in companyService.GetAllCompanies())
//{
//	Console.WriteLine($"{company.Id} - {company.Name} - {company.Status}");
//}

//// 2. Add Company
//Company newCompany = new Company
//{
//	Id = 4,
//	Name = "Future Tech",
//	Industry = "Software",
//	City = "Tanta",
//	Status = CompanyStatus.Pending
//};

//Console.WriteLine($"Add: {companyService.AddCompany(newCompany)}");

//// 3. Get By Id
//Company? foundCompany = companyService.GetCompanyById(4);

//Console.WriteLine($"Found: {foundCompany?.Name}");

//// 4. Update Company
//Company updatedCompany = new Company
//{
//	Id = 4,
//	Name = "Future Technology",
//	Industry = "IT",
//	City = "Tanta",
//	Status = CompanyStatus.Pending
//};

//Console.WriteLine($"Update: {companyService.UpdateCompany(updatedCompany)}");

//// 5. Change Status
//Console.WriteLine(
//	$"Change Status: {companyService.ChangeCompanyStatus(4, CompanyStatus.Approved)}"
//);

//// 6. Get Companies By Status
//Console.WriteLine("Approved Companies:");

//foreach (var company in companyService.GetCompaniesByStatus(CompanyStatus.Approved))
//{
//	Console.WriteLine(company.Name);
//}

//// 7. Remove Company
//Console.WriteLine($"Remove: {companyService.RemoveCompanyById(4)}");

//// 8. Check After Remove
//Console.WriteLine($"Find After Remove: {companyService.GetCompanyById(4) == null}");


//////   -----------------------------------------      Test the RecruiterService :) ------------------------------------------


//RecruiterService recruiterService = new RecruiterService(data);

//// 1. Get All
//foreach (var recruiter in recruiterService.GetAllRecruiters())
//{
//	Console.WriteLine(
//		$"{recruiter.Id} - {recruiter.Name} - Company: {recruiter.CompanyId}"
//	);
//}

//// 2. Add
//Recruiter newRecruiter = new Recruiter
//{
//	Id = 4,
//	Name = "Sara Ahmed",
//	Email = "sara@futuretech.com",
//	CompanyId = 1
//};

//Console.WriteLine(
//	$"Add: {recruiterService.AddRecruiter(newRecruiter)}"
//);

//// 3. Invalid Company
//Recruiter invalidRecruiter = new Recruiter
//{
//	Id = 5,
//	Name = "Ali Mohamed",
//	Email = "ali@futuretech.com",
//	CompanyId = 99
//};

//Console.WriteLine(
//	$"Add To Missing Company: {recruiterService.AddRecruiter(invalidRecruiter)}"
//);

//// 4. Get By Id
//Console.WriteLine(
//	$"Found: {recruiterService.GetRecruiterById(4)?.Name}"
//);

//// 5. Update
//Recruiter updatedRecruiter = new Recruiter
//{
//	Id = 4,
//	Name = "Sara Mohamed",
//	Email = "sara.mohamed@futuretech.com",
//	CompanyId = 2
//};

//Console.WriteLine(
//	$"Update: {recruiterService.UpdateRecruiter(updatedRecruiter)}"
//);

//// 6. Remove
//Console.WriteLine(
//	$"Remove: {recruiterService.RemoveRecruiterById(4)}"
//);


//////   -----------------------------------------      Test the CandidateService :) ------------------------------------------

//CandidateService candidateService = new CandidateService(data);

//// 1. Check Seeded Data
//Console.WriteLine(
//	$"Candidates Count: {data.Candidates.GetAll().Count()}"
//);

//Console.WriteLine(
//	$"Emails Count: {data.CandidateEmails.Count}"
//);

//// 2. Add New Candidate
//Candidate newCandidate = new Candidate
//{
//	Id = 6,
//	FullName = "Sara Ahmed",
//	Email = "sara@gmail.com",
//	PhoneNumber = "01000000000",
//	YearsOfExperience = 1
//};

//Console.WriteLine(
//	$"Add: {candidateService.AddCandidate(newCandidate)}"
//);

//// 3. Duplicate Email With Different Case
//Candidate duplicateCandidate = new Candidate
//{
//	Id = 7,
//	FullName = "Sara Mohamed",
//	Email = "SARA@GMAIL.COM",
//	PhoneNumber = "01111111111",
//	YearsOfExperience = 2
//};

//Console.WriteLine(
//	$"Duplicate Email: {candidateService.AddCandidate(duplicateCandidate)}"
//);

//// 4. Update Email
//Candidate updatedCandidate = new Candidate
//{
//	Id = 6,
//	FullName = "Sara Ahmed",
//	Email = "sara.ahmed@gmail.com",
//	PhoneNumber = "01000000000",
//	YearsOfExperience = 1
//};

//Console.WriteLine(
//	$"Update: {candidateService.UpdateCandidate(updatedCandidate)}"
//);

//// 5. Check Old And New Emails
//Console.WriteLine(
//	$"Old Email Exists: {data.CandidateEmails.Contains("sara@gmail.com")}"
//);

//Console.WriteLine(
//	$"New Email Exists: {data.CandidateEmails.Contains("sara.ahmed@gmail.com")}"
//);

//// 6. Remove Candidate
//Console.WriteLine(
//	$"Remove: {candidateService.RemoveCandidateById(6)}"
//);

//Console.WriteLine(
//	$"Email Exists After Remove: {data.CandidateEmails.Contains("sara.ahmed@gmail.com")}"
//);

//////   -----------------------------------------      Test H1 — Apply for Job :) ------------------------------------------

//data.AppliedJobs.Add((5, 1));
//data.AppliedJobs.Add((6, 1));
//data.AppliedJobs.Add((5, 2));

//Console.WriteLine(data.AppliedJobs.Contains((5, 1)));
//Console.WriteLine(data.AppliedJobs.Contains((5, 2)));
//Console.WriteLine(data.AppliedJobs.Contains((7, 1)));


//ApplicationService applicationService = new ApplicationService(data);

//// 1. Best pract
//Console.WriteLine(
//	applicationService.ApplyForJob(1, 1)
//);

//// 2. Same person Same job
//Console.WriteLine(
//	applicationService.ApplyForJob(1, 1)
//);

//// 3. Same person Diffrent job
//Console.WriteLine(
//	applicationService.ApplyForJob(1, 2)
//);

//// 4. Not Valid Candidate 
//Console.WriteLine(
//	applicationService.ApplyForJob(99, 1)
//);

//// 5. Not valid Job 
//Console.WriteLine(
//	applicationService.ApplyForJob(1, 99)
//);

//////   -----------------------------------------      Test practice :) ------------------------------------------

//collections test
CollectionsPractice.Run(data);

// Generic Method practice:
Job? job = GenericMethods.FindById(
	data.Jobs.GetAll(),
	1
);

if (job != null)
{
	Console.WriteLine($"Generic Method Result: {job.Title}");
}