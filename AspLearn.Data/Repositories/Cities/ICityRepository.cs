using AspLearn.Data.Entities;
using System;
using System.Collections.Generic;

namespace AspLearn.Data.Repositories.Cities {
    public interface ICityRepository  {
        List<City> GetAll();

        City GetByNetId(Guid netId);

        City Add(City city);
    }
}
