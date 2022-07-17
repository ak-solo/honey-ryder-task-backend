using HoneyRyderTask.UseCase.Services.Tasks;

namespace HoneyRyderTask.WebAPI.Models.Tasks
{
    /// <summary>
    /// タスク（レスポンス）
    /// </summary>
    /// <param name="TaskId">タスクID</param>
    /// <param name="Title">タスクタイトル</param>
    /// <param name="Description">タスク説明</param>
    /// <param name="Status">タスク状態</param>
    /// <param name="DueDate">タスク期限</param>
    /// <param name="CreationDate">タスク作成日</param>
    /// <param name="CompletionDate">タスク完了日</param>
    public record TaskResponseModel(
        string TaskId,
        string Title,
        string Description,
        int Status,
        DateTime? DueDate,
        DateTime CreationDate,
        DateTime? CompletionDate)
    {
        /// <summary>
        /// タスクDTOからタスク（レスポンス）を作成します。
        /// </summary>
        /// <param name="taskDto">タスクDTO</param>
        /// <returns>タスク（レスポンス）</returns>
        public static TaskResponseModel FromTaskDto(TaskDto taskDto)
        {
            return new TaskResponseModel(
                TaskId: taskDto.TaskId,
                Title: taskDto.Title,
                Description: taskDto.Description,
                Status: taskDto.Status,
                DueDate: taskDto.DueDate,
                CreationDate: taskDto.CreationDate,
                CompletionDate: taskDto.CompletionDate);
        }
    }
}
