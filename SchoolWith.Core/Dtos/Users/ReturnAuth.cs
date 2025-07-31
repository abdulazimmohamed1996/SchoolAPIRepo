using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Dtos.Users
{
    public class ReturnAuth
    {
        public string? Id { get; set; }
        public string? Massage { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Name { get; set; }
        public bool IsAuth { get; set; }
        public string? Token { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public List<string>? Permissions { get; set; } = new List<string>();
    }
}
