﻿namespace LifeInFocus.Business.Notificacoes
{
    public class Notification
    {
        public string? Message { get; set; }

        public Notification(string message)
        {
            Message = message;
        }
    }
}
