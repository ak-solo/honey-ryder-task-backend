using System;
using HoneyRyderTask.Domain.Models.Shared;
using HoneyRyderTask.Domain.Models.Tasks;
using HoneyRyderTask.Domain.Services.Shared;

namespace HoneyRyderTaskTest.Builders.Domain.Models.Tasks
{
    /// <summary>
    /// Task - builder
    /// </summary>
    public record TaskBuilder
    {
        private string id = "01D0KDBRASGD5HRSNDCKA0AH53";
        private string title = "タスクタイトル";
        private string description = "タスク説明";
        private int status = TaskStatus.Completed.Value;
        private DateTime? dueDate = new DateTime(2022, 3, 31);
        private DateTime creationDate = new DateTime(2022, 1, 1);
        private DateTime? completionDate = new DateTime(2022, 4, 1);
        private IDateTimeProvider dateTimeProvider = new DefaultDateTimeProvider();

        public TaskBuilder WithId(string id)
        {
            this.id = id;
            return this;
        }

        public TaskBuilder WithTitle(string title)
        {
            this.title = title;
            return this;
        }

        public TaskBuilder WithDescription(string description)
        {
            this.description = description;
            return this;
        }

        public TaskBuilder WithStatus(int status)
        {
            this.status = status;
            return this;
        }

        public TaskBuilder WithDueDate(DateTime? dueDate)
        {
            this.dueDate = dueDate;
            return this;
        }

        public TaskBuilder WithCreationDate(DateTime creationDate)
        {
            this.creationDate = creationDate;
            return this;
        }

        public TaskBuilder WithCompletionDate(DateTime? completionDate)
        {
            this.completionDate = completionDate;
            return this;
        }

        public TaskBuilder WithDateTimeProvider(IDateTimeProvider dateTimeProvider)
        {
            this.dateTimeProvider = dateTimeProvider;
            return this;
        }

        public Task Build()
        {
            return Task.Reconstruct(
                id: TaskId.ValueOf(this.id),
                title: TaskTitle.ValueOf(this.title),
                description: TaskDescription.ValueOf(this.description),
                status: TaskStatus.ValueOf(this.status),
                dueDate: TaskDueDate.CreateNullable(this.dueDate),
                creationDate: TaskCreationDate.Create(this.creationDate),
                completionDate: TaskCompletionDate.CreateNullable(this.completionDate),
                dateTimeProvider: this.dateTimeProvider);
        }
    }
}
