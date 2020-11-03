using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    public  class ProblemDTO
    {
        public string Question { get; set; }
        
        public string Answer { get; }

        public ProblemDTO(string question)
        {
            Question = question;
            Answer = null;
        }
    }
}
