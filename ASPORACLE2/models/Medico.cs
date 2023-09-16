using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPORACLE2.Models
{
    public class Medico
    {
        public string ID_MEDICO { get; set; }
        public string NOMBRE { get; set; }
        public string ESPECIALIDAD {  get; set; }
        public int EXP_ANIO {  get; set; }
        public int NUM_COLE {  get; set; }

        public Medico()
        {
        }
            
        public Medico(string ID_MEDICO, string NOMBRE, string ESPECIALIDAD, int EXP_ANIO, int NUM_COLE)
        {
            this.ID_MEDICO = ID_MEDICO;
            this.NOMBRE = NOMBRE;
            this.ESPECIALIDAD = ESPECIALIDAD;
            this.EXP_ANIO = EXP_ANIO;
            this.NUM_COLE = NUM_COLE;
        }
    }
}