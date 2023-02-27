using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Abstractions.Services
{
    public interface IRoleService
    {
        //This method returns bool results because the Name property is unique in the Identity library
        Task<bool> CreateRole(string name);
        Task<bool> DeleteRole(string id);
        Task<bool> UpdateRole(string name,string Id);
        (object,int) GetAllRoles(int page, int size); 
        Task<(string id, string name)> GetRoleById(string id); //tuple
    }
}
