using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TravelMonkey.Models;

namespace TravelMonkey.Services
{
    internal class DataTranslationsService
    {
        static DataTranslationsService item;
        public static DataTranslationsService Instance
        {
            get
            {
                if (item == null)
                {
                    item = new DataTranslationsService();
                }
                return item;
            }
        }
        public List<OldSearchs> Listado = new List<OldSearchs>();
        public void Add(string phrase, Dictionary<string, string> results)
        {
            try
            {
                Listado.Add(new OldSearchs()
                {
                    Phrase = phrase,
                    Resultados = results
                });
            }
            catch (Exception)
            {

            }
        }
    }
}
