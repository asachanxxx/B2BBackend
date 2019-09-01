using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.Unitilities
{
    public class JsonEngine
    {

        public string ConvertFromList<T>(List<T> obj) where T : class
        {
            var json = JsonConvert.SerializeObject(obj);
            return json;
        }

        public List<T> ConvertFromJson<T>(string str) where T : class
        {
            var deserializedItemsFromItems = JsonConvert.DeserializeObject<List<T>>(str);
            return deserializedItemsFromItems;
        }



    }
}
