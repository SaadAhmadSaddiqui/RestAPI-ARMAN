using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI_ARMAN.Models
{
    [JsonObject, Serializable]
    public class Room
    {
        public int RoomID { get; set; }

        public string RoomName { get; set; }

        public float RoomX { get; set; }

        public float RoomY { get; set; }

        public float RoomZ { get; set; }
    }
}
