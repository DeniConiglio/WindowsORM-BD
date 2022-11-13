using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsAppPubs.Models;

namespace WindowsAppPubs.AdminDatos
{
    public static class DacAuthor
    {
        static PubsContext Context = new PubsContext();

        public static List<Author> Listar()
        {
            List<Author> lista = Context.Authors.ToList() ;
            return lista ;
        }

        public static Author TraerUno(string id, PubsContext Context)
        {

            Author author = Context.Authors.Find(id);
            return author;

        }
        public static int AgregarAutor(Author authorNuevo)
        {
            Context.Authors.Add(authorNuevo);
            int filasAfectadas = Context.SaveChanges();
            return filasAfectadas;

        }
        public static int ModificarAutor(Author authorModificar)
        {
            Author authorDb = Context.Authors.Find(authorModificar.au_id);
            if (authorDb != null)
            {
                authorDb.au_lname = "Carlos";
                authorDb.au_fname = "Jhonson";
                authorDb.City = "Cordoba";
                authorDb.State = "CB";
            }
            int filasAfectadas = Context.SaveChanges();
            return filasAfectadas;
        }
        public static int EliminarAutor(Author authorEliminar)
        {
            Author authorDb = Context.Authors.Find(authorEliminar.au_id);
            if (authorDb != null)
            {
                Context.Authors.Remove(authorDb);
            }
            int filasAfectadas = Context.SaveChanges();
            return filasAfectadas;
        }
    }
}
