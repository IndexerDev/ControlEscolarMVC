using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Control_Escolar.Models
{
    public class PersonalTipoBaseUpdateDto
    {
        public byte IdPersonalTipo { get; set; }
        [Required]
        [MaxLength(50)]
        public string PersonalTipoDescripcion { get; set; }
        [Required]
        public bool IsPersonalLaboral { get; set; }
        public Nullable<byte> IdSueldosTabulacion { get; set; }
    }
}