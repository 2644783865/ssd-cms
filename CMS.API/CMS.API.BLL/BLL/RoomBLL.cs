using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;

namespace CMS.API.BLL.BLL
{
    public class RoomBLL : IRoomBLL
    {
        private IRoomRepository _repository = new RoomRepository();

        public bool AddRoom(RoomDTO room)
        {
            try
            {
                _repository.AddRoom(room);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteRoom(int roomId)
        {
            try
            {
                _repository.DeleteRoom(roomId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditRoom(RoomDTO room)
        {
            try
            {
                _repository.EditRoom(room);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
