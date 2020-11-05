using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    class WordTranslationExercise : IExerciseDTO
    {
        internal int TopicId { get; set; }

        public string Title  { get; }

        IEnumerable<IProblemDTO> IExerciseDTO.Problems { get; set; }
    }
}
