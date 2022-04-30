using System;

namespace CopyService
{
    public class PhotoService : IPhotoService
    {
        public string TakePhoto()
        {
            return Guid.NewGuid().ToString();
        }
    }
}