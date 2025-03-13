using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobStorageLibrary.Models
{
    public class BlobImage
    {
        public string Name { get; set; }
        public string Uri { get; set; }
        public long? Size { get; set; }
    }
}
