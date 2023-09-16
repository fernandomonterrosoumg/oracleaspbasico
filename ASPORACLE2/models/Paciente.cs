using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPORACLE2.Models
{
    public class Paciente
    {

        public string ID_PACIENTE { get; set; }
        public string NOMBRE { get; set; }
        public int EDAD {  get; set; }
        public string GENERO {  get; set; }
        public DateTime FEC_ING {  get; set; }

        public Paciente()
        {
        }

        public Paciente(string ID_PACIENTE, string NOMBRE, int EDAD, string GENERO, DateTime FEC_ING)
        {
            this.ID_PACIENTE = ID_PACIENTE;
            this.NOMBRE = NOMBRE;
            this.EDAD = EDAD;
            this.GENERO = GENERO;
            this.FEC_ING = FEC_ING;
        }
    }
}