using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Disco
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int CantidadDeCanciones { get; set; }
        public string UrlImagenTapa { get; set; }
        public Estilo genero { get; set; }
        public TipoDeEdicion Edicion { get; set; }
        
    }
}
