using BreadProjectLibrary;

namespace BreadService
{
    public class UpdateBreadRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ProjectEnums.BreadCategory Category { get; set; }
        public string Description { get; set; }
    }
}
