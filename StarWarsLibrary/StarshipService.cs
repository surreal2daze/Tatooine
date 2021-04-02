using System;
using System.Collections.Generic;
using System.Linq;

namespace StarWarsLibrary
{
    public class StarshipService: GenericHttpWookiee<Starship>,IStarWarsUniverse<Starship>
    {

        public IList<Starship> GetAll()
        {
            return PaginatedData("/starships/").ToList();
        }

        public Starship GetSingle(string endpoint)
        {
            throw new NotImplementedException();
        }
    }
}
