namespace HoneyRyderTask.UseCase.Services.Tasks.UpdateTaskStatus
{
    /// <summary>
    /// タスク状態更新コマンド
    /// </summary>
    /// <param name="Id">タスクID</param>
    /// <param name="Status">タスク状態</param>
    public record UpdateTaskStatusCommand(string Id, int Status)
    {
    }
}
