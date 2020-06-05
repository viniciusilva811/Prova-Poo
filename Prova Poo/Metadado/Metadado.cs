
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using Prova_Poo.Model;

namespace Prova_Poo.Model
{
    public partial class provapooEntities : DbContext
    {
        public System.Data.Entity.DbSet<Model.serie> Serie { get; set; }
        public System.Data.Entity.DbSet<Model.episodio> Episodio { get; set; }
    }

    [MetadataType(typeof(serieMD))]
    public partial class serie
    {
        public class serieMD
        {

            public long Id { get; set; }
            [Required]
            public string Nome { get; set; }
            [Required]  
            public string Temporada { get; set; }

        }
    }


    [MetadataType(typeof(episodioMD))]
    public partial class episodio
    {
        public class episodioMD
        {

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

            public virtual serie serie { get; set; }
        }
    }




}