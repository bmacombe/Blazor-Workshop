using System;
using System.Linq;
using BandBookerData;
using BandBookerData.Models;


namespace BandBookerDataTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Un-comment to start over
            //DataManager.DeleteAll();

            // Add Guitar
            var guitar = (from i in DataManager.Instruments
                where i.Name == "Guitar"
                select i).FirstOrDefault();
            if (guitar == null)
            {
                guitar = new Instrument()
                {
                    Name = "Guitar"
                };
                DataManager.AddInstrument(guitar);
            }
            Console.WriteLine("Instrument: {0} with InstrumentId {1}",
                guitar.Name, guitar.InstrumentId);

            // Add Keyboards
            var keyboards = (from i in DataManager.Instruments
                          where i.Name == "Keyboards"
                          select i).FirstOrDefault();
            if (keyboards == null)
            {
                keyboards = new Instrument()
                {
                    Name = "Keyboards"
                };
                DataManager.AddInstrument(keyboards);
            }
            Console.WriteLine("Instrument: {0} with InstrumentId {1}",
                keyboards.Name, keyboards.InstrumentId);
        }
    }
}