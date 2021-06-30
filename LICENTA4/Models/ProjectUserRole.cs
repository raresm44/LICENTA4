using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LICENTA4.Models
{
    public class ProjectUserRole
    {
        public int roleId;

        public ProjectRole role;
        
        public int userId;
        
        public ProjectUser user;
    }
}