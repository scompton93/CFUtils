using System;
using CFUtils;

public class Transformer
{
	public virtual sbyte[] transformString(string key, sbyte[] inBytes)
	{
		this.setKey(key);
		int num = inBytes.Length;
		int num2 = num;
		if (num2 >= 0)
		{
			sbyte[] array = new sbyte[num2];
			for (int i = 0; i < num; i++)
			{
				array[i] = this.transformByte(inBytes[i]);
			}
			return array;
		}
		return new sbyte[num2];
	}

	private sbyte transformByte(sbyte target)
	{
		sbyte b = 0;
		int num = this.m_LFSR_B & 1;
		int num2 = this.m_LFSR_C & 1;
		for (int i = 0; i < 8; i++)
		{
			if ((this.m_LFSR_A & 1) != 0)
			{
				this.m_LFSR_A = ((this.m_LFSR_A ^ (int)((uint)this.m_Mask_A >> 1)) | this.m_Rot1_A);
				if ((this.m_LFSR_B & 1) != 0)
				{
					this.m_LFSR_B = ((this.m_LFSR_B ^ (int)((uint)this.m_Mask_B >> 1)) | this.m_Rot1_B);
					num = 1;
				}
				else
				{
					this.m_LFSR_B = (int)((uint)this.m_LFSR_B >> 1 & (uint)this.m_Rot0_B);
					num = 0;
				}
			}
			else
			{
				this.m_LFSR_A = (int)((uint)this.m_LFSR_A >> 1 & (uint)this.m_Rot0_A);
				if ((this.m_LFSR_C & 1) != 0)
				{
					this.m_LFSR_C = ((this.m_LFSR_C ^ (int)((uint)this.m_Mask_C >> 1)) | this.m_Rot1_C);
					num2 = 1;
				}
				else
				{
					this.m_LFSR_C = (int)((uint)this.m_LFSR_C >> 1 & (uint)this.m_Rot0_C);
					num2 = 0;
				}
			}
			b = (sbyte)((int)b << 1 | (num ^ num2));
		}
		return (sbyte)((int)target ^ (int)b);
	}
	private void setKey(string key)
	{
		this.m_Key = key;
		string text = key;
		if (Transformer.isEmpty(text))
		{
			text = "Default Seed";
		}
		int num = (StringImpl.length(text) < 12) ? 12 : StringImpl.length(text);
		if (num >= 0)
		{
			char[] array = new char[num];
			StringImpl.getChars(this.m_Key, 0, StringImpl.length(this.m_Key), array, 0);
			int num2 = StringImpl.length(this.m_Key);
			int i = 0;
			while (num2 + i < 12)
			{
				array[num2 + i] = array[i];
				i++;
			}
			for (i = 0; i < 4; i++)
			{
				this.m_LFSR_A = ((this.m_LFSR_A <<= 8) | (int)array[i + 4]);
				this.m_LFSR_B = ((this.m_LFSR_B <<= 8) | (int)array[i + 4]);
				this.m_LFSR_C = ((this.m_LFSR_C <<= 8) | (int)array[i + 4]);
			}
			if (this.m_LFSR_A == 0)
			{
				this.m_LFSR_A = 324508639;
			}
			if (this.m_LFSR_B == 0)
			{
				this.m_LFSR_B = 610839776;
			}
			if (this.m_LFSR_C == 0)
			{
				this.m_LFSR_C = -38177487;
			}
			return;
		}

	}

	private static bool isEmpty(string text)
	{
		return text == null || StringImpl.length(text) == 0;
	}

	public Transformer()
	{
		this.m_LFSR_A = 324508639;
		this.m_LFSR_B = 610839776;
		this.m_LFSR_C = -38177487;
		this.m_Mask_A = -2147483550;
		this.m_Mask_B = 1073741856;
		this.m_Mask_C = 268435458;
		this.m_Rot0_A = int.MaxValue;
		this.m_Rot0_B = 1073741823;
		this.m_Rot0_C = 268435455;
		this.m_Rot1_A = int.MinValue;
		this.m_Rot1_B = -1073741824;
		this.m_Rot1_C = -268435456;
	}

	private string m_Key;

	private int m_LFSR_A;

	private int m_LFSR_B;

	private int m_LFSR_C;

	private int m_Mask_A;

	private int m_Mask_B;

	private int m_Mask_C;

	private int m_Rot0_A;

	private int m_Rot0_B;

	private int m_Rot0_C;

	private int m_Rot1_A;

	private int m_Rot1_B;

	private int m_Rot1_C;
}
