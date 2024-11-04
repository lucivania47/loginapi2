using Exo.WebApi.Contexts;
using Exo.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Exo.WebApi.Repositories
{
    public class UsuarioRepository
    {
        private readonly ExoContext _context;

        public UsuarioRepository(ExoContext context)
        {
            _context = context;
        }

        // Método para listar todos os usuários
        public IEnumerable<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        // Método para buscar um usuário por ID
        public Usuario BuscaPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        // Método para adicionar um novo usuário
        public void Adicionar(Usuario usuario)
        {
            if (usuario != null)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
        }

        // Método para atualizar um usuário existente
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioExistente = _context.Usuarios.Find(id);
            if (usuarioExistente != null && usuarioAtualizado != null)
            {
                usuarioExistente.Nome = usuarioAtualizado.Nome;
                usuarioExistente.Email = usuarioAtualizado.Email;
                usuarioExistente.Senha = usuarioAtualizado.Senha;

                // Atualizando o estado da entidade
                _context.Entry(usuarioExistente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
        }

        // Método para deletar um usuário por ID
        public void Deletar(int id)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

        // Método de login para autenticação do usuário
        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
