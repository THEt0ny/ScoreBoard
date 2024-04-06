using System.ComponentModel.DataAnnotations;

namespace ScoreBoard.Models
{
    public class Jeu
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        [DataType("Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Date de sortie")]
        public DateTime DateSortie { get; set; }
        public string Description { get; set; }
        public int JoueurId { get; set; }
        public Joueur Joueur { get; set; }
        public int ScoreJoueur { get; set; }
        [DataType("Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Date d'enregistrement")]
        public DateTime DateEnregistrement { get; set; }
    }
}
