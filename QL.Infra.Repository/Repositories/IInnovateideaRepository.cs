using QL.Infra.Models.Dto;
using QL.Infra.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Repository.Repositories
{
    public interface IInnovateideaRepository
    {
        Task<IEnumerable<QLIdeaTrackerDto>> GetAllQLInnovativeIdeas();
        Task<IEnumerable<QLIdeaTrackerDto>> GetQLIdeasByEmployee(string employeeId);
        Task<IEnumerable<QLIdeaTrackerDto>> GetQLIdeasByEmployeeAndRole(string employeeId, string roleId);
        Task<IEnumerable<QLIdeaDetailsDto>> GetQLIdeaDetails();
        Task<bool> SaveIdeaTracker(IdeaTracker ideaTracker);
    }
}
