﻿using System.ComponentModel.DataAnnotations;

namespace Store.Domain.Entities
{
    public abstract class BaseEntity
    {
        //private List<Notification>? _notifications;

        [Key]
        public Guid Id { get; set; }
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        private DateTime _createAt;

        public DateTime CreateAt
        {
            get { return _createAt; }
            set => _createAt = DateTime.UtcNow;
        }

        private DateTime? _updateAt;

        public DateTime? UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }

        //public abstract bool Validate();


        //[NotMapped]
        //public IReadOnlyCollection<Notification>? Notifications => _notifications;

        //protected void SetNotifications(List<Notification> notifications)
        //{
        //    _notifications = notifications;
        //}
    }
}
