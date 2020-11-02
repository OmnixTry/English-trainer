using EnglishTrainer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishTrainer.DAL.Interfaces
{
    interface IVocabularyUnitOfWork : IDisposable
    {
        IRepository<Word> Words { get; }
        IRepository<Topic> Topics { get; }
        IRepository<User> Users { get; }
        IRepository<Mistake> Mistakes { get; }
        void Save();
    }
}
