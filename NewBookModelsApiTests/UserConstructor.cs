using System;
using System.Collections.Generic;

namespace NewBookModelsApiTests
{
    public class UserConstructor
    {
        public Dictionary<string, string> User = new()
        {
            { "email", $"Jonson{DateTime.Now:ddyyyymmHHmmssffff}@gmail.com" },
            { "first_name", "Ban" },
            { "last_name", "Jonson" },
            { "password", "QWE123qwe!@#" },
            { "phone_number", "1254785852" }
        };
    }
}
