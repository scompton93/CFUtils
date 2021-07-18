using CFUtils;
using CFUtils.coder;
using System;

namespace ColdFusion
{
	public class CFMXCompat
	{
		public static string encrypt(string plain, string key)
		{
			return CFMXCompat.encrypt(plain, key, "uu");
		}

		public static string decrypt(string encrypted, string key)
		{
			return CFMXCompat.decrypt(encrypted, key, "uu");
		}

		public static string encrypt(string plain, string key, string encoding)
		{
			Transformer transformer = new Transformer();
			string text = StringImpl.toLowerCase(encoding);
			string result;
			if (text == "uu")
			{
				result = (UUCoder.encode(transformer.transformString(key, StringImpl.getBytes(plain))));
			}
			else if (text == "hex")
			{
				result = StringImpl.trim(HexCoder.encode(transformer.transformString(key, StringImpl.getBytes(plain))));
			}

			else
			{
				result = null;
			}
			return result;
		}

		public static string decrypt(string encrypted, string key, string encoding)
		{
			Transformer transformer = new Transformer();
			string text = StringImpl.toLowerCase(encoding);
			string result;
			if (text == "uu")
			{
				result = StringImpl.createString(transformer.transformString(key, UUCoder.decode(encrypted)));
			}
			else if (text == "hex")
			{
				result = StringImpl.createString(transformer.transformString(key, HexCoder.decode(encrypted)));
			}

			else
			{
				result = null;
			}
			return result;
		}

		public const string DEFAULT_ENCODING = "uu";
		public const string UU = "uu";
		public const string HEX = "hex";
		public const string BASE64 = "base64";
	}
}
