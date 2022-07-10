using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOOperation
{
    /// <summary>
    /// Json Input and Output Operations
    /// </summary>
    class JasonDataOperaton
    {
        /// <summary>
        /// Jsons the serialize
        /// </summary>
        public static void JsonSerialize()
        {
            string jsonPath = @"C:\Users\GURPREET SINGH\Desktop\RFP\AdressBookCollection\AddressBookCollection\Files\JsonData.json";
            //Collection Intialiser
            List<Person> person = new List<Person>()
            {
               new Person(){PersonId = 12, Name = "Ganesh", Address = "Portblair"},
               new Person(){PersonId = 13, Name = "Arun", Address = "bihar"},
               new Person(){PersonId = 12, Name = "Deepak", Address = "Calcutta"},
            };
            //Serialise Object method used to convert from object into json data
            string result = JsonConvert.SerializeObject(person);
            //Writing in to file
            File.WriteAllText(jsonPath, result);
        }
        public static void JsonDeserialize()
        {
            string jsonPath = @"C:\Users\GURPREET SINGH\Desktop\RFP\AdressBookCollection\AddressBookCollection\Files\JsonData.json";
            if (Program.IsFileExists(jsonPath))
            {
                string JsonData = File.ReadAllText(jsonPath);
                List<Person> result = JsonConvert.DeserializeObject<List<Person>>(JsonData);
                if (result.Count != 0)
                {
                    foreach (Person person in result)
                    {
                        Console.WriteLine(person.PersonId + " " + person.Name + " " + person.Address);
                    }
                }
            }
        }
        public class Person
        {
            public int PersonId { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }

            public override string ToString()
            {
                return $"Id : " + PersonId + " Name " + Name + "Address" + Address;
            }
        }
    }
}