﻿using BreadProjectLibrary;
namespace BreadService
{
    public interface IPicturesManager
    {
        Task<bool> PostPicture(Picture picture);
        Task<bool> DeletePicture(int id);
        Task<Picture> GetPicture(int id);

    }
}
