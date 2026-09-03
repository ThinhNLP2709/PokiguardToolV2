/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Mono.Math
{
	internal class BigInteger // TypeDefIndex: 2137
	{
		// Fields
		private uint length; // 0x10
		private uint[] data; // 0x18
		internal static readonly uint[] smallPrimes; // 0x00
		private static RandomNumberGenerator rng; // 0x08
	
		// Properties
		private static RandomNumberGenerator Rng { get; } // 0x0000000181443620-0x00000001814436C0 
	
		// Nested types
		public enum Sign // TypeDefIndex: 2138
		{
			Negative = -1,
			Zero = 0,
			Positive = 1
		}
	
		internal sealed class ModulusRing // TypeDefIndex: 2139
		{
			// Fields
			private BigInteger mod; // 0x10
			private BigInteger constant; // 0x18
	
			// Constructors
			public ModulusRing(BigInteger modulus); // 0x000000018144C870-0x000000018144C9D0
	
			// Methods
			public void BarrettReduction(BigInteger x); // 0x000000018144BE10-0x000000018144C290
			public BigInteger Multiply(BigInteger a, BigInteger b); // 0x000000018144C450-0x000000018144C670
			public BigInteger Difference(BigInteger a, BigInteger b); // 0x000000018144C290-0x000000018144C450
			public BigInteger Pow(BigInteger a, BigInteger k); // 0x000000018144C670-0x000000018144C7F0
			public BigInteger Pow(uint b, BigInteger exp); // 0x000000018144C7F0-0x000000018144C870
		}
	
		private sealed class Kernel // TypeDefIndex: 2140
		{
			// Methods
			public static BigInteger Subtract(BigInteger big, BigInteger small); // 0x0000000181447D20-0x0000000181447F30
			public static void MinusEq(BigInteger big, BigInteger small); // 0x000000018141F520-0x000000018141F640
			public static void PlusEq(BigInteger bi1, BigInteger bi2); // 0x000000018141F8A0-0x000000018141FA60
			public static Sign Compare(BigInteger bi1, BigInteger bi2); // 0x000000018141EE80-0x000000018141EFD0
			public static uint SingleByteDivideInPlace(BigInteger n, uint d); // 0x000000018141FCA0-0x000000018141FD50
			public static uint DwordMod(BigInteger n, uint d); // 0x000000018141DC10-0x000000018141DC70
			public static BigInteger[] DwordDivMod(BigInteger n, uint d); // 0x0000000181447410-0x0000000181447680
			public static BigInteger[] multiByteDivide(BigInteger bi1, BigInteger bi2); // 0x0000000181448940-0x0000000181449120
			public static BigInteger LeftShift(BigInteger bi, int n); // 0x0000000181447680-0x0000000181447960
			public static BigInteger RightShift(BigInteger bi, int n); // 0x0000000181447AE0-0x0000000181447D20
			public static BigInteger MultiplyByDword(BigInteger n, uint f); // 0x0000000181447960-0x0000000181447AE0
			public static void Multiply(uint[] x, uint xOffset, uint xLen, uint[] y, uint yOffset, uint yLen, uint[] d, uint dOffset); // 0x000000018141F780-0x000000018141F8A0
			public static void MultiplyMod2p32pmod(uint[] x, int xOffset, int xLen, uint[] y, int yOffest, int yLen, uint[] d, int dOffset, int mod); // 0x000000018141F640-0x000000018141F780
			public static uint modInverse(BigInteger bi, uint modulus); // 0x0000000181448820-0x0000000181448940
			public static BigInteger modInverse(BigInteger bi, BigInteger modulus); // 0x0000000181447F30-0x0000000181448820
		}
	
		// Constructors
		public BigInteger(Sign sign, uint len); // 0x0000000181443220-0x0000000181443290
		public BigInteger(BigInteger bi); // 0x0000000181443290-0x0000000181443380
		public BigInteger(BigInteger bi, uint len); // 0x0000000181443150-0x0000000181443220
		public BigInteger(byte[] inData); // 0x0000000181443380-0x0000000181443620
		public BigInteger(uint ui); // 0x00000001814430C0-0x0000000181443150
		static BigInteger(); // 0x0000000181443030-0x00000001814430C0
	
		// Methods
		public static implicit operator BigInteger(uint value); // 0x0000000181443830-0x0000000181443890
		public static implicit operator BigInteger(int value); // 0x0000000181443790-0x0000000181443830
		public static BigInteger operator -(BigInteger bi1, BigInteger bi2); // 0x0000000181443D90-0x0000000181444040
		public static uint operator %(BigInteger bi, uint ui); // 0x000000018141DC10-0x000000018141DC70
		public static BigInteger operator %(BigInteger bi1, BigInteger bi2); // 0x0000000181443940-0x0000000181443970
		public static BigInteger operator /(BigInteger bi1, BigInteger bi2); // 0x00000001814436C0-0x00000001814436F0
		public static BigInteger operator *(BigInteger bi1, BigInteger bi2); // 0x0000000181443AA0-0x0000000181443D80
		public static BigInteger operator *(BigInteger bi, int i); // 0x0000000181443970-0x0000000181443AA0
		public static BigInteger operator <<(BigInteger bi1, int shiftVal); // 0x0000000181443930-0x0000000181443940
		public static BigInteger operator >>(BigInteger bi1, int shiftVal); // 0x0000000181443D80-0x0000000181443D90
		public static BigInteger GenerateRandom(int bits, RandomNumberGenerator rng); // 0x00000001814420A0-0x0000000181442290
		public static BigInteger GenerateRandom(int bits); // 0x0000000181442040-0x00000001814420A0
		public void Randomize(RandomNumberGenerator rng); // 0x0000000181442870-0x0000000181442AA0
		public void Randomize(); // 0x0000000181442AA0-0x0000000181442B00
		public int BitCount(); // 0x000000018141C1A0-0x000000018141C250
		public bool TestBit(uint bitNum); // 0x0000000181442B00-0x0000000181442B40
		public bool TestBit(int bitNum); // 0x0000000181442B40-0x0000000181442BE0
		public void SetBit(uint bitNum); // 0x000000018141CBD0-0x000000018141CC20
		public void SetBit(uint bitNum, bool value); // 0x000000018141CC20-0x000000018141CC80
		public int LowestSetBit(); // 0x00000001814426E0-0x00000001814427D0
		public byte[] GetBytes(); // 0x0000000181442290-0x0000000181442460
		public static bool operator ==(BigInteger bi1, uint ui); // 0x000000018141D810-0x000000018141D890
		public static bool operator !=(BigInteger bi1, uint ui); // 0x000000018141DB10-0x000000018141DB90
		public static bool operator ==(BigInteger bi1, BigInteger bi2); // 0x00000001814436F0-0x0000000181443790
		public static bool operator !=(BigInteger bi1, BigInteger bi2); // 0x0000000181443890-0x0000000181443930
		public static bool operator >(BigInteger bi1, BigInteger bi2); // 0x000000018141D950-0x000000018141D970
		public static bool operator <(BigInteger bi1, BigInteger bi2); // 0x000000018141DBC0-0x000000018141DBE0
		public static bool operator >=(BigInteger bi1, BigInteger bi2); // 0x000000018141D930-0x000000018141D950
		public static bool operator <=(BigInteger bi1, BigInteger bi2); // 0x000000018141DBA0-0x000000018141DBC0
		public string ToString(uint radix); // 0x0000000181442BE0-0x0000000181442C30
		public string ToString(uint radix, string characterSet); // 0x0000000181442C80-0x0000000181443030
		private void Normalize(); // 0x000000018141CB80-0x000000018141CBD0
		public void Clear(); // 0x000000018141C250-0x000000018141C2B0
		public override int GetHashCode(); // 0x000000018141C910-0x000000018141C950
		public override string ToString(); // 0x0000000181442C30-0x0000000181442C80
		public override bool Equals(object o); // 0x0000000181441E80-0x0000000181441FD0
		public BigInteger ModInverse(BigInteger modulus); // 0x00000001814427D0-0x00000001814427E0
		public BigInteger ModPow(BigInteger exp, BigInteger n); // 0x00000001814427E0-0x0000000181442870
		public bool IsProbablePrime(); // 0x0000000181442460-0x00000001814426E0
		public static BigInteger GeneratePseudoPrime(int bits); // 0x0000000181441FD0-0x0000000181442040
		public void Incr2(); // 0x000000018141C950-0x000000018141C9F0
	}
}
