﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishTrainer.DAL.Entities
{
    class Mistake
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; }
    }
}
