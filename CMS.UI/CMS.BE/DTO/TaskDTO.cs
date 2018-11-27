namespace CMS.BE.DTO
{
    public class TaskDTO
    {
        public int TaskID { get; set; }
        public int ConferenceId { get; set; }
        public int EmployeeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string ManagerId { get; set; }
    }
}
