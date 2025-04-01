using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialUniversitaria.Domain
{
    public class Comentario
    {
        public int Id { get; set; }
        public int PostagemId { get; set; }
        public Postagem Postagem { get; set; }
        public int AutorId { get; set; }
        public Usuario Autor { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }
    }
}
