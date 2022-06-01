using ReactAuthAdWith_JWT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactAuthAdWith_JWT.Web.Models
{
    public class AdViewModel
    {
        public Ad Ad { get; set; }
        public bool CanDelete { get; set; }
        public string UserName { get; set; }
    }
}
