namespace CraftBreadService
{
    public class CreateBreadRequest
    {
        public string Name { get; set; }
        public string NecessaryProducts { get; set; }
        public bool IsMachineRequired { get; set; }
        public string Description { get; set; }
    }
}
