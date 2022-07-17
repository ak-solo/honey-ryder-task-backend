using System.ComponentModel.DataAnnotations;
using HoneyRyderTask.UseCase.Services.Tasks.RegisterTask;

namespace HoneyRyderTask.WebAPI.Models.Tasks
{
    /// <summary>
    /// タスク登録リクエスト
    /// </summary>
    public class RegisterTaskRequestModel
    {
        /// <summary>
        /// タスクタイトル
        /// </summary>
        [Required]
        public string? Title { get; set; }

        /// <summary>
        /// タスク説明
        /// </summary>
        [Required]
        public string? Description { get; set; }

        /// <summary>
        /// タスク期限
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// CRegisterTaskCommandに変換します。
        /// </summary>
        /// <returns>コマンド</returns>
        public RegisterTaskCommand ToCommand()
        {
            if (this.Title == null) throw new Exception();
            if (this.Description == null) throw new Exception();

            return new RegisterTaskCommand(
                Title: this.Title,
                Description: this.Description,
                DueDate: this.DueDate);
        }
    }
}
