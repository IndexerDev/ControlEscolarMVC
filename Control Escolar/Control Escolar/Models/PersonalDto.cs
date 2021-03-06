﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Control_Escolar.Models
{
    public class PersonalDto
    {
        public int IdPersonal { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string CorreoElectronico { get; set; }
        public PersonalTipoDto PersonalTipo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? FechaNacimiento { get; set; }
        [MaxLength(17)]
        public string NumeroControl { get; set; }
        public bool Estatus { get; set; }
        public decimal PersonalSueldo { get; set; }
    }
}