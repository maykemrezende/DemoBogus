using Bogus;
using DemoBogus.Model;
using System;
using System.Collections.Generic;

namespace DemoBogus.RuleForType
{
    class Program
    {
        static void Main(string[] args)
        {
            CriaPesoFakeForType();
        }

        private static void CriaUserFakeForType()
        {
            var fakeUserFactory = new Faker<User>()
                .RuleForType(typeof(Login),
                                f => new Login()
                                {
                                    Usuario = f.Name.FirstName(),
                                    UsuariosAntigos = CriaListaUsernameFake(2),
                                    SenhasAntigas = CriaListaSenhaFake(2)
                                })
                .Rules((f, u) =>
                {
                    u.Id = f.Random.Int(1, 100);
                    u.Nome = f.Name.FirstName();
                    u.SobrenomeBogus = f.Name.LastName();
                    u.NomeCompletoContexto = $"{u.Nome} {u.SobrenomeBogus}";
                    u.NomeCompleto = f.Name.FullName();
                    u.Email = f.Internet.Email();
                    u.Sexo = f.PickRandom<SexoEnum>();
                    u.ImagemPerfil = f.Internet.Avatar();
                    u.Guid = Guid.NewGuid().ToString();
                    u.CPF = u.GeraCPF();
                })
                .FinishWith((f, u) => Console.WriteLine("Usuário criado: Id {0}", u.Id));

            var user = fakeUserFactory.Generate().AsJson();

            Console.WriteLine(user);
            Console.ReadKey();
        }

        public static void CriaPesoFakeForType()
        {
            var fakePesoFactory = new Faker<Peso>()
                .RuleForType(typeof(decimal), f => Math.Round(f.Random.Decimal(1, 100), 2))
                .FinishWith((f, p) => Console.WriteLine("Peso criado: peso 1: {0}", p.Peso1));

            var peso = fakePesoFactory.Generate().AsJson();

            Console.WriteLine(peso);
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
