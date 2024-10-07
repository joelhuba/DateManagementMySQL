using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateManagementMySQL.Core.DTOS
{
    public class SectionDTO
    {
        public int? SectionId { get; set; }
        public string SectionName { get; set; }
        public string SectionContent { get; set; }
        public bool IsActive { get; set; }
        public string? Image { get; set; }  
    }
}
