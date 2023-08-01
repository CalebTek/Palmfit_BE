using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Palmfit.Core.Helpers;

namespace Palmfit.Core.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly PalmfitDbContext _palmfitDbContext;

        public AuthRepository(IConfiguration configuration, PalmfitDbContext palmfitDbContext)
        {
            _configuration = configuration;
            _palmfitDbContext = palmfitDbContext;
        }

        public string GenerateJwtToken(AppUser user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Set a default expiration in minutes if "AccessTokenExpiration" is missing or not a valid numeric value.
            if (!double.TryParse(jwtSettings["AccessTokenExpiration"], out double accessTokenExpirationMinutes))
            {
                accessTokenExpirationMinutes = 30; // Default expiration of 30 minutes.
            }

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(accessTokenExpirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        public string SendOTPByEmail(string email)
        {
            try
            {
                //generating otp
                var generateRan = new RandomNumberGenerator();
                var otp = generateRan.GenerateOTP();


                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(EmailSettings.SmtpUsername);
                    mailMessage.To.Add(email);
                    mailMessage.Subject = "One Time Password(OTP)";
                    mailMessage.Body = $"Your OTP:{otp}";

                    using (SmtpClient smtpClient = new SmtpClient(EmailSettings.SmtpServer, EmailSettings.SmtpPort))
                    {
                        smtpClient.EnableSsl = true;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(EmailSettings.SmtpUsername, EmailSettings.SmtpPassword);
                        smtpClient.Send(mailMessage);
                    }
                }

                // saving otp
                var userOTP = new UserOTP
                {
                    Email = email,
                    OTP = otp,
                    Expiration = DateTime.UtcNow.AddMinutes(10) // set an expiration time for OTP (e.g 5 minutes)
                };
                _palmfitDbContext.UserOTPs.Add(userOTP);
                _palmfitDbContext.SaveChanges();

                return $"OTP sent to {email}";
            }
            catch (Exception ex)
            {
                return $"Faild To Send OTP to {email}, Error, {ex.Message}";
            }
        }





    }
}
