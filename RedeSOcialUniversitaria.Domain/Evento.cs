namespace RedeSocialUniversitaria.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public string Descricao { get; set; }
        public Usuario Organizador { get; set; }
        public int OrganizadorId { get; set; }
        public DateTime Data { get; set; }
    }
}
