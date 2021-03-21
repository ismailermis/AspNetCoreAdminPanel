using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Responses
{
    public class FileResponse
    {
        public string FileType { get; set; }
        public List<FileItemInfo> FileList { get; set; }

    }
    public class FileItemInfo
    {
        public string Name { get; set; }
        public string Size { get; set; }
    }
}
