using Lind.Test.FileExplorer.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lind.Test.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileExplorerController : ControllerBase
    {
        protected string Path { get; }
        protected ILogger Logger { get; }
        protected IFileExplorer Explorer { get; }
        public FileExplorerController(IConfiguration config, ILogger<FileExplorerController> logger, IFileExplorer explorer)
        {
            Logger = logger;
            Explorer = explorer;
            Path = config["SharedFolder"] ?? throw new InvalidDataException();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Folder[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetFolders(CancellationToken token = default)
        {
            try
            {
                return Ok(await Explorer.GetFolders(Path, token));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
