using System.Collections.Generic;
using System.Linq;

namespace StarWarsLibrary
{
    public class StarWarsDeepCore
    {

        private readonly StarshipService _sService;
        private readonly StarWarsPeopleService _pService;

        public int CarryPassengers { get; set; }
        public StarWarsDeepCore()
        {
            _sService = new StarshipService();
            _pService = new StarWarsPeopleService();
        }

        public IList<StarshipWithPilot> AllStarshipsWithPilot()
        {
            List<StarshipWithPilot> collection = new List<StarshipWithPilot>();

            foreach (var item in _sService.GetAll().Where(s => s._passenger >= CarryPassengers))
            {
                //if (!item.pilots?.Any() ?? false )
                //{
                //    collection.Add(new StarshipWithPilot { StarshipName = item.name, StarshipPilot = "None" });
                //}
                foreach (var item2 in item.pilots)
                {
                    var peopleEntity = _pService.GetSingle(item2);
                    collection.Add(new StarshipWithPilot { StarshipName = item.name, StarshipPilot = peopleEntity.name });

                }
            }

            return collection;
        }




       
    }
}
