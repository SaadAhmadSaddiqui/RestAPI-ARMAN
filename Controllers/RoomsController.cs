using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI_ARMAN.Models;
using RestAPI_ARMAN.Processors;

namespace RestAPI_ARMAN.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {

        public List<Room> rooms = new List<Room>();


        // GET: api/Rooms/Get
        [HttpGet]
        [ActionName("Get")]
        public JsonResult Get()
        {
            return new RoomProcessor().GetRooms();
        }

        // GET: api/Rooms/Get/5
        [HttpGet("{id}", Name = "Get")]
        [ActionName("Get")]
        public JsonResult Get(int id)
        {
            return new RoomProcessor().GetRoomByID(id);
        }

        // POST: api/Rooms/Post
        [HttpPost]
        [ActionName("Post")]
        public JsonResult Post([FromBody] Room room)
        {
            return new RoomProcessor().AddRoom(room.RoomName, room.RoomX, room.RoomY, room.RoomZ);
        }

        //PUT: api/Rooms/PutName/5
        [HttpPut("{id}")]
        [ActionName("PutName")]
        public JsonResult PutName(int id, [FromBody] Room room)
        {
            return new RoomProcessor().UpdateRoomName(id, room.RoomName);
        }

        // PUT: api/Rooms/Put/5
        [HttpPut("{id}")]
        [ActionName("Put")]
        public JsonResult Put(int id, [FromBody] Room room)
        {
            return new RoomProcessor().UpdateRoom(id, room.RoomName, room.RoomX, room.RoomY, room.RoomZ);
        }

        // DELETE: api/ApiWithActions/Delete/5
        [HttpDelete("{id}")]
        [ActionName("Delete")]
        public JsonResult Delete(int id)
        {
            return new RoomProcessor().DeleteRoom(id);
        }
    }
}
