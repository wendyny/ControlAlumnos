using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ControlAlumnos.Models
{
    public class DetallePagos
    {
        [Key]
        public int IdAlumno_master { get; set; }
        public int idAlumno { get; set; }
        public int idMes { get; set; }  
        public DateTime fecha { get; set; }
        public int Total { get; set; }
        public Alumno Alumno { get; set; }
        public Mes Mes { get; set; }
        
    }
}
