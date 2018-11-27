using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;

namespace CMS.API.BLL.BLL
{
    class BuildungBLL : IBuildingBLL
    {
        private IRoomRepository _repository = new RoomRepository();

        public bool AddBuilding(BuildingDTO buildingId)
        {
            try
            {
                _repository.AddBuilding(buildingId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteBuilding(int building)
        {
            try
            {
                _repository.DeleteBuilding(building);
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
