using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ.Models
{
    public class Usuario
    {
        private string _Nombre;
        private string _Email;
        private string _Contraseña;
        private bool _Administrador;

        public Usuario(string nombre, string email, string contraseña, bool administrador)
        {
            _Nombre = nombre;
            _Email = email;
            _Contraseña = contraseña;
            _Administrador = administrador;
        }

        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }
        public bool Administrador { get => _Administrador; set => _Administrador = value; }

        public Usuario()
        {
        }
    }
}