namespace CopyService
{
    public class BWPrinter : Printer
    {
        protected override bool CanPrint(PrintRequest request)
        {
            if (request.Color == PrintColor.BlackAndWhite)
                return true;

            return false;
        }
    }
}