using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lind.Test.FileExplorer.Core
{
    public class Folder
    {
        public string Name { get; set; } = null!;
        public ICollection<FileName> Files { get; set; } = [];
    }
    public class FileName
    {
        public string Name { get; set; } = null!;
    }
}
