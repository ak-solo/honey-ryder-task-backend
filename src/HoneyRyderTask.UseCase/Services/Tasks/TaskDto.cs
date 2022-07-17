using Task = HoneyRyderTask.Domain.Models.Tasks.Task;

namespace HoneyRyderTask.UseCase.Services.Tasks
{
    /// <summary>
    /// タスクDTO
    /// </summary>
    /// <param name="TaskId">タスクID</param>
    /// <param name="Title">タスクタイトル</param>
    /// <param name="Description">タスク説明</param>
    /// <param name="Status">タスク状態</param>
    /// <param name="DueDate">タスク期限</param>
    /// <param name="CreationDate">タスク作成日</param>
    /// <param name="CompletionDate">タスク完了日</param>
    public record TaskDto(
        string TaskId,
        string Title,
        string Description,
        int Status,
        DateTime? DueDate,
        DateTime CreationDate,
        DateTime? CompletionDate)
    {
        /// <summary>
        /// タスクエンティティからタスクDTOを作成します。
        /// </summary>
        /// <param name="task">タスクエンティティ</param>
        /// <returns>タスクDTO</returns>
        public static TaskDto FromEntity(Task task)
        {
            return new TaskDto(
                TaskId: task.Id.Value,
                Title: task.Title.Value,
                Description: task.Description.Value,
                Status: task.Status.Value,
                DueDate: task.DueDate?.Value,
                CreationDate: task.CreationDate.Value,
                CompletionDate: task.CompletionDate?.Value);
        }
    }
}
