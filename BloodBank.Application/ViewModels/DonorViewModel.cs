namespace BloodBank.Application.ViewModels;

public class DonorViewModel
{
    public DonorViewModel(int id, string fullName, DateTime birthDate, string gender, double weight, string bloodType, string rHFactor)
    {
        Id = id;
        FullName = fullName;
        BirthDate = birthDate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RHFactor = rHFactor;
    }

    public int Id { get; private set; }
    public string FullName { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Gender { get; private set; }
    public double Weight { get; private set; }
    public string BloodType { get; private set; }
    public string RHFactor { get; private set; }

}
