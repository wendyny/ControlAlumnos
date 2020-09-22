using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ControlAlumnos.Models
{
    public class Grado
    {
        [Key]
        public int idGrado { get; set; }
        public string nombreGrado { get; set; }
        public List<Alumno> alumnos { get; set; }
    }
}
