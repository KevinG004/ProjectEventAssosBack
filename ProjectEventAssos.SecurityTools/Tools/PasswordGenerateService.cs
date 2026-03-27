using ProjectEventAssos.Core.Interfaces.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace ProjectEventAssos.SecurityTools.Tools
{
    public class PasswordGenerateService : IPasswordGenerateService
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Number = "0123456789";
        private const string Special = "@#$=~^&";
        private const string PasswordRandom = Alphabet + Number + Special;
        public string GeneratePassword(int length = 12)
        {
            List<char> chars = [];
                chars.Add(Alphabet[RandomNumberGenerator.GetInt32(Alphabet.Length)]);

                chars.Add(Number[RandomNumberGenerator.GetInt32(Number.Length)]);

                chars.Add(Special[RandomNumberGenerator.GetInt32(Special.Length)]);

            for (int i = 0; i < length - 3; i++)
            {
                chars.Add(PasswordRandom[RandomNumberGenerator.GetInt32(PasswordRandom.Length)]);
            }

            for (int i = chars.Count - 1; i > 0; i--)
            {
                int j = RandomNumberGenerator.GetInt32(i + 1);
                (chars[i], chars[j]) = (chars[j], chars[i]);
            }

            return new string(chars.ToArray());
        }
    }
}
