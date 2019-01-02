using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace ValidationMVC.Models
{
    public class FormService
    {
        public void SendEmail(string message)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("anastasya.07022000@gmail.com", "Nastya");
            // кому отправляем
            MailAddress to = new MailAddress("anastasya.0702@mail.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "from Nastya";
            // текст письма
            m.Body = $"<h2>{message}</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("anastasya.07022000@gmail.com", "Nastenka0702");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

        public bool CreateFeedback(Feedback feedback)
        {
            using (ServerValidation_Db db = new ServerValidation_Db())
            {
                db.Feedbacks.Add(feedback);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }

        public bool CreateOrder(Sender sender)
        {
            using (ServerValidation_Db db = new ServerValidation_Db())
            {
                db.Senders.Add(sender);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }

                return true;
            }
        }

        public List<FormOfPayment> GetPaymentTypes()
        {
            using (ServerValidation_Db db = new ServerValidation_Db())
            {
                return db.FormOfPayments.ToList();
            }
        }

        public List<MessageTheme> GetMessageThemes()
        {
            using (ServerValidation_Db db = new ServerValidation_Db())
            {
                return db.MessageThemes.ToList();
            }
        }

        public List<City> GetCities()
        {
            using (ServerValidation_Db db = new ServerValidation_Db())
            {
                return db.Cities.ToList();
            }
        }
        public List<Country> GetCountries()
        {
            using (ServerValidation_Db db = new ServerValidation_Db())
            {
                return db.Countries.ToList();
            }
        }
        public List<DepartureType> GetDepartureTypes()
        {
            using (ServerValidation_Db db = new ServerValidation_Db())
            {
                return db.DepartureTypes.ToList();
            }
        }

        public bool CreateTrack(DescriptionOfGood description)
        {
            using (ServerValidation_Db db = new ServerValidation_Db())
            {
                db.DescriptionOfGoods.Add(description);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }

        public List<TariffsView> GetTariffsViews()
        {
            using (ServerValidation_Db db = new ServerValidation_Db())
            {
                return db.TariffsViews.ToList();
            }
        }
    }
}