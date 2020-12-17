using BLL.BusinessModels;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using EnglishTrainer.DAL.Interfaces;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainerAPI.Infrastructure
{
    public class BLLBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IChecker>().To<Checker>();
            //TODO put into config file
            var kernel = new StandardKernel(new DALBindings("Data Source=(local);Initial Catalog=Vocabulary2; Integrated Security= SSPI"));
            Bind<ITopicService>()
                .To<TopicService>()
                .WithConstructorArgument("uow", kernel.Get<IVocabularyUnitOfWork>())
                .WithConstructorArgument("checker", new Checker());
        }
    }
}
