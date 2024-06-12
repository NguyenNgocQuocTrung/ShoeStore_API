using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Common
{
    public class BaseModels
    {
        public int Id { get; set;}
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
    }
}