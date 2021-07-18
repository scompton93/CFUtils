using System;
using System.Text;

namespace CFUtils
{
    public class StringBuffer
    {
		public StringBuffer()
		{
			this.__builder = new StringBuilder();
		}

		public virtual StringBuffer append(string str)
		{
			if (str == null)
			{
				str = "NULL";
			}
			this.__builder.Append(str);
			return this;
		}
		internal StringBuilder __builder;
	}
}
