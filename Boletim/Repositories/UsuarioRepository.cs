using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Boletim;
using Boletim.Models;


namespace SistemaBoletim.Repositories
{
    public class UsuarioRepository : IDisposable
    {
        private readonly BoletimOnlineEntities5 db;
        private bool disposed = false;

        public UsuarioRepository(BoletimOnlineEntities5 context)
        {
            this.db = context;
        }
        public IEnumerable<Usuario> BuscarTodos()
        {
            return db.Usuario
           
            .ToList();
        }
        public Usuario BuscarPorId(int Cod_Administrador)
        {
            return db.Usuario.Find(Cod_Administrador);
        }
        public Usuario BuscarPorEmail(string email)
        {
            return db.Usuario
                .Where(u => u.Email == email)
              
                .FirstOrDefault();
        }
        public void Criar(Usuario usuario)
        {
            if (usuario != null)
            {
                db.Usuario.Add( usuario);
                db.SaveChanges();
            }
        }
        public void Salvar(Usuario usuario)
        {
            if (usuario!= null)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Apagar(int Cod_Administrador)
        {
             Usuario  usuario = db.Usuario.Find(Cod_Administrador);

            db.Usuario.Remove(usuario);
            db.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}