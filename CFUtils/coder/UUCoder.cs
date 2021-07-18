using System;
using System.Text;


namespace CFUtils.coder
{
	public sealed class UUCoder
	{
		private UUCoder()
		{
		}

		public static string encode(sbyte[] barr)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = barr.Length;
			int num2 = 0;
			bool flag = false;
			int num3 = 0;
			for (; ; )
			{
				int num4 = num - num2;
				if (num4 == 0)
				{
					flag = true;
				}
				sbyte b;
				if (num4 <= 45)
				{
					b = (sbyte)num4;
				}
				else
				{
					b = 45;
				}
				stringBuilder.Append(UUCoder._enc(b));
				for (int i = 0; i < (int)b; i += 3)
				{
					if (num - num3 < 3)
					{
						int num5 = 3;
						if (num5 < 0)
						{
							return stringBuilder.ToString();
						}
						sbyte[] array = new sbyte[num5];
						int num6 = 0;
						while (num3 + num6 < num)
						{
							array[num6] = barr[num3 + num6];
							num6++;
						}
						UUCoder.encodeBytes(array, 0, stringBuilder);
					}
					else
					{
						UUCoder.encodeBytes(barr, num3, stringBuilder);
					}
					num3 += 3;
				}
				stringBuilder.Append('\n');
				num2 += (int)b;
				if ((int)b < 45)
				{
					flag = true;
				}
				if (flag)
				{
					return stringBuilder.ToString();
				}
			}
		}
		public static sbyte[] decode(string str)
		{
			int num = StringImpl.length(str);

			sbyte[] array = new sbyte[num];
			int num2 = 0;
			int num3 = 0;
			bool flag = false;
			StringCharacterIterator stringCharacterIterator = new StringCharacterIterator(str);
			do
			{
				sbyte b = UUCoder._dec(stringCharacterIterator.current());
				stringCharacterIterator.next();
				if ((int)b < 45)
				{
					flag = true;
				}
				num2 += (int)b;
				while ((int)b > 0)
				{
					UUCoder.decodeChars(stringCharacterIterator, array, num3);
					num3 += 3;
					b = (sbyte)((int)b - 3);
				}
				stringCharacterIterator.next();
			}
			while (!flag);
			num = num2;
			if (num >= 0)
			{
				sbyte[] array2 = new sbyte[num];
				for (int i = 0; i < num2; i++)
				{
					array2[i] = array[i];
				}
				return array2;
			}
			return array;
		}

		private static void encodeBytes(sbyte[] @in, int off, StringBuilder @out)
		{
			@out.Append(UUCoder._enc((sbyte)((uint)((int)@in[off]) >> 2)));
			@out.Append(UUCoder._enc((sbyte)(((int)@in[off] << 4 & 48) | (int)((uint)((int)@in[off + 1]) >> 4 & 15U))));
			@out.Append(UUCoder._enc((sbyte)(((int)@in[off + 1] << 2 & 60) | (int)((uint)((int)@in[off + 2]) >> 6 & 3U))));
			@out.Append(UUCoder._enc((sbyte)((int)@in[off + 2] & 63)));
		}

		private static void decodeChars(StringCharacterIterator it, sbyte[] @out, int off)
		{
			sbyte b = UUCoder._dec(it.current());
			sbyte b2 = UUCoder._dec(it.next());
			sbyte b3 = UUCoder._dec(it.next());
			sbyte b4 = UUCoder._dec(it.next());
			it.next();
			sbyte b5 = (sbyte)((int)b << 2 | (int)b2 >> 4);
			sbyte b6 = (sbyte)((int)b2 << 4 | (int)b3 >> 2);
			sbyte b7 = (sbyte)((int)b3 << 6 | (int)b4);
			@out[off] = b5;
			@out[off + 1] = b6;
			@out[off + 2] = b7;
		}

		private static char _enc(sbyte c)
		{
			return (char)(((int)c & 63) + 32);
		}

		private static sbyte _dec(char c)
		{
			return (sbyte)((int)c - 32 & 63);
		}
	}
}
