using S_T.Apartaments.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Application.Common.DTOs.ApartmentDto
{
    public class ApartmentDto : BaseApartmentDto
    {  
        public DateTime LastUpdated {  get; set; }
    }
}
