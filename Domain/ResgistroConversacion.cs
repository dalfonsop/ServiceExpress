using Dapper.Contrib.Extensions;

namespace ServiceExpress.Domain
{
    [Table("public.RegistroConversacion")]
    public class ResgistroConversacion
    {
        [Key]
        public long IdRegistroConversacion { get; set; }
        public string? NumeroTelefonicoRemitente { get; set; }
        public int IdUltimoFlujoComunicacionEnviado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public override string ToString()
        {
            var response = $"IdRegistroConversacion: {IdRegistroConversacion} \n NumeroTelefonicoRemitente: {NumeroTelefonicoRemitente} \n IdUltimoFlujoComunicacionEnviado: {IdUltimoFlujoComunicacionEnviado} \n FechaCreacion: {FechaCreacion}";
            return response ;
        }
    }
}
