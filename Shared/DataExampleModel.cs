using System.ComponentModel.DataAnnotations;

namespace Shared
{
    public class DataExampleModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
