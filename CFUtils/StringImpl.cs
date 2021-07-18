using System;
using System.Globalization;
using System.Text;

namespace CFUtils
{
    public static class StringImpl
    {
        public static sbyte[] getBytes(string input)
        {
            return (sbyte[])(Object)Encoding.UTF8.GetBytes(input);
        }

        public static string valueOf(char ch)
        {
            int num = 1;
            if (num >= 0)
            {
                char[] array = new char[num];
                array[0] = ch;
                char[] charArray = array;
                return new string(charArray, 0, 1);
            }
            throw new ApplicationException("num less than 0");
        }

        public static char charAt(string mrString, int index)
        {
            return mrString[index];
        }
        public static bool equals(string mrString, object obj)
        {
            return mrString.Equals(obj);
        }
		public static int hashCode(string mrString)
		{
			int num = 0;
			int length = mrString.Length;
			if (length <= 15)
			{
				int num2 = 1;
				for (int i = length - 1; i >= 0; i += -1)
				{
					num += (int)mrString[i] * num2;
					num2 *= 37;
				}
			}
			else
			{
				int num3 = length / 8;
				int num4 = length / num3;
				if (length % num3 != 0)
				{
					num4++;
				}
				int num5 = 1;
				for (int j = num4 - 1; j >= 0; j += -1)
				{
					num += (int)mrString[j * num3] * num5;
					num5 *= 39;
				}
			}
			return num;
		}
		public static int length(string mrString)
		{
			return mrString.Length;
		}
		public static void getChars(string mrString, int srcOffset, int srcEnd, char[] dst, int dstOffset)
		{
			mrString.CopyTo(srcOffset, dst, dstOffset, srcEnd - srcOffset);
		}
		public static string toLowerCase(string mrString)
		{
			return mrString.ToLower(
                CultureInfo.CurrentCulture);
		}
		public static string trim(string mrString)
		{
			int length = mrString.Length;
			int num = 0;
			int num2 = length;
			while (num < num2 && (int)mrString[num] <= 32)
			{
				num++;
			}
			while (num < num2 && (int)mrString[num2 - 1] <= 32)
			{
				num2 += -1;
			}
			return (num <= 0 && num2 >= length) ? mrString : StringImpl.substring(mrString, num, num2);
		}
		public static string substring(string mrString, int offset, int endIndex)
		{
			string result;
	
			result = StringImpl.createString(mrString.Substring(offset, endIndex - offset));

			return result;
		}
		public static string createString(string src)
		{

			return string.Copy(src);
		}
		public static char[] toCharArray(string mrString)
		{
			int length = mrString.Length;
			if (length >= 0)
			{
				char[] array = new char[length];
				mrString.CopyTo(0, array, 0, mrString.Length);
				return array;
			}
            return new char[length];
		}
		public static string createString(sbyte[] byteArray)
		{
			return StringImpl.createString(byteArray, 0, byteArray.Length);
		}

		public static string createString(sbyte[] byteArray, int offset, int count)
		{
			return new string(GetChars(__convertToUBytes(byteArray, offset, count)));
		}
		internal static byte[] __convertToUBytes(sbyte[] byteArray, int offset, int len)
		{
			if (len >= 0)
			{
				byte[] array = new byte[len];
				Buffer.BlockCopy(byteArray, offset, array, 0, len);
				return array;
			}
			return new byte[len];
		}
		public static char[] GetChars(byte[] bytes)
		{

			return GetChars(bytes, 0, bytes.Length);
		}
		public static char[] GetChars(byte[] bytes, int index, int count)
		{
			var enc = Encoding.UTF8;
			char[] array = new char[enc.GetCharCount(bytes, index, count)];
			enc.GetChars(bytes, index, count, array, 0);
			return array;
		}

	}
}
