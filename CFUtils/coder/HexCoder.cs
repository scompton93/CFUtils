using System;
using System.Text;

namespace CFUtils.coder
{
	public sealed class HexCoder
	{
		private HexCoder()
		{
		}

		public static string encode(sbyte[] bytes)
		{
			string text = "";
			string result;
			if (bytes == null || bytes.Length == 0)
			{
				result = text;
			}
			else
			{
				foreach (sbyte b in bytes)
				{
					int num = (int)b & 15;
					num += ((num >= 10) ? 55 : 48);
					int num2 = ((int)b & 240) >> 4;
					num2 += ((num2 >= 10) ? 55 : 48);
					text = new StringBuffer().append(text).append(num2.ToString()).append((num.ToString())).ToString();
				}
				result = text;
			}
			return result;
		}

		public static sbyte[] decode(string hexa)
		{
			int num = StringImpl.length(hexa) / 2;
			int num2 = num;
			if (num2 >= 0)
			{
				sbyte[] array = new sbyte[num2];
				for (int i = 0; i < num; i++)
				{
					array[i] = HexCoder.hexToByte(StringImpl.substring(hexa, i * 2, i * 2 + 2));
				}
				return array;
			}
            return new sbyte[num2];
		}

		private static sbyte hexToByte(string hexa)
		{
			UTF8Encoding utf8Encoding = new UTF8Encoding();
			byte[] bytes = new UTF8Encoding(true).GetBytes(hexa);
			sbyte[] array = (sbyte[])(Object)bytes;
			return (sbyte)(HexCoder.hexDigitValue((char)array[0]) * 16 + HexCoder.hexDigitValue((char)array[1]));
		}

		private static int hexDigitValue(char c)
		{
			int result;
			if ((int)c >= 48 && (int)c <= 57)
			{
				result = (int)((sbyte)c) - 48;
			}
			else if ((int)c >= 65 && (int)c <= 70)
			{
				result = (int)((sbyte)c) - 55;
			}
			else if ((int)c >= 97 && (int)c <= 102)
			{
				result = (int)((sbyte)c) - 87;
			}
			else
			{
				result = 0;
			}
			return result;
		}
	}
}
