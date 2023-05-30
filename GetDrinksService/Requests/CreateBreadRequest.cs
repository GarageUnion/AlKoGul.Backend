using BreadProjectLibrary;
using System.ComponentModel.DataAnnotations;

namespace BreadService
{
    public class CreateBreadRequest
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public ProjectEnums.BreadCategory Category { get; set; }
        public string Description { get; set; }
    }
}
