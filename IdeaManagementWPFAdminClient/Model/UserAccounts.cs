using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaManagementWPFAdminClient.Model
{
    class UserAccounts
    {
        public int fld_id { get; set; }

        public string fld_username { get; set; }

        public string fld_password { get; set; }

        public int? fld_loginType { get; set; }
    }
}
