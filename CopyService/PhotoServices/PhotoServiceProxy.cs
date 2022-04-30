namespace CopyService
{
    public class PhotoServiceProxy : IPhotoService
    {
        private IPhotoService? _photoService;

        public PhotoServiceProxy()
        {
            _photoService = null;
        }

        public string TakePhoto()
        {
            if (_photoService is null)
            {
                _photoService = new PhotoService();
            }

            return _photoService.TakePhoto();
        }
    }
}