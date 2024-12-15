﻿namespace Notes.Domain
{
    public class Note
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatinDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
