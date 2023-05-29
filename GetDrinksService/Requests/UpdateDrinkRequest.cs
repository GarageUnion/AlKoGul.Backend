using AlcoProjectLibrary;

namespace DrinksService
{
    public class UpdateDrinkRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public ProjectEnums.DrinkCategory Category { get; set; }
        public string Description { get; set; }
    }
}
