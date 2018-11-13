using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.RapiAuto
{
    public class DatosDeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {

            var usuarioAdmin = new Usuario();
            usuarioAdmin.Nombre = "admin";
            usuarioAdmin.Contrasena = "123";

            contexto.Usuarios.Add(usuarioAdmin);

            var tipo1 = new Tipo();
            tipo1.Descripcion = "Sedan";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Descripcion = "Pick Up";
            contexto.Tipos.Add(tipo2);

            var tipo3 = new Tipo();
            tipo3.Descripcion = "Camioneta";
            contexto.Tipos.Add(tipo3);

            var tipo4 = new Tipo();
            tipo4.Descripcion = "Van";
            contexto.Tipos.Add(tipo4);

            var tipo5 = new Tipo();
            tipo5.Descripcion = "Mini Van";
            contexto.Tipos.Add(tipo5);

            var tipo6 = new Tipo();
            tipo6.Descripcion = "Furgon";
            contexto.Tipos.Add(tipo6);

            var tipo7 = new Tipo();
            tipo7.Descripcion = "Camion";
            contexto.Tipos.Add(tipo7);

            var tipo8 = new Tipo();
            tipo8.Descripcion = "Panel";
            contexto.Tipos.Add(tipo8);

            var tipo9 = new Tipo();
            tipo9.Descripcion = "Autobus";
            contexto.Tipos.Add(tipo9);

            var tipo10 = new Tipo();
            tipo10.Descripcion = "Tractor";
            contexto.Tipos.Add(tipo10);

            var tipo11 = new Tipo();
            tipo11.Descripcion = "Otros";
            contexto.Tipos.Add(tipo11);

            var combustible1 = new Combustible();
            combustible1.Descripcion = "Diesel";
            contexto.Combustibles.Add(combustible1);

            var combustible2 = new Combustible();
            combustible2.Descripcion = "Gasolina";
            contexto.Combustibles.Add(combustible2);

            var combustible3 = new Combustible();
            combustible3.Descripcion = "Keroseno";
            contexto.Combustibles.Add(combustible3);

            var transmision1 = new Transmision();
            transmision1.Descripcion = "Manual";
            contexto.Transmisiones.Add(transmision1);

            var transmision2 = new Transmision();
            transmision2.Descripcion = "Automatico";
            contexto.Transmisiones.Add(transmision2);

            var transmision3 = new Transmision();
            transmision3.Descripcion = "Triptonica";
            contexto.Transmisiones.Add(transmision3);

            base.Seed(contexto);
        }


    }
}
