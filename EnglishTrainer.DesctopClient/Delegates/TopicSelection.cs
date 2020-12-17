using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishTrainer.DesctopClient.Delegates
{
    public enum Language
    {
        Ukrainian,
        English
    }

    public delegate void TopicSelection(int topicId, Language language);
}
