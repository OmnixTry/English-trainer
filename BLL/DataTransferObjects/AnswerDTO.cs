using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    class AnswerDTO
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public Language Language { get; set; }
    }
}
