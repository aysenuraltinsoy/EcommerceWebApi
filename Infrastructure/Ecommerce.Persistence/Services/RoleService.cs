using Ecommerce.Application.Abstractions.Services;
using Ecommerce.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Services
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<AppRole> _roleManager;
        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<bool> CreateRole(string name)
        {
            IdentityResult result=await _roleManager.CreateAsync(new() {Id=Guid.NewGuid().ToString(), Name=name });
            return result.Succeeded;
        }

        public async Task<bool> DeleteRole(string Id)
        {
            AppRole appRole=await _roleManager.FindByIdAsync(Id);
            IdentityResult result =await  _roleManager.DeleteAsync(appRole);
            return result.Succeeded;
        }

        public (object, int) GetAllRoles(int page, int size)
        {
            var data = _roleManager.Roles.Skip(page * size).Take(size).Select(r => new { r.Id, r.Name });
            return (data, _roleManager.Roles.Count());
        }

        public async Task<(string id, string name)> GetRoleById(string id)
        {
           string role=await _roleManager.GetRoleIdAsync(new() { Id=id });
            return(id,role);
        }

        public async Task<bool> UpdateRole(string name ,string Id)
        {
			AppRole appRole = await _roleManager.FindByIdAsync(Id);
            appRole.Name = name;
			IdentityResult result = await _roleManager.UpdateAsync(appRole);
            return result.Succeeded;
        }
    }
}
