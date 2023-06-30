using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class RequesterBackendRef
    {
        [Required]
        public string? InstanceId { get; set; }
        [Required]
        public string? ReferenceId { get; set; }
        [Required]
        public string? AccessKey { get; set; }
    }
}
