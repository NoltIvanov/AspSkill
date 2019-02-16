using AspLearn.Data.Entities;
using System.Collections.Generic;

namespace AspLearn.Data.Entities {
    public class City : EntityBase {

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfPointsOfInterest { get => PointsOfInterest.Count; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public City() {
            PointsOfInterest = new HashSet<PointOfInterest>();
        }

        public ICollection<PointOfInterest> PointsOfInterest { get; set; }
    }
}
