using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WorkManagement.Entity.Dtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WorkManagement.Bll
{
    public class TokenManager
    {
        IConfiguration configuration;

        public TokenManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string CreateAccessToken(DtoLoginEmployee user)
        {
            //claim
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                new Claim("authorizationId", user.AuthorizationId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token");

            // claim rolleri
            var claimsRoleList = new List<Claim>
            {
                new Claim("role", "Admin"),
                new Claim("role", "Manager"),
                new Claim("role", "Employee")
            };

            // security key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
            // key ele gecirilmezse token elde edilse bile yeni bir token olusturulamaz.

            // sifrelenmis kimlik olusturma
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // token ayarlari
            var token = new JwtSecurityToken
            (
                issuer: configuration["Tokens:Issuer"],     // token dagitici url
                audience: configuration["Tokens:Issuer"], // erisilebilecek api'ler
                expires: DateTime.Now.AddDays(1),         // token'in omrunu ayarlar
                //expires: DateTime.Now.AddSeconds(30),         
                                                             // expires: tokenin omru 60 dakika ise ornegin 40 dk gectikten sonra token tekrar kullanilirsa omru kullanim anindan itibaren 60 dk daha uzatilir. 60 dk hic kullanilmaz ise o zaman tokenin omru sona erer.
                notBefore: DateTime.Now,    // login olmadan islem yapilamayacaktir.
                                            // notBefore: token uretildikten ne kadar sure sonra aktif olacagina karar verir.
                signingCredentials: cred,   // kimlik verdik
                claims: claimsIdentity.Claims   // claims'leri verdik   
            );

            // token olusturma sinifi ile ornek almak
            var tokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(token) };

            return tokenHandler.token;
        }
    }
}
