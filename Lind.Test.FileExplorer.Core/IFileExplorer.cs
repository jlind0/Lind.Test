using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lind.Test.FileExplorer.Core
{
    public interface IFileExplorer
    {
        Task<Folder[]> GetFolders(string path, CancellationToken token = default);
    }
}
