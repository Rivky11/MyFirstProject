using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly IContext _context;

        public ClaimRepository(IContext context)
        {
            _context = context;
        }

        public List<Claim> GetAll()
        {
            return _context.Claims.ToList();
        }

        public Claim GetById(int id)
        {
            return _context.Claims.Find(id);
        }

        public async Task<Claim> AddAsync(int id, int roleId, int permissionId, EPolicy policy)
        {
            Claim claim1 = Add(id,roleId,permissionId,policy);
            await _context.SaveChangesAsync();
            return claim1;
        }
        public Claim Add(int id, int roleId, int permissionId, EPolicy policy)
        {
            Claim c = new Claim();
            c.Id = id;
            c.RoleId = roleId;
            c.PermissionId = permissionId;
            c.Policy = policy;
            _context.Claims.Add(c);
            return c;
        }
        public async Task<Claim> UpdateAsync(Claim claim)
        {
            Claim claim1 = Update(claim);
            await _context.SaveChangesAsync();
            return claim1;
        }
        public Claim Update(Claim claim)
        {
            var c = _context.Claims.Find(claim.Id);
            c.Id = claim.Id;
            c.PermissionId = claim.PermissionId;
            c.Policy = claim.Policy;
            c.RoleId = claim.RoleId;
            return c;
        }
        public async Task DeleteAsync(int id)
        {
            Delete(id);
           await _context.SaveChangesAsync();
        }
        public void Delete(int id)
        {
            _context.Claims.Remove(_context.Claims.Find(id));
        }

    }
}
