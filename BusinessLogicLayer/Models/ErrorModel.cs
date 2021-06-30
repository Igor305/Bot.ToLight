using System;
using Telegram.Bot;

namespace BusinessLogicLayer.Models
{
    public class ErrorModel
    {
        public string Message { get; set; }
        public DateTime Time { get; set; }
    }
}
