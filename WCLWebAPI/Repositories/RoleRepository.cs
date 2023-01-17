using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.Interfaces;
using WCLWebAPI.Server.ViewModels.System.Roles;

namespace WCLWebAPI.Server.Repositories
{
    public class RoleRepository : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        public RoleRepository(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<List<RoleVM>> GetAll()
        {
            var roles = await _mapper.ProjectTo<RoleVM>(_roleManager.Roles).ToListAsync();
            return roles;
        }
    }
}
