using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarWarsLibrary
{
    public class StarWarsPeopleService : GenericHttpWookiee<People>, IStarWarsUniverse<People>
    {
        public IList<People> GetAll()
        {
            return PaginatedData("/people/").ToList();
        }

        public People GetSingle(string endpoint)
        {
            return GetSingleData(endpoint);
        }
    }
}
