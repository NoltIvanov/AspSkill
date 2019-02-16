using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspLearn.Data.Entities;
using AspLearn.Data.Repositories.Cities;
using AspLearn.Data.TransactionUnits;
using AspLearn.Data.TransactionUnits.Contracts;

namespace AspLearn.Services.Cities {
    public sealed class CityService : ICityService {

        private readonly ICityRepository _cityRepository;

        /// <summary>
        ///     ctor().
        /// </summary>
        public CityService(ICityRepository cityRepository) {
            _cityRepository = cityRepository;
        }

        public Task<List<City>> GetAllCitiesAsync() =>
            Task.Run(() => {
                return _cityRepository.GetAll();
            });

        public Task<City> GetCityByNetIdAsync(Guid netId) =>
           Task.Run(() => {
               return _cityRepository.GetByNetId(netId);
           });
    }
}
