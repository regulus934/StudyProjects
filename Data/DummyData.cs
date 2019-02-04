using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Data
{
    public class DummyData
    {
        public static System.Collections.Generic.List<Instrument> getInstruments()
        {
            List<Instrument> instruments = new List<Instrument>()
            {
                new Instrument(){
                    Name = "Стул",
                    Kolvo = 0,
                    Comments = " "
                    
                },
                new Instrument(){
                    Name = "Стол",
                    Kolvo = 0,
                    Comments = " "
                },
                new Instrument(){
                    Name = "Калькулятор",
                    Kolvo = 0,
                    Comments = " "
                },
                new Instrument(){
                    Name = "Ведро",
                    Kolvo = 0,
                    Comments = " "
                },
                new Instrument(){
                    Name = "Веник",
                    Kolvo = 0,
                    Comments = " "
                },
            };
            return instruments;

        }
    }
}