using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using feedback.Models;
using System.Net.Mail;

namespace feedback
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent(); 
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var comment = new Comment();
            comment.FullName = name.Text;
            comment.Email = email.Text;
            comment.Opinion = opinion.Text;
            try
            {
                await App.Database.SaveCommentAsync(comment);
            }
            catch(Exception ex)
            {
                 await DisplayAlert("Ошибка",ex.Message.ToString(),"ОК");
            }


            MailMessage msg = new MailMessage();
            msg.To.Add("it@mile.by");
            msg.Subject = "Отзыв о работе магазина от " + name.Text;
            msg.From = new MailAddress(email.Text);
            msg.Body = opinion.Text;
            SmtpClient smtp = new SmtpClient("aspmx.l.google.com", 25);

            try
            {
                smtp.Send(msg);
            }
            catch(Exception ex)
            {
               await DisplayAlert("Ошибка", ex.Message,"OK");
            }

        }

        private  void OnCancelButtonClicked(object sender, EventArgs e)
        {

            name.Text = "";
            email.Text = "";
            opinion.Text = "";
        }

        
    }
}
