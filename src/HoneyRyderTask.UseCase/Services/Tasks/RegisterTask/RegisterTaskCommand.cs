using System;
using HoneyRyderTask.Domain.Models.Tasks;

namespace HoneyRyderTask.UseCase.Services.Tasks.RegisterTask
{
    /// <summary>
    /// タスク登録コマンド
    /// </summary>
    /// <param name="Title">タスクタイトル</param>
    /// <param name="Description">タスク説明</param>
    /// <param name="DueDate">タスク期限</param>
    public record RegisterTaskCommand(
        string Title,
        string Description,
        DateTime? DueDate)
    {
        /// <summary>
        /// タスク作成パラメタに変換します。
        /// </summary>
        /// <returns>タスク作成パラメタ</returns>
        public TaskCreateParam ToTaskCreateParam()
        {
            return new TaskCreateParam(
                this.Title,
                this.Description,
                this.DueDate);
        }
    }
}
