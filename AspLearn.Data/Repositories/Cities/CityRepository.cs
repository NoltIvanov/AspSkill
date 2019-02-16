using AspLearn.Data.Entities;
using AspLearn.Data.TransactionUnits;
using AspLearn.Data.TransactionUnits.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspLearn.Data.Repositories.Cities {
    public sealed class CityRepository : ICityRepository {

        private readonly ITransactionUnit _transactionUnit;

        public CityRepository(ITransactionUnit transactionUnit) {
            _transactionUnit = transactionUnit;
        }

        public List<City> GetAll() {
            return _transactionUnit.GetTable<City>().ToList();
        }

        public City GetByNetId(Guid netId) =>
          _transactionUnit
              .GetTable<City>()
              .FirstOrDefault(u => u.NetUid.Equals(netId));

        public City Add(City city) =>
            _transactionUnit
                .GetTable<City>()
                .Add(city)
                .Entity;
    }
}
