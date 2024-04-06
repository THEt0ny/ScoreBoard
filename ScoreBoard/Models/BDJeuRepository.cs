namespace ScoreBoard.Models
{
    public class BDJeuRepository: IJeuRepository
    {
        private readonly CatalogueJeuDbContext _catalogueJeudbContext;

        public BDJeuRepository(CatalogueJeuDbContext catalogueJeuDbContext)
        {
            _catalogueJeudbContext = catalogueJeuDbContext;
        }

        public List<Jeu> ListeJeux
        {
            get
            {
                return _catalogueJeudbContext.Jeus.OrderBy(x => x.Id).ToList();
            }
        }

        public Jeu GetJeu(int jeuId)
        {
            return _catalogueJeudbContext.Jeus.FirstOrDefault(x => x.Id == jeuId);
        }

        public void Ajouter(Jeu jeu)
        {
            _catalogueJeudbContext.Jeus.Add(jeu);
            _catalogueJeudbContext.SaveChanges();
        }

        public void Modifier(Jeu jeu)
        {
            var existingJeu = _catalogueJeudbContext.Jeus.FirstOrDefault(x => x.Id == jeu.Id);
            if (existingJeu != null)
            {
                existingJeu.Nom = jeu.Nom;
                existingJeu.Description = jeu.Description;
                existingJeu.DateSortie = jeu.DateSortie;
                existingJeu.DateEnregistrement = jeu.DateEnregistrement;
                existingJeu.ScoreJoueur = jeu.ScoreJoueur;
                _catalogueJeudbContext.SaveChanges();
            }
        }

        public void Supprimer(int id)
        {

            var jeuToDelete = _catalogueJeudbContext.Jeus.FirstOrDefault(x => x.Id == id);
            if (jeuToDelete != null)
            {
                _catalogueJeudbContext.Jeus.Remove(jeuToDelete);
                _catalogueJeudbContext.SaveChanges();
            }
        }
    }
}
