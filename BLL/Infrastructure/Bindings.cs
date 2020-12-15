using System;
using System.Collections.Generic;
using System.Text;
using EnglishTrainer.DAL.Interfaces;
using EnglishTrainer.DAL.Repositories;
using Ninject;
using Ninject.Modules;

namespace BLL.Infrastructure
{
    public class DALBindings : NinjectModule
    {
        private string _connectionStringName;
        
        public DALBindings(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
        }
        public override void Load()
        {
            Bind<IVocabularyUnitOfWork>().To<EFVocabularyUnitOfWork>().WithConstructorArgument(_connectionStringName);
        }
    }
}
