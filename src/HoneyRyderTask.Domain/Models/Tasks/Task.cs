using HoneyRyderTask.Domain.Models.Shared;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク - entity
    /// </summary>
    public class Task
    {
        private readonly IDateTimeProvider dateTimeProvider;

        private Task(
            TaskId id,
            TaskTitle title,
            TaskDescription description,
            TaskStatus status,
            TaskDueDate? dueDate,
            TaskCreationDate creationDate,
            TaskCompletionDate? completionDate,
            IDateTimeProvider dateTimeProvider)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.DueDate = dueDate;
            this.Status = status;
            this.CreationDate = creationDate;
            this.CompletionDate = completionDate;
            this.dateTimeProvider = dateTimeProvider;
        }

        /// <summary>
        /// タスクID
        /// </summary>
        public TaskId Id { get; }

        /// <summary>
        /// タスクタイトル
        /// </summary>
        public TaskTitle Title { get; private set; }

        /// <summary>
        /// タスク説明
        /// </summary>
        public TaskDescription Description { get; private set; }

        /// <summary>
        /// タスク期限
        /// </summary>
        public TaskDueDate? DueDate { get; private set; }

        /// <summary>
        /// タスク状態
        /// </summary>
        public TaskStatus Status { get; private set; }

        /// <summary>
        /// タスク作成日
        /// </summary>
        public TaskCreationDate CreationDate { get; private set; }

        /// <summary>
        /// タスク完了日
        /// </summary>
        public TaskCompletionDate? CompletionDate { get; private set; }

        /// <summary>
        /// タスクを作成します。
        /// </summary>
        /// <param name="title">タスクタイトル</param>
        /// <param name="description">タスク説明</param>
        /// <param name="dueDate">タスク期限</param>
        /// <param name="dateTimeProvider">日付プロバイダー</param>
        /// <returns>タスク</returns>
        public static Task Create(
            TaskTitle title,
            TaskDescription description,
            TaskDueDate? dueDate,
            IDateTimeProvider dateTimeProvider)
        {
            return new Task(
                id: TaskId.NewId(),
                title,
                description,
                status: TaskStatus.NotStarted,
                dueDate,
                creationDate: TaskCreationDate.CreateWithCurrentDate(dateTimeProvider),
                completionDate: null,
                dateTimeProvider);
        }

        /// <summary>
        /// タスクを再構築します。
        /// </summary>
        /// <param name="id">タスクID</param>
        /// <param name="title">タスクタイトル</param>
        /// <param name="description">タスク説明</param>
        /// <param name="status">タスク状態</param>
        /// <param name="dueDate">タスク期限</param>
        /// <param name="creationDate">タスク作成日</param>
        /// <param name="completionDate">タスク完了日</param>
        /// <param name="dateTimeProvider">日付プロバイダー</param>
        /// <returns>タスク</returns>
        public static Task Reconstruct(
            TaskId id,
            TaskTitle title,
            TaskDescription description,
            TaskStatus status,
            TaskDueDate? dueDate,
            TaskCreationDate creationDate,
            TaskCompletionDate? completionDate,
            IDateTimeProvider dateTimeProvider)
        {
            return new Task(
                id,
                title,
                description,
                status,
                dueDate,
                creationDate,
                completionDate,
                dateTimeProvider);
        }

        /// <summary>
        /// タスク状態を変更します。
        /// </summary>
        /// <param name="status">タスク状態</param>
        public void ChangeStatus(TaskStatus status)
        {
            this.Status = status;
            if (status == TaskStatus.Completed)
            {
                this.CompletionDate = TaskCompletionDate.CreateWithCurrentDate(this.dateTimeProvider);
            }
            else
            {
                this.CompletionDate = null;
            }
        }
    }
}
