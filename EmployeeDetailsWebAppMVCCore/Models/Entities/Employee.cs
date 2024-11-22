namespace EmployeeDetailsWebAppMVCCore.Models.Entities
{
    public class Employee
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public long salary { get; set; }
        public  string eMail { get; set; }
        public DateTime joiningDate { get; set; }
        public string project { get; set; }
    }
}
