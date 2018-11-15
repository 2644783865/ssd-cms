namespace CMS.API.BLL.Interfaces.Conference
{
    public interface IConferenceBLL
    {
        object GetConferences();
        bool AddConference(DAL.Conference conference);
    }
}
