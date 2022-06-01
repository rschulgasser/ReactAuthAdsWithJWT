using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReactAuthAdWith_JWT.Data
{
    public class Ad
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }

      
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
