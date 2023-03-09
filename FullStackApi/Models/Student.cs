namespace FullStackApi.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }   
        public long Phone { get; set; }
        public string Address { get; set; }
    }
}
