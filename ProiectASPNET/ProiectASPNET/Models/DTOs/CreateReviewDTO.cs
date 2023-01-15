﻿namespace ProiectASPNET.Models.DTOs
{
    public class CreateReviewDTO
    {
        public string HeadLine { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
