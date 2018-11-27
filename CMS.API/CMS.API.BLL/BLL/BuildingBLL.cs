using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;

namespace CMS.API.BLL.BLL
{
    public class BuildingBLL : IBuildingBLL
    {
        private IRoomRepository _repository = new RoomRepository();

        public bool AddBuilding(BuildingDTO building)
        {
            try
            {
                _repository.AddBuilding(building);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteBuilding(int buildingId)
        {
            try
            {
                _repository.DeleteBuilding(buildingId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditBuilding(BuildingDTO building)
        {
            try
            {
                _repository.EditBuilding(building);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
