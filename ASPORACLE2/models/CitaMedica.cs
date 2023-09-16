using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPORACLE2.Models
{
    public class CitaMedica
    {
        
        public int ID_CITA { get; set; }
        public int ID_PACIENTE { get; set; }
        public int ID_MEDICO {  get; set; }
        public DateTime FECHA_HORA { get; set; }
        public string MOTIVO { get; set; }

        public CitaMedica()
        {
        }

        public CitaMedica(int ID_CITA, int ID_PACIENTE, int ID_MEDICO, DateTime FECHA_HORA, string MOTIVO)
        {
            this.ID_CITA = ID_CITA;
            this.ID_PACIENTE = ID_PACIENTE;
            this.ID_MEDICO = ID_MEDICO;
            this.FECHA_HORA = FECHA_HORA;
            this.MOTIVO = MOTIVO;
        }
    }
}