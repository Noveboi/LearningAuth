using System.Security.Cryptography;

namespace KeyService;
public static class KeyGen
{
	public static void GenerateKey()
	{
		var rsa = RSA.Create();
		var rsaKey = rsa.ExportRSAPrivateKey();

		File.WriteAllBytes("../../../../LearningAuth.API/key", rsaKey);
	}
}
