﻿using HoneyRyderTask.Domain.Models.Shared;
using HoneyRyderTask.Domain.Services.Shared;

namespace HoneyRyderTask.Domain.Models.Tasks
{
    /// <summary>
    /// タスク - entity
    /// </summary>
    public class Task
    {
        private Task(
            TaskId id,
            TaskTitle title,
            TaskDescription description,
            TaskStatus status,
            TaskDueDate? dueDate,
            TaskCreatedDate createdDate,
            TaskCompletedDate? completedDate)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.DueDate = dueDate;
            this.Status = status;
            this.CreatedDate = createdDate;
            this.CompletedDate = completedDate;
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
        public TaskCreatedDate CreatedDate { get; private set; }

        /// <summary>
        /// タスク完了日
        /// </summary>
        public TaskCompletedDate? CompletedDate { get; private set; }

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
                createdDate: TaskCreatedDate.CreateWithCurrentDate(dateTimeProvider),
                completedDate: null);
        }

        /// <summary>
        /// タスクを再構築します。
        /// </summary>
        /// <param name="id">タスクID</param>
        /// <param name="title">タスクタイトル</param>
        /// <param name="description">タスク説明</param>
        /// <param name="status">タスク状態</param>
        /// <param name="dueDate">タスク期限</param>
        /// <param name="createdDate">タスク作成日</param>
        /// <param name="completedDate">タスク完了日</param>
        /// <returns>タスク</returns>
        public static Task Reconstruct(
            TaskId id,
            TaskTitle title,
            TaskDescription description,
            TaskStatus status,
            TaskDueDate? dueDate,
            TaskCreatedDate createdDate,
            TaskCompletedDate? completedDate)
        {
            return new Task(
                id,
                title,
                description,
                status,
                dueDate,
                createdDate,
                completedDate);
        }
    }
}
