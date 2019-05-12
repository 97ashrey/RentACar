
namespace UI.Views.Models
{
    public interface ICarModelView
    {
        string Brand { get; set; }
        string Model { get; set; }
        int CreatedYear { get; set; }
        double CubicCapacity { get; set; }
        string DriveType { get; set; }
        string ShiftType { get; set; }
        string CarBody { get; set; }
        string FuelType { get; set; }
        string DorCount { get; set; }
    }
}
