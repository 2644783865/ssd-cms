namespace CMS.BE.DTO
{
    public class TaskDTO
    {
        public int taskID { get; set; }
        public string Title { get; set; }
        public string Desacription { get; set; }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
    }
}
