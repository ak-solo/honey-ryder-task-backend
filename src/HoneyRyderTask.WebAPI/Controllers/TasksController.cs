using HoneyRyderTask.UseCase.Services.Tasks.RegisterTask;
using HoneyRyderTask.WebAPI.Models.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HoneyRyderTask.WebAPI.Controllers
{
    /// <summary>
    /// タスク - controller
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TasksController : Controller
    {
        private readonly RegisterTaskUseCase registerTaskUseCase = default!;

        /// <summary>
        /// タスク - controller
        /// </summary>
        /// <param name="registerTaskUseCase">タスク登録ユースケース</param>
        public TasksController(RegisterTaskUseCase registerTaskUseCase)
        {
            this.registerTaskUseCase = registerTaskUseCase;
        }

        /// <summary>
        /// タスクを登録します。
        /// </summary>
        /// <param name="request">タスク作成に必要な情報を指定します。</param>
        [HttpPost]
        [MapToApiVersion("1.0")]
        public void RegisterTask([FromBody] RegisterTaskRequest request)
        {
            var command = request.ToCommand();
            this.registerTaskUseCase.Execute(command);
        }
    }
}
