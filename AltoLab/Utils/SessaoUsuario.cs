using AltoLab.Models;

namespace AltoLab.Utils
{
    public static class SessaoUsuario
    {
        public static Usuario UsuarioLogado { get; set; }

        public static bool IsAdmin => UsuarioLogado != null && UsuarioLogado.Login.ToLower() == "admin";

        public static void EncerrarSessao()
        {
            UsuarioLogado = null;
        }
    }
}
