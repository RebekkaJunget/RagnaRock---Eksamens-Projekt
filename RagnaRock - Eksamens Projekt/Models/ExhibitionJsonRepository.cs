﻿using RagnaRock___Eksamens_Projekt.Pages;
using System.Diagnostics;
using System.Formats.Asn1;

namespace RagnaRock___Eksamens_Projekt.Models
{
    public class ExhibitionJsonRepository : IExhibitionRepository
    {
        List<Exhibition> exhibitions;

        string path = @"C:\Users\RJung\Downloads\RagnaRock---Eksamens-Projekt-master (1)\RagnaRock---Eksamens-Projekt-master\RagnaRock - Eksamens Projekt\Data\ExhibitionsFile.Json";
        public ExhibitionJsonRepository()
        {
            Debug.WriteLine("test");
            exhibitions = JsonReader.ReadFromFile(path);
        }

       
        public List<Exhibition> GetAll()
        {
            return exhibitions;
        }

      

        public Exhibition Get(int id)
        {
            if (exhibitions != null)
                return (exhibitions[exhibitions.FindIndex(e => e.Id == id)]);
            return null;
        }

        public void Delete(int id)
        {
            //Vi tjekker lige at listen ikke er null eller tom - alternativt ville der blive smidt en exception
            if ((exhibitions != null) && (exhibitions.Count > 0))
            {
                //Her leder vi efter elementet gennem linq
                int c = exhibitions.FindIndex(e => e.Id == id);
                exhibitions.RemoveAt(exhibitions.FindIndex(e => e.Id == id));
                JsonWriter.WriteToFile(path, exhibitions);
            }
        }

        public void Add(Exhibition exhibition)
        {
            if (exhibitions != null)
            {
                exhibitions.Add(exhibition);
                JsonWriter.WriteToFile(path, exhibitions);
            }
            
        }
    }
}
