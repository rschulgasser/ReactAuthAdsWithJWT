﻿using ReactAuthAdWith_JWT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactAuthAdWith_JWT.Web.Models
{
    public class SignupViewModel : User
    {
        public string Password { get; set; }
    }
}
