using QL.Infra.Models.Employee;
using QL.Infra.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Repository.InfraRepos
{
    public class EmployeeWFHRequest : IEmployeeWFHRequest,IDisposable
    {
        public WFHRequests AddWFHRequestsByEmployee(string EmployeeID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QLEmployee> GetAllEmployees()
        {
            List<QLEmployee> _qlemployees = new()
            { 
                new() { Email="mkasarapu@qentelli.com", EmployeeId= "QE1901", EmployeeName="Madhu"  },
                new() { Email="raju@qentelli.com", EmployeeId= "QE1902", EmployeeName="Raju"  },
                new() { Email="rani@qentelli.com", EmployeeId= "QE1903", EmployeeName="Rani"  }
            };
            return _qlemployees;
        }
        public IEnumerable<WFHRequests> GetAllWFHRequests()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WFHRequests> GetWFHRequestsByEmployee(string EmployeeID)
        {
            throw new NotImplementedException();
        }

        public WFHRequests UpdateWFHRequestsByEmployee(string EmployeeID)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                this.Dispose();
                disposing = true;
            }

        }
    }
}
