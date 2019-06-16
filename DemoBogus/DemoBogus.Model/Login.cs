using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBogus.Model
{
    public class Login
    {
        public string Usuario { get; set; }
        public List<string> UsuariosAntigos { get; set; } = new List<string>();
        public List<string> SenhasAntigas { get; set; } = new List<string>();

        public Login()
        {

        }        
    }
}
