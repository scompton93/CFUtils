using System;
using System.ComponentModel;
using System.Text;

namespace CFUtils
{
	public sealed class StringCharacterIterator : CharacterIterator
	{
		public object MemberwiseClone()
		{
			return new StringCharacterIterator(this.__text, this.__begin, this.__end, this.__pos);
		}
		public char current()
		{
			char result;
			if (this.__begin == this.__end || this.__pos == this.__end)
			{
				result = char.MaxValue;
			}
			else
			{
				result = StringImpl.charAt(this.__text, this.__pos);
			}
			return result;
		}
		public bool Equals(object obj)
		{
			StringCharacterIterator stringCharacterIterator = (StringCharacterIterator)obj;
			return StringImpl.equals(this.__text, stringCharacterIterator.__text) && this.__begin == stringCharacterIterator.__begin && this.__end == stringCharacterIterator.__end && this.__pos == stringCharacterIterator.__pos;
		}

		public char first()
		{
			this.__pos = this.getBeginIndex();
			return this.current();
		}

		public int getBeginIndex()
		{
			return this.__begin;
		}

		public int getEndIndex()
		{
			return this.__end;
		}

		public int getIndex()
		{
			return this.__pos;
		}

		public override int GetHashCode()
		{
			return StringImpl.hashCode(this.__text) + this.__begin * 31 + this.__end * 31 + this.__pos * 31;
		}

		public char last()
		{
			if (this.getEndIndex() > this.getBeginIndex())
			{
				this.__pos = this.getEndIndex() - 1;
			}
			return this.current();
		}
		public char next()
		{
			char result;
			if (this.__pos == this.getEndIndex())
			{
				result = char.MaxValue;
			}
			else
			{
				this.__pos++;
				result = this.current();
			}
			return result;
		}

		public char previous()
		{
			char result;
			if (this.__begin == this.__end || this.__pos == this.getBeginIndex())
			{
				result = char.MaxValue;
			}
			else
			{
				this.__pos += -1;
				result = this.current();
			}
			return result;
		}

		public char setIndex(int idx)
		{
			this.__pos = idx;
			return this.current();
		}

		public StringCharacterIterator(string text) : this(text, 0)
		{
		}

		public StringCharacterIterator(string text, int pos) : this(text, 0, text.Length, pos)
		{
		}

		public StringCharacterIterator(string text, int begin, int end, int pos)
		{
			this.__text = text;
			this.__begin = begin;
			this.__end = ((end != 0) ? end : text.Length);
			this.__pos = pos;
		}

		internal string __getText()
		{
			return this.__text;
		}

		public object Clone()
		{
			object result;
	
			result = this.MemberwiseClone();

			return result;
		}

		private string __text;

		private int __begin;

		private int __end;

		private int __pos;
	}
}
