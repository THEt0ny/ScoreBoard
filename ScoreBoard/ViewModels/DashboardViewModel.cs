using ScoreBoard.Models;
using ScoreBoard.ViewModels;
using System;

namespace ScoreBoard.ViewModels
{
    public class DashboardViewModel
    {
        public Joueur joueur { get; set; }
        public Jeu jeu {  get; set; }
        public int ScoreTotal { get; set; }

        public DashboardViewModel(Jeu jeu, Joueur joueur, int ScoreTotal)
        {
            this.jeu = jeu;
            this.joueur = joueur;
            this.ScoreTotal = ScoreTotal;
        }

        public override string ToString()
        {
            return "Jeu: " + this.jeu.Nom + ", Joueur: " + this.joueur.Nom; 
        }
    }
}
