using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myproject.repositories.Entities
{
   public enum EPolicy { Allow,Deny}
   public class Claims
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public EPolicy Policy { get; set; }
        public override string ToString()
        {
            return $"Claims: Id = {Id}, RoleId = {RoleId},PermissionId= {PermissionId},Policy={Policy}";
        }

    }
}
