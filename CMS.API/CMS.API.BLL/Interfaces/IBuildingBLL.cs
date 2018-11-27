using CMS.BE.DTO;

namespace CMS.API.BLL.Interfaces
{
    interface IBuildingBLL
    {
        bool AddBuilding(BuildingDTO building);
        bool EditBuilding(BuildingDTO building);
        bool DeleteBuilding(int buildingId);
    }
}
