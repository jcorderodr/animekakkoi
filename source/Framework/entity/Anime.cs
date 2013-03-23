using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.entity
{
    public class Anime
    {

        public int Codigo { get; set; }

        public ANIME_STATE Estado { get; set; }

        public String Nombre { get; set; }

        public int Captiulos { get; set; }

        public String Comentario { get; set; }

        //Agregar categoria/gusto/genero

    }

    public enum ANIME_STATE
    {
        QUEUE = 1,
        WATCHING = 2,
        WATCHED = 3
    }

}
