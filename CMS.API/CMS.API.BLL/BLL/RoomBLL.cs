using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;

namespace CMS.API.BLL.BLL
{
    class RoomBLL : IRoomBLL
    {
        private IRoomRepository _repository = new RoomRepository();

        public bool AddRoom(RoomDTO roomId)
        {
            try
            {
                _repository.AddRoom(roomId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteRoom(int room)
        {
            try
            {
                _repository.DeleteRoom(room);
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
