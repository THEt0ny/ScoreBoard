using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;
using ScoreBoard.ViewModels;
using ScoreBoard.Models;

namespace ScoreBoard.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IJeuRepository jeuRepository;
        private readonly IJoueurRepository joueurRepository;

        public DashboardController(IJeuRepository jeuRepository, IJoueurRepository joueurRepository)
        {
            this.jeuRepository = jeuRepository;
            this.joueurRepository = joueurRepository;
        }

        public IActionResult Index()
        {
            var jeuxJoueurs = new List<DashboardViewModel>();

            var jeux = this.jeuRepository.ListeJeux;
            foreach (var jeu in jeux)
            {
                var joueur = this.joueurRepository.GetJoueur(jeu.JoueurId);
                var jeuJoueurViewModel = new DashboardViewModel(jeu,jeu.Joueur, 120);
                jeuxJoueurs.Add(jeuJoueurViewModel);
            }

            return View(jeuxJoueurs);
        }
    }
}
