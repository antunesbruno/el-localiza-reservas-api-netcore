using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace el.localiza.reservas.api.netcore.Domain.Extensions
{
	[ExcludeFromCodeCoverage]
	public class CriptografiaService
    {
		public static string Create(string value, string salt)
		{
			var valueBytes = KeyDerivation.Pbkdf2(
								password: value,
								salt: Encoding.UTF8.GetBytes(salt),
								prf: KeyDerivationPrf.HMACSHA512,
								iterationCount: 10000,
								numBytesRequested: 256 / 8);

			return Convert.ToBase64String(valueBytes);
		}

		public static bool Validate(string value, string salt, string hash)
			=> Create(value, salt) == hash;
	}

	public class Salt
	{
		//salt usado para geração das senhas (quando nao se quer usar o random)
		public const string SALT_DEFAULT = "localiza@reservas#el";

		/// <summary>
		/// Cria o SALT dinamicamente
		/// </summary>
		/// <returns></returns>
		public static string Create()
		{
			byte[] randomBytes = new byte[128 / 8];
			using (var generator = RandomNumberGenerator.Create())
			{
				generator.GetBytes(randomBytes);
				return Convert.ToBase64String(randomBytes);
			}
		}
	}
}
