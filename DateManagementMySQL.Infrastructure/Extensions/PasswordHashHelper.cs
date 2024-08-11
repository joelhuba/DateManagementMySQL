using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace transversal_layer_back.Infrastructure.Helpers
{
    public static class PasswordHashHelper
    {
        //encripta la contraseña
        public static (string hash, string salt) HashPassword(string password)
        {
            byte[] salt = GetSecureSalt();

            using (var hasher = new Argon2id(Encoding.UTF8.GetBytes(password)))
            {
                hasher.Salt = salt;
                hasher.DegreeOfParallelism = 8;
                hasher.MemorySize = 65536;
                hasher.Iterations = 4;

                string hash = Convert.ToBase64String(hasher.GetBytes(32));
                string saltAsString = Convert.ToBase64String(salt);
                return (hash, saltAsString);
            }
        }

        //verifica que si la contraseña que provee el usuario coincide con la de la base de datos
        private static byte[] GetSecureSalt(int saltSize = 16)
        {
            byte[] salt = new byte[saltSize];
            RandomNumberGenerator.Fill(salt);
            return salt;
        }

        public static bool VerifyPassword(string password, string storedHash, byte[] storedSalt)
        {
            using (var hasher = new Argon2id(Encoding.UTF8.GetBytes(password)))
            {
                hasher.Salt = storedSalt;
                hasher.DegreeOfParallelism = 8;
                hasher.MemorySize = 65536;
                hasher.Iterations = 4;

                string newHash = Convert.ToBase64String(hasher.GetBytes(32));
                return newHash == storedHash;
            }
        }

    }
}
