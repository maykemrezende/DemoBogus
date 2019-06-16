using Bogus;
using DemoBogus.Model;
using System;
using System.Collections.Generic;

namespace DemoBogus.StrictMode
{
    class Program
    {
        static void Main(string[] args)
        {
            CriaUserFakeStrictMode();
        }

        private static void CriaUserFakeStrictMode()
        {
            var user = string.Empty;

            var fakeLoginFactory = new Faker<Login>("pt_BR")
                .RuleFor(u => u.Usuario, f => f.Internet.UserName("en"))
                .RuleFor(u => u.UsuariosAntigos, f => CriaListaUsernameFake(5))
                .RuleFor(u => u.SenhasAntigas, f => CriaListaSenhaFake(5))
                ;

            var fakeUserFactory = new Faker<User>("pt_BR")
                .StrictMode(true)
                .RuleFor(u => u.Id, f => f.Random.Number(1, 100))
                .RuleFor(u => u.Nome, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.SobrenomeBogus, (f, u) => f.Name.LastName())
                .RuleFor(u => u.NomeCompletoContexto, (f, u) => $"{u.Nome} {u.SobrenomeBogus}")
                .RuleFor(u => u.NomeCompleto, (f, u) => f.Name.FullName())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email())
                .RuleFor(u => u.Sexo, (f, u) => f.PickRandom<SexoEnum>())
                .RuleFor(u => u.ImagemPerfil, (f, u) => f.Internet.Avatar())
                .RuleFor(u => u.Guid, f => Guid.NewGuid().ToString())
                .RuleFor(u => u.CPF, (f, u) => u.GeraCPF())
                .RuleFor(u => u.Login, f => fakeLoginFactory.Generate())
                .FinishWith((f, u) => Console.WriteLine("Usuário criado: Id {0}", u.Id))
                ;

            if (fakeUserFactory.Validate())
            {
                user = fakeUserFactory.Generate().AsJson();

                Console.WriteLine(user);

            } else
            {
                Console.WriteLine("Nem todas as regras foram definidas na criação do objeto.");
            }

            Console.ReadKey();
        }


        private static List<string> CriaListaUsernameFake(int quantidadeLista)
        {
            var usernamesAntigos = new List<string>();

            for (int i = 0; i < quantidadeLista; i++)
            {
                var item = new Bogus.DataSets.Internet().UserName();

                usernamesAntigos.Add(item);
            }

            return usernamesAntigos;
        }

        private static List<string> CriaListaSenhaFake(int quantidadeLista)
        {
            var senhasAntigas = new List<string>();

            for (int i = 0; i < quantidadeLista; i++)
            {
                var item = new Bogus.DataSets.Internet().Password();

                senhasAntigas.Add(item);
            }

            return senhasAntigas;
        }
    }
}
