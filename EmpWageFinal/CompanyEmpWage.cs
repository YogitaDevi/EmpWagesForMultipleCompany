using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpWageFinal
{
    
       public interface IComputeEmpWage
       {
        public void addcompanyEmpWage(string company, int empRatePerHour, int numOfWorkingDays, int maxHoursPerMonth);
        public void computeEmpWage();
        public int getTotalWage(string company);
       }

       public class CompanyEmpWage
       {
        public string company;
        public int empRatePerHour;
        public int numOfWorkingDays;
        public int maxHoursPerMonth;
        public int totalEmpWage;
        public CompanyEmpWage(string company, int empRatePerHour, int numOfWorkingDays, int maxHoursPerMonth)
        {
            this.company = company;
            this.empRatePerHour = empRatePerHour;
            this.numOfWorkingDays = numOfWorkingDays;
            this.maxHoursPerMonth = maxHoursPerMonth;
            this.totalEmpWage = 0;
        }
        public void setTotalEmpWage(int totalEmpWage)
        {
            this.totalEmpWage = totalEmpWage;
        }
        public string toString()
        {
            return "Total Emp wage for company : " + this.company + " is: " + this.totalEmpWage;
        }
       }
       public class EmpWageBuilder: IComputeEmpWage
       {
        public const int isPartTime = 1;
        public const int isFullTime = 2;
        private LinkedList<CompanyEmpWage> companyEmpWagesList;
        private Dictionary<string, CompanyEmpWage> companyToEmpWageMap;
        public EmpWageBuilder()
        {
            this.companyEmpWagesList = new LinkedList<CompanyEmpWage>();
            this.companyToEmpWageMap = new Dictionary<string, CompanyEmpWage>();
        }
        public void addCompanyEmpWage(string company, int empRatePerHour, int numOfWorkingDays, int maxHoursPerMonth)
        {
            CompanyEmpWage companyEmpWage = new CompanyEmpWage(company, empRatePerHour, numOfWorkingDays, maxHoursPerMonth);
            this.companyEmpWagesList.AddLast(companyEmpWage);
            this.companyToEmpWageMap.Add(company, companyEmpWage);
        }
        public void ComputeEmpWage()
        {
            foreach (CompanyEmpWage companyEmpWage in this.companyEmpWagesList)
            {
                companyEmpWage.setTotalEmpWage(this.ComputeEmpWage(companyEmpWage));
                Console.WriteLine(companyEmpWage.toString());
            }
        }

        private int ComputeEmpWage(CompanyEmpWage companyEmpWage);

          public int getTotalWage(string company)
          {

            return this.companyToEmpWageMap[company].totalEmpWage;
          }

          public void addcompanyEmpWage(string company, int empRatePerHour, int numOfWorkingDays, int maxHoursPerMonth)
          {
                throw new NotImplementedException();

          }

        public void computeEmpWage()
        {
            throw new NotImplementedException();
        }
    }
       class Program
       {
        static void Main(string[] args)
        {

            EmpWageBuilder empWageBuilder = new EmpWageBuilder();
            empWageBuilder.addCompanyEmpWage("DMart", 20, 2, 10);
            empWageBuilder.addCompanyEmpWage("Reliance", 10, 4, 20);
            empWageBuilder.ComputeEmpWage();
            Console.WriteLine("Total wage for DMart company : " + empWageBuilder.getTotalWage("DMart"));
        }
       }

   
}
