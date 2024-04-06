using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;

namespace ScoreBoard.Controllers
{
    public class JoueurController : Controller
    {
        private readonly IJoueurRepository joueurRepository;

        public JoueurController(IJoueurRepository joueurRepository)
        {
            this.joueurRepository = joueurRepository;
        }

        public IActionResult Index()
        {
            List<Joueur> listeJoueurs = this.joueurRepository.ListeJoueurs;
            return View(listeJoueurs);
        }

        public IActionResult Modifier(int joueurId)
        {
            Joueur joueur = this.joueurRepository.ListeJoueurs.FirstOrDefault(x => x.Id == joueurId);   
            return View(joueur);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModifierJoueur(Joueur joueur)
        {
            this.joueurRepository.Modifier(joueur);
            return View("Index", this.joueurRepository.ListeJoueurs);
        }

        public IActionResult Supprimer(int joueurId)
        {
            Joueur joueur = this.joueurRepository.ListeJoueurs.FirstOrDefault(x => x.Id == joueurId);
            return View(joueur);
        }

        public IActionResult SupprimerJoueur(int joueurId)
        {
            this.joueurRepository.Supprimer(joueurId);
            return View("Index", this.joueurRepository.ListeJoueurs);
        }
    }
}
