using ScoreBoard.Models;

namespace ScoreBoard.Models
{
    public class BDJoueurRepository: IJoueurRepository
    {
        private readonly CatalogueJeuDbContext _catalogueJeudbContext;

        public BDJoueurRepository(CatalogueJeuDbContext catalogueJeuDbContext)
        {
            _catalogueJeudbContext = catalogueJeuDbContext;
        }

        public List<Joueur> ListeJoueurs
        {
            get
            {
                return _catalogueJeudbContext.Joueurs.OrderBy(x => x.Nom).ToList();
            }
        }

        public Joueur GetJoueur(int joueurId)
        {
            return _catalogueJeudbContext.Joueurs.FirstOrDefault(x => x.Id == joueurId);
        }

        public void Modifier(Joueur joueur)
        {
            var existingJoueur = _catalogueJeudbContext.Joueurs.FirstOrDefault(x => x.Id == joueur.Id);
            if (existingJoueur != null)
            {
                existingJoueur.Nom = joueur.Nom;
                existingJoueur.Prenom = joueur.Prenom;
                existingJoueur.Telephone = joueur.Telephone;
                existingJoueur.Courriel = joueur.Courriel;
                existingJoueur.Jeux = joueur.Jeux;
                _catalogueJeudbContext.SaveChanges();
            }
        }

        public void Supprimer(int id)
        {

            var joueurToDelete = _catalogueJeudbContext.Joueurs.FirstOrDefault(x => x.Id == id);
            if (joueurToDelete != null)
            {
                _catalogueJeudbContext.Joueurs.Remove(joueurToDelete);
                _catalogueJeudbContext.SaveChanges();
            }
        }
    }
}
