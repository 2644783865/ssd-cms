using CMS.BE.DTO;

namespace CMS.API.BLL.Interfaces
{
    interface IRoomBLL
    {
        bool AddRoom(RoomDTO room);
        bool EditRoom(RoomDTO room);
        bool DeleteRoom(int roomId);
    }
}
