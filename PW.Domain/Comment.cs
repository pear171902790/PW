using System;

namespace PW.Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public Account Publisher { get; set; }
    }
}