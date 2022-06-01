using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ReactAuthAdWith_JWT.Data
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
     
        public List<Ad> Ads { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}
