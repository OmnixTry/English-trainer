using EnglishTrainer.DAL.EF;
using EnglishTrainer.DAL.Entities;
using EnglishTrainer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishTrainer.DAL.Repositories
{
    class EFVocabularyUnitOfWork : IVocabularyUnitOfWork
    {
        private VocabularyContext db;
        private WordRepository wordRepository;
        private TopicRepository topicRepository;
        private UserRepository userRepository;
        private MistakeRepository mistakeRepository;
        public IRepository<Word> Words
        {
            get
            {
                if (wordRepository == null)
                    wordRepository = new WordRepository(db);
                return wordRepository;
            }
        }

        public IRepository<Topic> Topics
        {
            get
            {
                if (topicRepository == null)
                    topicRepository = new TopicRepository(db);
                return topicRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Mistake> Mistakes
        {
            get
            {
                if (mistakeRepository == null)
                    mistakeRepository = new MistakeRepository(db);
                return mistakeRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
}
