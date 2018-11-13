using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.RapiAuto
{
    public class ClientesBL
    {
        Contexto _contexto;
        public BindingList<Clientes> ListaClientes { get; set; }

        public ClientesBL()
        {
            _contexto = new Contexto();
            ListaClientes = new BindingList<Clientes>();
        }

        public BindingList<Clientes> ObtenerClientes()
        {
            _contexto.Clientes.Load();
            ListaClientes = _contexto.Clientes.Local.ToBindingList();
            return ListaClientes;
        }

        public void AgregarCliente()
        {
            var NuevoCliente = new Clientes();
            ListaClientes.Add(NuevoCliente);
        }

        public bool EliminarCliente(int id)
        {
            foreach (var cliente in ListaClientes)
            {
                if (cliente.Id == id)
                {
                    ListaClientes.Remove(cliente);
                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public Resultado GuardarCliente(Clientes cliente)
        {
            var resultado = Validar(cliente);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();
            resultado.Exitoso = true;
            return resultado;
        }

        private Resultado Validar(Clientes cliente)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(cliente.NombreCliente) == true)
            {
                resultado.Mensaje = "Debe ingresar un nombre";
                resultado.Exitoso = false;
            }
            if (string.IsNullOrEmpty(cliente.RtnCliente) == true)
            {
                resultado.Mensaje = "Se debe agregar RTN del cliente";
                resultado.Exitoso = false;
            }
            return resultado;
        }
    }

    public class Clientes
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string RtnCliente { get; set; }
        public string DireccionCliente { get; set; }
    }

    public class ResultadoCliente
    {
        public bool Exitoso { get; set; }
        public string Mesaje { get; set; }
    }
}
