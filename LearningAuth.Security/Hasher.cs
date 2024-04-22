using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.DataAccess;

public static class Hasher
{
	public static byte[] Hash(string plaintext) => SHA256.HashData(Encoding.UTF8.GetBytes(plaintext));
}
