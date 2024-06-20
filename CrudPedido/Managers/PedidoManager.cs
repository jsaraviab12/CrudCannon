using CrudPedido.Models;
using System.Data.SqlClient;
using System.Data;
using CrudPedido.Requests;

namespace CrudPedido.Managers
{
    public class PedidoManager
    {

        private readonly string conexion;


        public PedidoManager(IConfiguration configuration)
        {
            conexion = configuration.GetConnectionString("CadenaSQL")!;
        }

        public async Task<List<Pedido>> GetPedidos()
        {
            List<Pedido> list = new List<Pedido>();
            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from Pedido", con);
                cmd.CommandType = CommandType.Text;
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Pedido pedido = new Pedido
                        {
                            pedidoid = reader.GetInt32(reader.GetOrdinal("pedidoid")),
                            origencodigo = reader.GetString(reader.GetOrdinal("origencodigo")).FirstOrDefault(),
                            tipodocumento = reader.GetString(reader.GetOrdinal("tipodocumento")),
                            numerodocumento = reader.GetInt32(reader.GetOrdinal("numerodocumento")),
                            entidadid = reader.GetInt32(reader.GetOrdinal("entidadid")),
                            direcciondespacho = reader.IsDBNull(reader.GetOrdinal("direcciondespacho")) ? null : reader.GetString(reader.GetOrdinal("direcciondespacho")),
                            padreentidadid = reader.GetInt32(reader.GetOrdinal("padreentidadid")),
                            vendedorid = reader.IsDBNull(reader.GetOrdinal("vendedorid")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("vendedorid")),
                            ordencompra = reader.IsDBNull(reader.GetOrdinal("ordencompra")) ? null : reader.GetString(reader.GetOrdinal("ordencompra")),
                            periodoid = reader.GetInt32(reader.GetOrdinal("periodoid")),
                            plazopagoid = reader.GetInt32(reader.GetOrdinal("plazopagoid")),
                            fechadocumento = reader.GetDateTime(reader.GetOrdinal("fechadocumento")),
                            fechavencimiento = reader.GetDateTime(reader.GetOrdinal("fechavencimiento")),
                            fechaentrega = reader.IsDBNull(reader.GetOrdinal("fechaentrega")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fechaentrega")),
                            fechadespacho = reader.IsDBNull(reader.GetOrdinal("fechadespacho")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fechadespacho")),
                            valorneto = reader.GetDecimal(reader.GetOrdinal("valorneto")),
                            valorseguro = reader.GetDecimal(reader.GetOrdinal("valorseguro")),
                            valorflete = reader.GetDecimal(reader.GetOrdinal("valorflete")),
                            valoriva = reader.GetDecimal(reader.GetOrdinal("valoriva")),
                            valordescuento = reader.GetDecimal(reader.GetOrdinal("valordescuento")),
                            valorotros = reader.GetDecimal(reader.GetOrdinal("valorotros")),
                            valorbruto = reader.GetDecimal(reader.GetOrdinal("valorbruto")),
                            comentario = reader.IsDBNull(reader.GetOrdinal("comentario")) ? null : reader.GetString(reader.GetOrdinal("comentario")),
                            incotermid = reader.IsDBNull(reader.GetOrdinal("incotermid")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("incotermid")),
                            listaprecioid = reader.GetInt32(reader.GetOrdinal("listaprecioid")),
                            valormigradooriginal = reader.IsDBNull(reader.GetOrdinal("valormigradooriginal")) ? null : reader.GetString(reader.GetOrdinal("valormigradooriginal")),
                            bdtablaorigendevalormigrado = reader.IsDBNull(reader.GetOrdinal("bdtablaorigendevalormigrado")) ? null : reader.GetString(reader.GetOrdinal("bdtablaorigendevalormigrado")),
                            fechacreacionlog = reader.GetDateTimeOffset(reader.GetOrdinal("fechacreacionlog")),
                            creadoporlog = reader.GetString(reader.GetOrdinal("creadoporlog")),
                            fechamodificacionlog = reader.GetDateTimeOffset(reader.GetOrdinal("fechamodificacionlog")),
                            modificadoporlog = reader.GetString(reader.GetOrdinal("modificadoporlog")),
                            estadodefila = reader.GetString(reader.GetOrdinal("estadodefila")).FirstOrDefault(),
                        };
                        list.Add(pedido);
                    }
                }
            }
            return list;
        }
        public async Task<Pedido> GetPedido(int PedidoId)
        {
            Pedido pedido = new Pedido();
            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from Pedido  WHERE PedidoId = @PedidoId ", con);
                cmd.Parameters.AddWithValue("@PedidoId", PedidoId);
                cmd.CommandType = CommandType.Text;
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                         pedido = new Pedido
                        {
                            pedidoid = reader.GetInt32(reader.GetOrdinal("pedidoid")),
                            origencodigo = reader.GetString(reader.GetOrdinal("origencodigo")).FirstOrDefault(),
                            tipodocumento = reader.GetString(reader.GetOrdinal("tipodocumento")),
                            numerodocumento = reader.GetInt32(reader.GetOrdinal("numerodocumento")),
                            entidadid = reader.GetInt32(reader.GetOrdinal("entidadid")),
                            direcciondespacho = reader.IsDBNull(reader.GetOrdinal("direcciondespacho")) ? null : reader.GetString(reader.GetOrdinal("direcciondespacho")),
                            padreentidadid = reader.GetInt32(reader.GetOrdinal("padreentidadid")),
                            vendedorid = reader.IsDBNull(reader.GetOrdinal("vendedorid")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("vendedorid")),
                            ordencompra = reader.IsDBNull(reader.GetOrdinal("ordencompra")) ? null : reader.GetString(reader.GetOrdinal("ordencompra")),
                            periodoid = reader.GetInt32(reader.GetOrdinal("periodoid")),
                            plazopagoid = reader.GetInt32(reader.GetOrdinal("plazopagoid")),
                            fechadocumento = reader.GetDateTime(reader.GetOrdinal("fechadocumento")),
                            fechavencimiento = reader.GetDateTime(reader.GetOrdinal("fechavencimiento")),
                            fechaentrega = reader.IsDBNull(reader.GetOrdinal("fechaentrega")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fechaentrega")),
                            fechadespacho = reader.IsDBNull(reader.GetOrdinal("fechadespacho")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fechadespacho")),
                            valorneto = reader.GetDecimal(reader.GetOrdinal("valorneto")),
                            valorseguro = reader.GetDecimal(reader.GetOrdinal("valorseguro")),
                            valorflete = reader.GetDecimal(reader.GetOrdinal("valorflete")),
                            valoriva = reader.GetDecimal(reader.GetOrdinal("valoriva")),
                            valordescuento = reader.GetDecimal(reader.GetOrdinal("valordescuento")),
                            valorotros = reader.GetDecimal(reader.GetOrdinal("valorotros")),
                            valorbruto = reader.GetDecimal(reader.GetOrdinal("valorbruto")),
                            comentario = reader.IsDBNull(reader.GetOrdinal("comentario")) ? null : reader.GetString(reader.GetOrdinal("comentario")),
                            incotermid = reader.IsDBNull(reader.GetOrdinal("incotermid")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("incotermid")),
                            listaprecioid = reader.GetInt32(reader.GetOrdinal("listaprecioid")),
                            valormigradooriginal = reader.IsDBNull(reader.GetOrdinal("valormigradooriginal")) ? null : reader.GetString(reader.GetOrdinal("valormigradooriginal")),
                            bdtablaorigendevalormigrado = reader.IsDBNull(reader.GetOrdinal("bdtablaorigendevalormigrado")) ? null : reader.GetString(reader.GetOrdinal("bdtablaorigendevalormigrado")),
                            fechacreacionlog = reader.GetDateTimeOffset(reader.GetOrdinal("fechacreacionlog")),
                            creadoporlog = reader.GetString(reader.GetOrdinal("creadoporlog")),
                            fechamodificacionlog = reader.GetDateTimeOffset(reader.GetOrdinal("fechamodificacionlog")),
                            modificadoporlog = reader.GetString(reader.GetOrdinal("modificadoporlog")),
                            estadodefila = reader.GetString(reader.GetOrdinal("estadodefila")).FirstOrDefault(),
                        };
                        
                    }
                }
            }
            return pedido;
        }

        public async Task<bool> CreatePedido(PedidoRequest nuevoPedido)
        {
            bool respuesta = true;
            using (var con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(@"
            INSERT INTO Pedido (
                 OrigenCodigo, TipoDocumento, NumeroDocumento, EntidadId, DireccionDespacho, 
                PadreEntidadId, VendedorId, OrdenCompra, PeriodoId, PlazoPagoId, FechaDocumento, 
                FechaVencimiento, FechaEntrega, FechaDespacho, ValorNeto, ValorSeguro, ValorFlete, 
                ValorIva, ValorDescuento, ValorOtros, ValorBruto, Comentario, IncoTermId, ListaPrecioId, 
                ValorMigradoOriginal, BdTablaOrigenDeValorMigrado, FechaCreacionLog, CreadoPorLog, 
                FechaModificacionLog, ModificadoPorLog, EstadoDeFila
            ) VALUES (
                @OrigenCodigo, @TipoDocumento, @NumeroDocumento, @EntidadId, @DireccionDespacho, 
                @PadreEntidadId, @VendedorId, @OrdenCompra, @PeriodoId, @PlazoPagoId, @FechaDocumento, 
                @FechaVencimiento, @FechaEntrega, @FechaDespacho, @ValorNeto, @ValorSeguro, @ValorFlete, 
                @ValorIva, @ValorDescuento, @ValorOtros, @ValorBruto, @Comentario, @IncoTermId, @ListaPrecioId, 
                @ValorMigradoOriginal, @BdTablaOrigenDeValorMigrado, @FechaCreacionLog, @CreadoPorLog, 
                @FechaModificacionLog, @ModificadoPorLog, @EstadoDeFila
            )", con);
                cmd.Parameters.AddWithValue("@OrigenCodigo", nuevoPedido.origencodigo);
                cmd.Parameters.AddWithValue("@TipoDocumento", nuevoPedido.tipodocumento);
                cmd.Parameters.AddWithValue("@NumeroDocumento", nuevoPedido.numerodocumento);
                cmd.Parameters.AddWithValue("@EntidadId", nuevoPedido.entidadid);
                cmd.Parameters.AddWithValue("@DireccionDespacho", (object)nuevoPedido.direcciondespacho ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PadreEntidadId", nuevoPedido.padreentidadid);
                cmd.Parameters.AddWithValue("@VendedorId", (object)nuevoPedido.vendedorid ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OrdenCompra", (object)nuevoPedido.ordencompra ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PeriodoId", nuevoPedido.periodoid);
                cmd.Parameters.AddWithValue("@PlazoPagoId", nuevoPedido.plazopagoid);
                cmd.Parameters.AddWithValue("@FechaDocumento", nuevoPedido.fechadocumento);
                cmd.Parameters.AddWithValue("@FechaVencimiento", nuevoPedido.fechavencimiento);
                cmd.Parameters.AddWithValue("@FechaEntrega", (object)nuevoPedido.fechaentrega ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaDespacho", (object)nuevoPedido.fechadespacho ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ValorNeto", nuevoPedido.valorneto);
                cmd.Parameters.AddWithValue("@ValorSeguro", nuevoPedido.valorseguro);
                cmd.Parameters.AddWithValue("@ValorFlete", nuevoPedido.valorflete);
                cmd.Parameters.AddWithValue("@ValorIva", nuevoPedido.valoriva);
                cmd.Parameters.AddWithValue("@ValorDescuento", nuevoPedido.valordescuento);
                cmd.Parameters.AddWithValue("@ValorOtros", nuevoPedido.valorotros);
                cmd.Parameters.AddWithValue("@ValorBruto", nuevoPedido.valorbruto);
                cmd.Parameters.AddWithValue("@Comentario", (object)nuevoPedido.comentario ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IncoTermId", (object)nuevoPedido.incotermid ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ListaPrecioId", nuevoPedido.listaprecioid);
                cmd.Parameters.AddWithValue("@ValorMigradoOriginal", (object)nuevoPedido.valormigradooriginal ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BdTablaOrigenDeValorMigrado", (object)nuevoPedido.bdtablaorigendevalormigrado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaCreacionLog", nuevoPedido.fechacreacionlog);
                cmd.Parameters.AddWithValue("@CreadoPorLog", nuevoPedido.creadoporlog);
                cmd.Parameters.AddWithValue("@FechaModificacionLog", nuevoPedido.fechamodificacionlog);
                cmd.Parameters.AddWithValue("@ModificadoPorLog", nuevoPedido.modificadoporlog);
                cmd.Parameters.AddWithValue("@EstadoDeFila", nuevoPedido.estadodefila);
                try
                {
                    await con.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;

                }
                catch
                {
                    respuesta = false;
                }
                return respuesta;
            }
        }
        
        public async Task<bool> ActualizarPedido(Pedido pedidoActualizado)
        {
            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("UPDATE Pedido SET OrigenCodigo = @OrigenCodigo, TipoDocumento = @TipoDocumento, NumeroDocumento = @NumeroDocumento, EntidadId = @EntidadId, DireccionDespacho = @DireccionDespacho, PadreEntidadId = @PadreEntidadId, VendedorId = @VendedorId, OrdenCompra = @OrdenCompra, PeriodoId = @PeriodoId, PlazoPagoId = @PlazoPagoId, FechaDocumento = @FechaDocumento, FechaVencimiento = @FechaVencimiento, FechaEntrega = @FechaEntrega, FechaDespacho = @FechaDespacho, ValorNeto = @ValorNeto, ValorSeguro = @ValorSeguro, ValorFlete = @ValorFlete, ValorIva = @ValorIva, ValorDescuento = @ValorDescuento, ValorOtros = @ValorOtros, ValorBruto = @ValorBruto, Comentario = @Comentario, IncoTermId = @IncoTermId, ListaPrecioId = @ListaPrecioId, ValorMigradoOriginal = @ValorMigradoOriginal, BdTablaOrigenDeValorMigrado = @BdTablaOrigenDeValorMigrado, FechaModificacionLog = @FechaModificacionLog, ModificadoPorLog = @ModificadoPorLog, EstadoDeFila = @EstadoDeFila WHERE PedidoId = @PedidoId", con);

                cmd.Parameters.AddWithValue("@PedidoId", pedidoActualizado.pedidoid);
                cmd.Parameters.AddWithValue("@OrigenCodigo", pedidoActualizado.origencodigo);
                cmd.Parameters.AddWithValue("@TipoDocumento", pedidoActualizado.tipodocumento);
                cmd.Parameters.AddWithValue("@NumeroDocumento", pedidoActualizado.numerodocumento);
                cmd.Parameters.AddWithValue("@EntidadId", pedidoActualizado.entidadid);
                cmd.Parameters.AddWithValue("@DireccionDespacho", (object)pedidoActualizado.direcciondespacho ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PadreEntidadId", pedidoActualizado.padreentidadid);
                cmd.Parameters.AddWithValue("@VendedorId", (object)pedidoActualizado.vendedorid ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OrdenCompra", (object)pedidoActualizado.ordencompra ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PeriodoId", pedidoActualizado.periodoid);
                cmd.Parameters.AddWithValue("@PlazoPagoId", pedidoActualizado.plazopagoid);
                cmd.Parameters.AddWithValue("@FechaDocumento", pedidoActualizado.fechadocumento);
                cmd.Parameters.AddWithValue("@FechaVencimiento", pedidoActualizado.fechavencimiento);
                cmd.Parameters.AddWithValue("@FechaEntrega", (object)pedidoActualizado.fechaentrega ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaDespacho", (object)pedidoActualizado.fechadespacho ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ValorNeto", pedidoActualizado.valorneto);
                cmd.Parameters.AddWithValue("@ValorSeguro", pedidoActualizado.valorseguro);
                cmd.Parameters.AddWithValue("@ValorFlete", pedidoActualizado.valorflete);
                cmd.Parameters.AddWithValue("@ValorIva", pedidoActualizado.valoriva);
                cmd.Parameters.AddWithValue("@ValorDescuento", pedidoActualizado.valordescuento);
                cmd.Parameters.AddWithValue("@ValorOtros", pedidoActualizado.valorotros);
                cmd.Parameters.AddWithValue("@ValorBruto", pedidoActualizado.valorbruto);
                cmd.Parameters.AddWithValue("@Comentario", (object)pedidoActualizado.comentario ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IncoTermId", (object)pedidoActualizado.incotermid ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ListaPrecioId", pedidoActualizado.listaprecioid);
                cmd.Parameters.AddWithValue("@ValorMigradoOriginal", (object)pedidoActualizado.valormigradooriginal ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BdTablaOrigenDeValorMigrado", (object)pedidoActualizado.bdtablaorigendevalormigrado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaModificacionLog", pedidoActualizado.fechamodificacionlog);
                cmd.Parameters.AddWithValue("@ModificadoPorLog", pedidoActualizado.modificadoporlog);
                cmd.Parameters.AddWithValue("@EstadoDeFila", pedidoActualizado.estadodefila);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }
        public async Task<bool> EliminarPedido(string PedidoId)
        {
            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("UPDATE Pedido SET  EstadoDeFila = 'I' WHERE PedidoId = @PedidoId", con);

                cmd.Parameters.AddWithValue("@PedidoId", PedidoId);                
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }
    }

}
