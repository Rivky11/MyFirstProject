using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{

    public class RoleRepository : IRoleRepository
    {
        private readonly IContext _context;

        public RoleRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Role> AddAsync(int id, string name, string description)
        {
            Role role=Add(id, name, description);
            await _context.SaveChangesAsync();
            return role;
        }
        public Role Add(int id, string name, string description)
        {
            Role role = new Role() { Id = id, Name = name, Description = description };
            _context.Roles.Add(role);
            return role;
        }
        public async Task DeleteAsync(int id)
        {
            Delete(id);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            _context.Roles.Remove(GetById(id));
        }

        public List<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Role GetById(int id)
        {
            return _context.Roles.Find(id);
        }
        public async Task<Role> UpdateAsync(Role role)
        {
            Role role1 = Update(role);
            await _context.SaveChangesAsync();
            return role;
        }


        public Role Update(Role role)
        {
            Role role1 = _context.Roles.Find(role.Id);
            role1.Name = role.Name;
            role1.Description = role.Description;
            return role1;
        }

    }
}
