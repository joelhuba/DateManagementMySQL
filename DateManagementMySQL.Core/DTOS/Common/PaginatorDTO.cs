using System.ComponentModel.DataAnnotations;

namespace DateManagementMySQL.Core.DTOS.Common
{
    public class PaginatorDTO
    {
        public int? PageIndex { get; set; } = 1;

        public int? PageSize { get; set; } = 10;
    }
}
