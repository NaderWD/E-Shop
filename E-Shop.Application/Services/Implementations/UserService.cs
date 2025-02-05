using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Services.Security;
using E_Shop.Application.Tools;
using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
using E_Shop.Domain.ServicesModels;
using E_Shop.Domain.ViewModels;
using System.Net.Mail;
using static E_Shop.Domain.ViewModels.LoginVM;
using static E_Shop.Domain.ViewModels.RegisterVM;

namespace E_Shop.Application.Services.Implementations
{
    public class UserService(IUserRepository repository) : IUserService
    {
        private readonly IUserRepository _repository = repository;

    

        public async Task<User> GetByEmail(string email)
        {
            var myEmail = email.Trim().ToLower();
            return await _repository.GetUserByEmail(myEmail);
        }

        public async Task<LoginResult> Login(LoginVM login)
        {
            var email = login.EmailAddress.Trim().ToLower();
            var user = await _repository.GetUserByEmail(email);

            if (user == null) return LoginResult.UserNotFound;

            string hashPassword = login.Password.Trim().EncodePasswordMd5();

            if (login.Password != hashPassword) return LoginResult.Error;

            return LoginResult.Success;
        }

        public async Task<RegisterResult> Register(RegisterVM register)

        {

            await _repository.RegisterUser(register);
            return RegisterResult.Success;
        }



        public async Task<string> SetActivationCode(ForgetPasswordVM model)
        {
            var user = await _repository.GetUserByEmail(model.EmailAddress);
            var activationCode = ActiveCodeGenerator.GenerateRandomCode(6);
            user.ActivationCode = activationCode;
            _repository.UpdateUser(user);
            _repository.Save();
            return activationCode;
        }

        public void SendVerificationEmail(Email email)
        {
            MailMessage mail = new();
            SmtpClient SmtpServer = new("smtp.gmail.com");
            mail.From = new MailAddress("Toplearn@gmail.com", "EShop");
            mail.To.Add(email.To);
            mail.Subject = email.Subject;
            var message = email.Body;
            mail.Body = $"{message}\n\nYour activation code is: {SetActivationCode}";
            mail.IsBodyHtml = true;

            SmtpServer.Port = 587;
            //SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("Toplearn@gmail.com", "******");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}
