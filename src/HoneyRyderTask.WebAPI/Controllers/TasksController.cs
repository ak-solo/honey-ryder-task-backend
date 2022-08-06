using HoneyRyderTask.UseCase.Services.Tasks.GetTask;
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
        private readonly GetTaskUseCase getTaskUseCase;
        private readonly RegisterTaskUseCase registerTaskUseCase;

        /// <summary>
        /// タスク - controller
        /// </summary>
        /// <param name="getTaskUseCase">タスク取得ユースケース</param>
        /// <param name="registerTaskUseCase">タスク登録ユースケース</param>
        public TasksController(
            GetTaskUseCase getTaskUseCase,
            RegisterTaskUseCase registerTaskUseCase)
        {
            this.getTaskUseCase = getTaskUseCase;
            this.registerTaskUseCase = registerTaskUseCase;
        }

        /// <summary>
        /// タスクを取得します。
        /// </summary>
        /// <param name="taskId">タスクID</param>
        /// <returns>タスク</returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public TaskResponseModel GetTask(string taskId)
        {
            var task = this.getTaskUseCase.Execute(taskId);
            return TaskResponseModel.FromTaskDto(task);
        }

        /// <summary>
        /// タスクを登録します。
        /// </summary>
        /// <param name="request">タスク作成に必要な情報を指定します。</param>
        [HttpPost]
        [MapToApiVersion("1.0")]
        public void RegisterTask([FromBody] RegisterTaskRequestModel request)
        {
            var command = request.ToCommand();
            this.registerTaskUseCase.Execute(command);
        }
    }
}
