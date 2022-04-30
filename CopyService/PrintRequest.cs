namespace CopyService
{
    public class PrintRequest
    {
        public FileFormat Format { get; set; }
        
        public string? File { get; set; }
        
        public PrintColor Color { get; set; }
    }
}