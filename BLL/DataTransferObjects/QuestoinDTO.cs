using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    class QuestoinDTO
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Queston { get; set; }
        public Language Language { get; set; }
        public Language TranslateIntoLanguage { get; set; }
    }
}
