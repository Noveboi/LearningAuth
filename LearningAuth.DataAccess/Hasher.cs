using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LearningAuth.DataAccess;

internal static class Hasher
{
	internal static byte[] Hash(string plaintext) => MD5.HashData(Encoding.UTF8.GetBytes(plaintext));
}
