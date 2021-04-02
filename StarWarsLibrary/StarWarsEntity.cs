using System;
using System.Collections.Generic;

namespace StarWarsLibrary
{
    public class StarWarsEntity<T> where T : class
    {
        public int count  { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<T> results { get; set; }
    }
}
