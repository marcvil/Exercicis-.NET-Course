using System;
using System.Collections.Generic;
using System.Text;
using Common.Lib.Infrastructure;
using Common.Lib;
using Common.Lib.Core;
using Common.Lib.DAL.EFCore;
using A4.Lib.Models;
using A4_DAL;
using A4.DAL.Repositories;
using A4WPFApp.DbContextFactory;

namespace A4WPFApp.AppBootstraper
{
    public class Bootstraper
    {
        public IDependencyContainer Init()
        {
            var depCon = new SimpleDependencyContainer();

            RegisterRepositories(depCon);

            Entity.DepCon = depCon;

            return depCon;
        }

        public void RegisterRepositories(IDependencyContainer depCon)
        {
            var studentRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new StudentRepository(GetDbConstructor());
            });
            var subjectRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new EfCoreRepository<Subject>(GetDbConstructor());
            });
            var examRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new EfCoreRepository<Exam>(GetDbConstructor());
            });
        }
        private static AcademyDbContext GetDbConstructor()
        {
            var factory = new AcademyDbContextFactory();
            return factory.CreateDbContext(null);
        }
    }
}
