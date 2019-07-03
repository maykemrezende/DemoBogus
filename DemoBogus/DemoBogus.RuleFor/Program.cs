using Bogus;
using DemoBogus.Model;
using System;
using System.Collections.Generic;

namespace DemoBogus.RuleFor
{
    class Program
    {
        static void Main(string[] args)
        {
            CriaUserFakePopulate();
        }


        private static void CriaUserFake()
        {
            var fakeLoginFactory = new Faker<Login>("pt_BR")
                .RuleFor(u => u.Usuario, f => f.Internet.UserName("en"))
                .RuleFor(u => u.UsuariosAntigos, f => CriaListaUsernameFake(5))
                .RuleFor(u => u.SenhasAntigas, f => CriaListaSenhaFake(5))
                ;

            var fakeUserFactory = new Faker<User>("pt_BR")
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

            var user = fakeUserFactory.Generate().AsJson();

            Console.WriteLine(user);
            Console.ReadKey();
        }

        private static void CriaUserFakeRules()
        {
            var fakeLoginFactory = new Faker<Login>()
                .RuleFor(u => u.Usuario, f => f.Internet.UserName())
                .RuleFor(u => u.UsuariosAntigos, f => CriaListaUsernameFake(5));

            var fakeUserFactory = new Faker<User>()
                .Rules((f, u) =>
            {
                u.Id = f.Random.Number(1, 100);
                u.Nome = f.Name.FirstName();
                u.SobrenomeBogus = f.Name.LastName();
                u.NomeCompletoContexto = $"{u.Nome} {u.SobrenomeBogus}";
                u.NomeCompleto = f.Name.FullName();
                u.Sexo = f.PickRandom<SexoEnum>();
                u.Email = f.Internet.Email();
                u.ImagemPerfil = f.Internet.Avatar();
                u.Guid = Guid.NewGuid().ToString();
                u.CPF = u.GeraCPF();
                u.Login = fakeLoginFactory.Generate();
            })
                .FinishWith((f, u) => Console.WriteLine("Usuário criado: Id {0}", u.Id));

            var user = fakeUserFactory.Generate().AsJson();

            Console.WriteLine(user);
            Console.ReadKey();
        }

        private static void CriaUserFakePopulate()
        {
            var fakeLoginFactory = new Faker<Login>("pt_BR")
                .RuleFor(u => u.Usuario, f => f.Internet.UserName("en"))
                .RuleFor(u => u.UsuariosAntigos, f => CriaListaUsernameFake(5))
                .RuleFor(u => u.SenhasAntigas, f => CriaListaSenhaFake(5))
                ;

            var fakeUserFactory = new Faker<User>("pt_BR")
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
                .RuleSet("nomeFeminino", f => f.RuleFor(u => u.Nome, fa => fa.Name.FirstName(Bogus.DataSets.Name.Gender.Female)))
                .RuleSet("nome", f => f.Rules((fa, u) => {
                    u.Nome = fa.Name.FirstName(Bogus.DataSets.Name.Gender.Female);
                    u.Email = fa.Internet.Email(new Bogus.DataSets.Name().FirstName());
                                                         }))
                .FinishWith((f, u) => Console.WriteLine("Usuário criado: Id {0}", u.Id))
                ;

            var user = new User();
            fakeUserFactory.Populate(user, "nome");

            Console.WriteLine(user.AsJson());
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
