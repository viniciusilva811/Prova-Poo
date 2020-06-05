using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prova_Poo.Model
{
    public class ViewModelSerieEpisodio
    {

        //Episodio
        public long Id { get; set; }

        public Nullable<long> Id_Serie { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Numero Episodio")]
        public Nullable<int> NumeroEpisodio { get; set; }
        [Required]
        [Display(Name = "Avaliação")]
        public string Avaliacao { get; set; }

       //Serie
        [Required]
        public string NomeSerie { get; set; }
        [Required]
        public string Temporada { get; set; }



    }
}