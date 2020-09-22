using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ControlAlumnos.Models
{
    public class Mes
    {
        [Key]
        public int idMes { get; set; }
        public string nombreMes { get; set; }
        public List<DetallePagos> detalleMes { get; set; }
    }
}
