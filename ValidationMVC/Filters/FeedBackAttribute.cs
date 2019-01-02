﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using ValidationMVC.Models;

namespace ValidationMVC.Filters
{
    public class FeedBackAttribute : ValidationAttribute
    {
        private readonly ServerValidation_Db _db = new ServerValidation_Db();
        //Получение данных для отправки письма
        private readonly SmtpSection _smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
        public override bool IsValid(object value)
        {
            if (value is Feedback feedback)
            {
                MessageTheme complaintsAndSuggestions =
                    _db.MessageThemes.FirstOrDefault(f => f.ThemeName.Contains("Жалобы и предложения"));
                if (complaintsAndSuggestions?.MessageThemeId == feedback.MessageThemeId)
                {
                    SendMessage.SendMessageAsync(new MailAddress(_smtpSection.Network.UserName, _smtpSection.From), new MailAddress(feedback.Email), feedback.Question, "Отправка жалоб и предложений", _smtpSection.Network.Host, _smtpSection.Network.Port, _smtpSection.Network.UserName, _smtpSection.Network.Password);
                    SendMessage.SendMessageAsync(new MailAddress(_smtpSection.Network.UserName, _smtpSection.From), new MailAddress("gersen.e.a@gmail.com"), feedback.Question, "Отправка жалоб и предложений", _smtpSection.Network.Host, _smtpSection.Network.Port, _smtpSection.Network.UserName, _smtpSection.Network.Password);
                    SendMessage.SendMessageAsync(new MailAddress(_smtpSection.Network.UserName, _smtpSection.From), new MailAddress("anastasya.0702@mail.ru"), feedback.Question, "Отправка жалоб и предложений", _smtpSection.Network.Host, _smtpSection.Network.Port, _smtpSection.Network.UserName, _smtpSection.Network.Password);
                    return true;
                }

                if (string.IsNullOrEmpty(feedback.Name))
                {
                    ErrorMessage = $"Поле Name должно быть заполнено.";
                    return false;
                }

                return true;
            }
            else
            {
                ErrorMessage = "Не удалось преобразоват объект к типу \'Feedback\'";
                return false;

            }

        }
    }
}