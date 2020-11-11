using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    public class MistakeDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public int WordId { get; set; }
        public WordDTO Word { get; set; }
        public Language Language { get; set; }
    }
}
