using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    public class TopicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastPlayed { get; set; }
        public ICollection<WordDTO> Words { get; set; }
        public UserDTO User { get; set; }

        public TopicDTO()
        {
            Words = new List<WordDTO>();
        }
    }
}
