using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    class MistakeDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public int WordId { get; set; }
        public WordDTO Word { get; set; }
    }
}
