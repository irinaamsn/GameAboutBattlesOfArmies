using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace GameAboutBattlesOfArmies.BL.Controlller
{
    public class SerialisableArmie : IDataSaver
    {
        private const string fileName = "armie.json";
        public SerialisableArmie() { }
        //public Armie Load()
        //{
        //    using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
        //    {
        //        var item = JsonSerializer.Deserialize<Armie>(fs);
        //        if (item == null)
        //            throw new Exception();
        //        return item;
        //    }
        //}
        public void Save(Armie obj)
         {
            using (FileStream fs = File.Create(fileName))
            {
                var json = JsonSerializer.Serialize(fs, new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                });
                JsonSerializer.Serialize(fs, obj);
                Console.WriteLine("Data has been saved to file");

            }

        }
    }
}
