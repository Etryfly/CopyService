using System;
using System.Threading.Tasks;

namespace CopyService
{
    public abstract class Printer
    {
        private FileFormat _formatState;
        private Printer? _next;
        private readonly IPhotoService _photoService = new PhotoServiceProxy();
        
        public async Task PrintAsync(PrintRequest request)
        {
            if (CanPrint(request))
            {
                await ApplySettings(request.Format);
                if (request.Format == FileFormat.Photo && request.File is null)
                {
                    request.File = _photoService.TakePhoto();
                }  else if (request.File is null)
                {
                    Console.WriteLine($"{GetType()} skip due to empty document");
                    return;
                }
                Console.Out.WriteLine($"{GetType()} is printing {request.File} in {request.Format} format");
                await Task.Delay(1000);
                return;
            }

            if (_next is null)
            {
                Console.WriteLine($"Can't print {request.File} in {request.Format} format");
                return;
            }

            await _next.PrintAsync(request);
        }

        public Task ApplySettings(FileFormat format)
        {
            if (format == _formatState)
                return Task.CompletedTask;

            Console.WriteLine($"Apply {format.ToString()} format for {GetType()}");
            _formatState = format;
            return Task.Delay(500);
        }

        protected abstract bool CanPrint(PrintRequest request);

        public void SetNext(Printer printer)
        {
            _next = printer;
        }
    }
}