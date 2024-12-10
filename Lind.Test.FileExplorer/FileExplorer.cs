using Lind.Test.FileExplorer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Lind.Test.FileExplorer
{
    public class FileExplorer : IFileExplorer
    {
        protected ILogger Logger { get; }
        public FileExplorer(ILogger<FileExplorer> logger)
        {
            Logger = logger;
        }
        public Task<Folder[]> GetFolders(string path, CancellationToken token = default)
        {
            try
            {
                Folder folder = new Folder() { Name = path };

                foreach(var file in Directory.GetFiles(path))
                {
                    folder.Files.Add(new FileName()
                    {
                        Name = file
                    });
                }
                return Task.FromResult(new Folder[] { folder });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
