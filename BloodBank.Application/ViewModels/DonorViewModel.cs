namespace BloodBank.Application.ViewModels
{
    public class DonorViewModel
    {
        public DonorViewModel(int id, string firstName, string lastName, DateTime birthDate, double weight)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Weight = weight;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public double Weight { get; private set; }
    }
}
