using Newtonsoft.Json;
using System;

namespace DemoBogus.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobrenomeBogus { get; set; }
        public string NomeCompletoContexto { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public SexoEnum Sexo { get; set; }
        public string ImagemPerfil { get; set; }
        public string Guid { get; set; }
        public string CPF { get; set; }
        public Login Login { get; set; }

        public User()
        {

        }

        public User(string nome, string nomeCompleto)
        {
            Nome = nome;
            NomeCompleto = nomeCompleto;
        }


        public string GeraCPF()
        {
            return "04020635030";
        }

        public string AsJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
