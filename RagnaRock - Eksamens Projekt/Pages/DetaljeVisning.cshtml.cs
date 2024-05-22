using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RagnaRock___Eksamens_Projekt.Models;
using System.Diagnostics;
using System.Collections.Generic;

namespace RagnaRock___Eksamens_Projekt.Pages
{
    public class DetaljeVisningModel : PageModel
    {
        private readonly ILogger<DetaljeVisningModel> _logger;
        public Exhibition Exhibition { get; private set; }
        public readonly IExhibitionRepository _repo;

        public DetaljeVisningModel(IExhibitionRepository repo, ILogger<DetaljeVisningModel> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public void OnGet(int id)
        {
            Debug.WriteLine("::::::::::::::::::::::::::::::" + id);
            Exhibition = _repo.Get(id); // Populate AllExhibitions with all exhibitions
        }

        // Handler til at h�ndtere sletning
        public IActionResult OnGetDelete(int id)
        {
            _repo.Delete(id);
            return Redirect("Listevisning");
        }
    }
}





    /* public class DetaljeVisningModel : PageModel
     {
         private readonly ILogger<IndexModel> _logger;
         public List<Exhibition> AllExhibitions { get; set; }
         public Exhibition Exhibition { get; set; }
         public readonly IExhibitionRepository _repo;

         public DetaljeVisningModel(IExhibitionRepository repo)
         {
             _repo = repo;

         }

         public void OnGet(int id)
         {
             Debug.WriteLine("::::::::::::::::::::::::::::::" + id);
             Exhibition = _repo.Get(id);
         }

         //Handler til at h�ndtere sletning
         public IActionResult OnGetDelete(int id)
         {
             _repo.Delete(id);
             return Redirect("Listevisning");
         }
     }*/

