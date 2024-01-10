namespace dmitry_efimov_kt_31_20.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int RatingsId { get; set; }
        public bool TestId { get; set; }
        public Ratings Ratings { get; set; }
        public Test Test { get; set; }
    }
}
