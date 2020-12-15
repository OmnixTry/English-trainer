using BLL.BusinessModels;
using BLL.Interfaces;
using BLL.Services;
using BLL.Infrastructure;
using EnglishTrainer.DAL.Interfaces;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishTrainer.WPFPresentationLayer.Infrastructure
{
    public class BLLBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IChecker>().To<Checker>();
            var kernel = new StandardKernel(new DALBindings("DefaultConnection"));
            Bind<ITopicService>()
                .To<TopicService>()
                .WithConstructorArgument("uow", kernel.Get<IVocabularyUnitOfWork>())
                .WithConstructorArgument("checker", new Checker());
        }
    }
}
