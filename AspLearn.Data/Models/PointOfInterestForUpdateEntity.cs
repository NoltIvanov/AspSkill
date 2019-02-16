using System.ComponentModel.DataAnnotations;

namespace AspLearn.Data.Models {
    public class PointOfInterestForUpdateEntity {
        [Required]
        [MaxLength(5)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
