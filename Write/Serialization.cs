using FluxDonneeTPDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Write
{
    public class Serialization
    {
        private static Serialization? _instance;
        private static readonly object _verrou = new();

        public static Serialization Instance
        {
            get 
            {
                lock (_verrou)
                {
                    //if (_instance == null) { _instance = new Serialization(); } cela équivaut à
                    _instance ??= new Serialization();

                } 
                return _instance;
            }
        }

        private Serialization() { }

        public string GetSerialization( HashSet<Personne> listeP )
        {
            return JsonSerializer.Serialize<HashSet<Personne>> (listeP, new JsonSerializerOptions() { AllowTrailingCommas = true });
        }
    }
}
