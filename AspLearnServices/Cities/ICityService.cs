using AspLearn.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspLearn.Services.Cities {
    public interface ICityService {
        Task<List<City>> GetAllCitiesAsync();

        Task<City> GetCityByNetIdAsync(Guid netId);
    }
}
