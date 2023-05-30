using AlcoProjectLibrary;
using System.ComponentModel.DataAnnotations;

namespace DrinksService
{
    public class CreateDrinkRequest
    {
        public string Name { get; set; }
        public double Strength { get; set; }
        public ProjectEnums.DrinkCategory Category { get; set; }
        public string Description { get; set; }
    }
}
