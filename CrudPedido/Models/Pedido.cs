namespace CrudPedido.Models
{
    public class Pedido
    {
        public int pedidoid { get; set; }
        public char origencodigo { get; set; }
        public string tipodocumento { get; set; }
        public int numerodocumento { get; set; }
        public int entidadid { get; set; }
        public string direcciondespacho { get; set; }
        public int padreentidadid { get; set; }
        public int? vendedorid { get; set; }
        public string ordencompra { get; set; }
        public int periodoid { get; set; }
        public int plazopagoid { get; set; }
        public DateTime fechadocumento { get; set; }
        public DateTime fechavencimiento { get; set; }
        public DateTime? fechaentrega { get; set; }
        public DateTime? fechadespacho { get; set; }
        public decimal valorneto { get; set; }
        public decimal valorseguro { get; set; }
        public decimal valorflete { get; set; }
        public decimal valoriva { get; set; }
        public decimal valordescuento { get; set; }
        public decimal valorotros { get; set; }
        public decimal valorbruto { get; set; }
        public string comentario { get; set; }
        public long? incotermid { get; set; }
        public int listaprecioid { get; set; }
        public string valormigradooriginal { get; set; }
        public string bdtablaorigendevalormigrado { get; set; }
        public DateTimeOffset fechacreacionlog { get; set; }
        public string creadoporlog { get; set; }
        public DateTimeOffset fechamodificacionlog { get; set; }
        public string modificadoporlog { get; set; }
        public char estadodefila { get; set; }
    }
}
