using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata;

namespace Patterns
{
    interface INotificator
    {
        void Send(string text);
    }

    class BaseNotificatirDecorator : INotificator
    {
        protected INotificator _notificator;

        public BaseNotificatirDecorator(INotificator n)
        {
            _notificator = n;
        }
        public virtual void Send(string text)
        {
            _notificator?.Send(text);

        }
    }

    class TelegramDecorator : BaseNotificatirDecorator
    {
        public TelegramDecorator(INotificator n) : base(n)
        {
        }
        public override void Send(string text)
        {
            base.Send(text);
            Console.WriteLine($"Sent to telegram: {text}");
        }
    }
    class SmsDecorator : BaseNotificatirDecorator
    {
        public SmsDecorator(INotificator n) : base(n)
        {
        }
        public override void Send(string text)
        {
            base.Send(text);
            Console.WriteLine($"Sent to sms: {text}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            INotificator notificator = new BaseNotificatirDecorator(null);

            bool needSms = true;
            bool needTg = true;

            if (needSms)
            {
                notificator = new SmsDecorator(notificator);
            }

            if (needTg)
            {
                notificator = new TelegramDecorator(notificator);
            }

            notificator.Send("Test");

        }
    }
}
