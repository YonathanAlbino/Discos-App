using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Disco
    {

        public Disco(string titulo, int cantidadCancioes) //string genero
        {
        //    this.genero = new Estilo();
        //    this.genero.Descripcion = genero;
            Titulo = titulo;
            CantidadDeCanciones = cantidadCancioes;

        }
        public Disco()
        {

        }


        public int Id { get; set; }
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [DisplayName("Fecha de lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }
        [DisplayName("Cantidad de canciones")]
        public int CantidadDeCanciones { get; set; }

        public string UrlImagenTapa { get; set; }


        //private Estilo genero;
        [DisplayName("Género")]
        public Estilo Genero { get; set; }
        [DisplayName("Edición")]
        public TipoDeEdicion Edicion { get; set; }

        

    }
}
