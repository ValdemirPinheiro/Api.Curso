namespace curso.Api.Business.Entities
{
    public class Curso
    {
        public int Codigo { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public int CodigoUser { get; set; }
        public virtual User User { get; set; }



    }
}
