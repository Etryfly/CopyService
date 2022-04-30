namespace CopyService
{
    public class ColorPrinter : Printer
    {
        protected override bool CanPrint(PrintRequest request)
        {
            if (request.Color == PrintColor.Color)
                return true;

            return false;
        }
    }
}