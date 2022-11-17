using Microsoft.EntityFrameworkCore;

namespace Core.Entities.Views
{
    [Keyless]
    public class BatchFile
    {
        public string? BatchKey { get; set; }
        public DateTime BatchDate { get; set; }
    }
}
