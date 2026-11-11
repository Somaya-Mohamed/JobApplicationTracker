using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplicationTracker.Services
{
	public class CompanyService
	{
		private readonly AppData _data;

		public CompanyService(AppData data)
		{
			_data = data;
		}

		public bool AddCompany(Company company)
		{
			if(company == null || string.IsNullOrWhiteSpace(company.Name))
				return false;

			return _data.Companies.Add(company);
		}

		public Company? GetCompanyById(int id)
		{
			return _data.Companies.GetById(id);
		}

		public IEnumerable<Company> GetAllCompanies()
		{
			return _data.Companies.GetAll();
		}

		public bool UpdateCompany(Company company)
		{
			if(company == null || string.IsNullOrWhiteSpace(company.Name))
				return false;

			return _data.Companies.Update(company);
		}

		public bool RemoveCompanyById(int id)
		{
			return _data.Companies.RemoveById(id);
		}

		public bool ChangeCompanyStatus(int companyId, CompanyStatus newStatus)
		{
			Company? company = _data.Companies.GetById(companyId);

			if (company == null)
				return false;

			company.Status = newStatus;
			return true;
		}

		public IEnumerable<Company> GetCompaniesByStatus(CompanyStatus status)
		{
			foreach (var company in _data.Companies.GetAll())
			{
				if (company.Status == status)
				{
					yield return company;
				}
			}
		}


	}
}
