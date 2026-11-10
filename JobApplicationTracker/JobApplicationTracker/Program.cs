using JobApplicationTracker.Data;
using JobApplicationTracker.Models;

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

AppData data = new AppData();

DataSeeder.Seed(data);
                          // linq :))
Console.WriteLine($"Companies: {data.Companies.GetAll().Count()}");
Console.WriteLine($"Recruiters: {data.Recruiters.GetAll().Count()}");
Console.WriteLine($"Jobs: {data.Jobs.GetAll().Count()}");
Console.WriteLine($"Candidates: {data.Candidates.GetAll().Count()}"); 
