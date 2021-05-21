using NewBookModelsApiTests.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBookModelsApiTests
{
    public class UserConstructor
    {
        public Dictionary<string, string> User = new Dictionary<string, string>()
        {
            { "email", $"Jonson{DateTime.Now:ddyyyymmHHmmssffff}@gmail.com" },
            { "first_name", "Ban" },
            { "last_name", "Jonson" },
            { "password", "QWE123qwe!@#" },
            { "phone_number", "1254785852" }
        };
    }
}
