using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ControlAlumnos.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }
        public string nombre { get; set; }
        public int idGrado { get; set; }
        public Grado grado { get; set; }
        public List<DetallePagos> detalleAlumno { get; set; }
    }
}
