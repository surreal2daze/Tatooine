using System.Collections.Generic;

namespace StarWarsLibrary
{
    public interface IStarWarsUniverse<T> where T :class
    {
       IList<T> GetAll();
       T GetSingle(string endpoint);
    }
}