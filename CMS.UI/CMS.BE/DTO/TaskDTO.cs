namespace CMS.BE.DTO
{
    public class TaskDTO
    {
        public int TaskID { get; set; }
        public string ConferenceId { get; set; }
        public string EmployeeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string ManagerId { get; set; }
    }
}
