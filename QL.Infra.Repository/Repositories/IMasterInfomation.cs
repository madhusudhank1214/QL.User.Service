using QL.Infra.Models.Dto;
using QL.Infra.Models.Employee;
using QL.Infra.Models.InnovateIdea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Infra.Repository.Repositories
{
    public interface IMasterInfomation
    {
        Task<IEnumerable<MasterDto>> GetAppName();
        Task<IEnumerable<MasterDto>> GetRequestType();
        Task<IEnumerable<MasterDto>> GetStatus();

        Task<IEnumerable<CardsDto>> GetCardsByEmployeeId(string employeeId);

        Task<bool> SaveIdeaIcons(IdeaIcons ideaIcon);
        Task<bool> UpdateIdeaIcons(IdeaIcons ideaIcon);
        Task<IEnumerable<IconsDto>> GetIdeaIcons();
    }
}
