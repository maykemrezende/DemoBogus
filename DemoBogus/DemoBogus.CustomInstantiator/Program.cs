using Bogus;
using DemoBogus.Model;
using System;

namespace DemoBogus.CustomInstantiator
{
    class Program
    {
        static void Main(string[] args)
        {
            CriaUserFakeCustomInstantiatorGenerate5();
        }

        private static void CriaUserFakeCustomInstantiator()
        {
            var fakeUserFactory = new Faker<User>()
                .CustomInstantiator(f => new User(f.Name.FirstName(), 
                                                  f.Name.FullName()));

            var user = fakeUserFactory.Generate().AsJson();

            Console.WriteLine(user);
            Console.ReadKey();
        }

        private static void CriaUserFakeCustomInstantiatorGenerate5()
        {
            var fakeUserFactory = new Faker<User>()
                .CustomInstantiator(f => new User(f.Name.FirstName(),
                                                  f.Name.FullName()));

            var user = fakeUserFactory.Generate(5);

            foreach (var u in user)
            {
                Console.WriteLine(u.AsJson());
            }

            Console.ReadKey();
        }

        private static void CriaUserFakeCustomInstantiatorGenerateForever()
        {
            var fakeUserFactory = new Faker<User>()
                .CustomInstantiator(f => new User(f.Name.FirstName(),
                                                  f.Name.FullName()));

            var user = fakeUserFactory.GenerateForever();

            foreach (var u in user)
            {
                Console.WriteLine(u.AsJson());
            }
            Console.ReadKey();
        }

        private static void CriaUserFakeCustomInstantiatorGenerateLazy()
        {
            var fakeUserFactory = new Faker<User>()
                .CustomInstantiator(f => new User(f.Name.FirstName(),
                                                  f.Name.FullName()));

            var user = fakeUserFactory.GenerateLazy(5);

            foreach (var u in user)
            {
                Console.WriteLine(u.AsJson());
            }
            Console.ReadKey();
        }
    }
}
