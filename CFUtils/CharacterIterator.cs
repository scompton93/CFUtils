using System;
namespace CFUtils
{

	public interface CharacterIterator : ICloneable
	{
		object MemberwiseClone();

		char current();

		char first();

		int getBeginIndex();

		int getEndIndex();

		int getIndex();

		char last();

		char next();

		char previous();

		char setIndex(int idx);
	}

}
