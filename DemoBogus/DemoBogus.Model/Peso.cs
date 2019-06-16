using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBogus.Model
{
    public class Peso
    {
        public decimal Peso1 { get; set; }
        public decimal Peso2 { get; set; }
        public decimal Peso3 { get; set; }
        public decimal Peso4 { get; set; }
        public decimal Peso5 { get; set; }
        public decimal Peso6 { get; set; }

        public string AsJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
