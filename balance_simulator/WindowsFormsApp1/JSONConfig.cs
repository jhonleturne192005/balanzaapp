using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class JSONConfig
    {
        public JSONConfig() { }

        public String createJson(String peso_actual,String peso_bruto,String tara)
        {
            JObject jo = new JObject();
            jo.Add("peso_actual", peso_actual);
            jo.Add("peso_bruto", peso_bruto);
            jo.Add("tara", tara);
            return jo.ToString();
        }

    }
}
