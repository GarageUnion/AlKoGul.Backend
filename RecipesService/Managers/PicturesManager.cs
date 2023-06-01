namespace PiesService
{
    public class PicturesManager : IPicturesManager
    {
        private readonly DataContext _dbContext;
        public PicturesManager(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> DeletePicture(int id)
        {
            if (File.Exists("Images/" + id))
            {
                File.Delete("Images/" + id);
                return true;
            }
            return false;
        }

        public async Task<Picture> GetPicture(int id)
        {
            if (File.Exists("Images/" + id))
            {
                string data = File.ReadAllText("Images/" + id);
                Picture picture = new Picture()
                {
                    Id = id,
                    DataBase64 = data
                };
                return picture;
            }
            else return null;
        }

        public async Task<bool> PostPicture(Picture picture)
        {
            if (_dbContext.Recipes.FirstOrDefault(x => x.Id == picture.Id) != null)
            {
                await File.WriteAllTextAsync("Images/" + picture.Id, picture.DataBase64);
                return true;
            }
            else return false;
        }
    }
}