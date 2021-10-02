using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Comment : BaseEntity
    {
        public string CommentText { get; set; }
        public int Score { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
