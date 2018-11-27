using CMS.BE.DTO;

namespace CMS.API.BLL.Interfaces
{
    interface IRoomBLL
    {
        bool AddRoom(RoomDTO roomId);
        bool EditRoom(RoomDTO room);
        bool DeleteRoom(int room);
    }
}
