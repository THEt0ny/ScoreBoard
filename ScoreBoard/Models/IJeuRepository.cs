namespace ScoreBoard.Models
{
    public interface IJeuRepository
    {
        public List<Jeu> ListeJeux{ get; }
        public Jeu? GetJeu(int id);
        public void Ajouter(Jeu jeu);
        public void Modifier(Jeu jeu);
        public void Supprimer(int id);
    }
}
