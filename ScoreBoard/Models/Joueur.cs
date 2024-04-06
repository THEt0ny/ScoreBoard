namespace ScoreBoard.Models
{
    public class Joueur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Equipe { get; set; }
        public string? Telephone { get; set; }
        public string Courriel { get; set; }
        public List<Jeu>? Jeux { get; set; }
    }
}
