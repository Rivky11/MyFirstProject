using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{


    public class PermissionRepository : IPermissionRepository
    {
        private readonly IContext _context;
        public PermissionRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Permission> AddAsync(int id ,string name,string description)
        {
            Permission per = Add(id,name,description);
            await _context.SaveChangesAsync();
            return per;
        }

        public Permission Add(int id, string name, string description)
        {
            Permission p = new Permission { Id = id, Name = name, Description = description };
            _context.Permissions.Add(p);
            return p;
        }
        public async Task DeleteAsync(int id)
        {
            Delete(id);
            await _context.SaveChangesAsync();
        }
        public void Delete(int id)
        {
            _context.Permissions.Remove(_context.Permissions.Find(id));
        }

        public List<Permission> GetAll()
        {
            return _context.Permissions.ToList();
        }

        public Permission GetById(int id)
        {
            return _context.Permissions.Find(id);
        }
        public async Task<Permission> UpdateAsync(Permission permission)
        {
            Permission per = Update(permission);
            await _context.SaveChangesAsync();
            return per;
        }

        public Permission Update(Permission Permission)
        {
            var p1=_context.Permissions.Find(Permission.Id);
            p1.Name = Permission.Name;
            p1.Description = Permission.Description;
            return p1;
        }
    }
}
