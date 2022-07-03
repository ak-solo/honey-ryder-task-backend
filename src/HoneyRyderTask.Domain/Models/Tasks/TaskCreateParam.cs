using System;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク作成パラメータ
    /// </summary>
    /// <param name="Title">タスクタイトル</param>
    /// <param name="Description">タスク説明</param>
    /// <param name="DueDate">タスク期限</param>
    public record TaskCreateParam(
        string Title,
        string Description,
        DateTime? DueDate)
    {
    }
}
