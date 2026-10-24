
using System;
using System.ComponentModel.DataAnnotations;

namespace FeedbackManagement.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a subject.")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a rating.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Please enter your feedback.")]
        [StringLength(500, MinimumLength = 10,
            ErrorMessage = "Feedback must be between 10 and 500 characters.")]
        public string Message { get; set; } = string.Empty;

        public DateTime SubmittedOn { get; set; } = DateTime.Now;
    }
}
