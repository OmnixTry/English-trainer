using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    interface IExerciseDTO
    {
        public string Title { get; }
        public IEnumerable<IProblemDTO> Problems { get; internal set; }
    }
}
