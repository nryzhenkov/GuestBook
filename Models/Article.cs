using System;
using System.ComponentModel.DataAnnotations;

namespace GuestBookApp.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Пустое поле темы")]
        [StringLength(255, ErrorMessage = "Длина строки больше максимальной длины")]
        public string Theme { get; set; }
        [Required(ErrorMessage = "Пустое поле текста")]
        [StringLength(65535, ErrorMessage = "Длина строки больше максимальной длины")]
        public string Text { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
