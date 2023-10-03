using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Dto
{
    public class FileToDataBaseDto
    {
        public Guid Id { get; set; }

        public string ImageTitle { get; set; }
        public string [] ImageData { get; set; }
        public Guid? RealEstateID { get; set; }
    }
}
