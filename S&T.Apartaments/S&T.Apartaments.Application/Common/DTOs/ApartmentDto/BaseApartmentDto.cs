using S_T.Apartaments.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Application.Common.DTOs.ApartmentDto
{
    public class BaseApartmentDto
    {
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public ApartmentSize Size { get; set; }
        public ApartmentStatus Status { get; set; }
    }
}
