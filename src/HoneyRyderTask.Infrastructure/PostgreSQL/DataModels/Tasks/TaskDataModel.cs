using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NpgsqlTypes;

namespace HoneyRyderTask.Infrastructure.PostgreSQL.DataModels.Tasks
{
    /// <summary>
    /// タスク - data model
    /// </summary>
    [Table("tasks")]
    public class TaskDataModel
    {
        /// <summary>
        /// タスクID
        /// </summary>
        [Key]
        [Column("task_id")]
        [StringLength(Domain.Models.Tasks.TaskId.MaxLengh)]
        public string TaskId { get; set; } = default!;

        /// <summary>
        /// タスクタイトル
        /// </summary>
        [Column("title")]
        [StringLength(Domain.Models.Tasks.TaskTitle.MaxLengh)]
        public string Title { get; set; } = default!;

        /// <summary>
        /// タスク説明
        /// </summary>
        [Column("description")]
        [StringLength(Domain.Models.Tasks.TaskDescription.MaxLength)]
        public string Description { get; set; } = default!;

        /// <summary>
        /// タスク状態
        /// </summary>
        [Column("status")]
        public int Status { get; set; }

        /// <summary>
        /// タスク期限
        /// </summary>
        [Column("due_date", TypeName = nameof(NpgsqlDbType.Date))]
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// タスク作成日
        /// </summary>
        [Column("creation_date", TypeName = nameof(NpgsqlDbType.Date))]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// タスク完了日
        /// </summary>
        [Column("completion_date", TypeName = nameof(NpgsqlDbType.Date))]
        public DateTime? CompletionDate { get; set; }
    }
}
