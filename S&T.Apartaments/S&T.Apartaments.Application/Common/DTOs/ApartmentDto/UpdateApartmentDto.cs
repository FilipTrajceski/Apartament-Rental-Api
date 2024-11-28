using S_T.Apartaments.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Application.Common.DTOs.ApartmentDto
{
    public class UpdateApartmentDto
    {
        public ApartmentSize Size { get; set; }
        public ApartmentStatus Status {  get; set; }
        public string ReasonForUpdate {  get; set; }

    }
}
