using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WindowsAppPubs.Models;

namespace WindowsAppPubs.AdminDatos
{
    public static class DacStore
    {
        static PubsContext ContextStore = new PubsContext();


        public static List<Store> Listar()
        {
            List<Store> lista = ContextStore.Stores.ToList();
            return lista;
        }

        public static Store TraerUno(string id)
        {
            Store storeId=ContextStore.Stores.Find(id);
            return storeId;
        }

        public static int NuevaStore(Store storeNueva)
        {
            ContextStore.Stores.Add(storeNueva);
            int filasAfectadas= ContextStore.SaveChanges();
            return filasAfectadas;
        }

        public static int ModificarStore(Store storeModificar)
        {
            Store storeDB = ContextStore.Stores.Find(storeModificar.stor_id);

            if(storeDB == null)
            {
                storeDB.stor_name = "Torreon";
                storeDB.stor_address = "Guemes 1234";
            }

            int filasAfectadas= ContextStore.SaveChanges();
            return filasAfectadas;
        }

        public static int EliminarStore(Store storeEliminar)
        {
            Store storeDb = ContextStore.Stores.Find(storeEliminar.stor_id);

            if(storeDb != null)
            {
                ContextStore.Stores.Remove(storeDb);
            }

            int filasAfectadas = ContextStore.SaveChanges();
            return filasAfectadas;
        }
    }
}
