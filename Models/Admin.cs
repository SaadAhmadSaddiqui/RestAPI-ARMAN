using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI_ARMAN.Models
{
    [JsonObject, Serializable]
    public class Admin
    {
        public int AdminID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string AdminName { get; set; }

        public string AdminEmail { get; set; }

    }
}
