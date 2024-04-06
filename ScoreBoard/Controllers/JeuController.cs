using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using ScoreBoard.Models;

namespace ScoreBoard.Controllers
{
    public class JeuController : Controller
    {
        private readonly IJeuRepository jeuRepository;
        private readonly IJoueurRepository joueurRepository;

        public JeuController(IJeuRepository jeuRepository, IJoueurRepository joueurRepository)
        {
            this.jeuRepository = jeuRepository;
            this.joueurRepository = joueurRepository;
        }

        public IActionResult Index()
        {
            List<Jeu> listeJeu = jeuRepository.ListeJeux;
            return View(listeJeu);
        }

        public IActionResult Modifier(int jeuId)
        {
            Jeu jeu = this.jeuRepository.ListeJeux.FirstOrDefault(x => x.Id == jeuId);
            var joueurIdList = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = jeu.JoueurId.ToString() },
            };

            ViewBag.JoueurId = joueurIdList;
            return View(jeu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModifierJeu(Jeu jeu)
        {
            this.jeuRepository.Modifier(jeu);
            return View("Index", this.jeuRepository.ListeJeux);
        }

        public IActionResult Nouveau()
        {
            var joueurList = new List<SelectListItem>();
            foreach (var joueur in this.joueurRepository.ListeJoueurs)
            {
                joueurList.Add(new SelectListItem { Value = joueur.Id.ToString(), Text = joueur.Nom });
            }
            ViewBag.Joueur = joueurList; 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AjouterJeu(Jeu jeu)
        {
            jeu.Joueur = this.joueurRepository.GetJoueur(jeu.JoueurId);
            jeu.JoueurId = jeu.JoueurId;
            this.jeuRepository.Ajouter(jeu);
            return View("Index", this.jeuRepository.ListeJeux);
        }

        public IActionResult Supprimer(int jeuId)
        {
            Jeu jeu = this.jeuRepository.ListeJeux.FirstOrDefault(x => x.Id == jeuId);
            return View(jeu);
        }

        public IActionResult SupprimerJeu(int jeuId)
        {
            this.jeuRepository.Supprimer(jeuId);
            return View("Index", this.jeuRepository.ListeJeux);
        }
    }
}
