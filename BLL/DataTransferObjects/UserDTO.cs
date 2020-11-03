using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    public class UserDTO
    {
        public int Id { get; set; }
        // not null unique
        public string NickName { get; set; }
        public ICollection<MistakeDTO> Mistakes { get; set; }
        public ICollection<TopicDTO> Topics { get; set; }
        public UserDTO()
        {
            Mistakes = new List<MistakeDTO>();
            Topics = new List<TopicDTO>();
        }
    }
}
