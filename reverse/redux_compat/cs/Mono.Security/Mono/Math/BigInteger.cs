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

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Math
{
	public class BigInteger // TypeDefIndex: 13890
	{
		// Fields
		private uint length; // 0x10
		private uint[] data; // 0x18
		internal static readonly uint[] smallPrimes; // 0x00
		private static RandomNumberGenerator rng; // 0x08
	
		// Properties
		private static RandomNumberGenerator Rng { get; } // 0x000000018141D740-0x000000018141D7E0 
	
		// Nested types
		public enum Sign // TypeDefIndex: 13891
		{
			Negative = -1,
			Zero = 0,
			Positive = 1
		}
	
		public sealed class ModulusRing // TypeDefIndex: 13892
		{
			// Fields
			private BigInteger mod; // 0x10
			private BigInteger constant; // 0x18
	
			// Constructors
			public ModulusRing(BigInteger modulus); // 0x0000000181423EF0-0x0000000181424050
	
			// Methods
			public void BarrettReduction(BigInteger x); // 0x0000000181423490-0x0000000181423910
			public BigInteger Multiply(BigInteger a, BigInteger b); // 0x0000000181423AD0-0x0000000181423CF0
			public BigInteger Difference(BigInteger a, BigInteger b); // 0x0000000181423910-0x0000000181423AD0
			public BigInteger Pow(BigInteger a, BigInteger k); // 0x0000000181423D70-0x0000000181423EF0
			[CLSCompliant(false)]
			public BigInteger Pow(uint b, BigInteger exp); // 0x0000000181423CF0-0x0000000181423D70
		}
	
		private sealed class Kernel // TypeDefIndex: 13893
		{
			// Methods
			public static BigInteger Subtract(BigInteger big, BigInteger small); // 0x000000018141FD50-0x000000018141FF60
			public static void MinusEq(BigInteger big, BigInteger small); // 0x000000018141F520-0x000000018141F640
			public static void PlusEq(BigInteger bi1, BigInteger bi2); // 0x000000018141F8A0-0x000000018141FA60
			public static Sign Compare(BigInteger bi1, BigInteger bi2); // 0x000000018141EE80-0x000000018141EFD0
			public static uint SingleByteDivideInPlace(BigInteger n, uint d); // 0x000000018141FCA0-0x000000018141FD50
			public static uint DwordMod(BigInteger n, uint d); // 0x000000018141DC10-0x000000018141DC70
			public static BigInteger[] DwordDivMod(BigInteger n, uint d); // 0x000000018141EFD0-0x000000018141F240
			public static BigInteger[] multiByteDivide(BigInteger bi1, BigInteger bi2); // 0x0000000181420970-0x0000000181421150
			public static BigInteger LeftShift(BigInteger bi, int n); // 0x000000018141F240-0x000000018141F520
			public static BigInteger RightShift(BigInteger bi, int n); // 0x000000018141FA60-0x000000018141FCA0
			public static void Multiply(uint[] x, uint xOffset, uint xLen, uint[] y, uint yOffset, uint yLen, uint[] d, uint dOffset); // 0x000000018141F780-0x000000018141F8A0
			public static void MultiplyMod2p32pmod(uint[] x, int xOffset, int xLen, uint[] y, int yOffest, int yLen, uint[] d, int dOffset, int mod); // 0x000000018141F640-0x000000018141F780
			public static uint modInverse(BigInteger bi, uint modulus); // 0x000000018141FF60-0x0000000181420080
			public static BigInteger modInverse(BigInteger bi, BigInteger modulus); // 0x0000000181420080-0x0000000181420970
		}
	
		// Constructors
		[CLSCompliant(false)]
		public BigInteger(Sign sign, uint len); // 0x000000018141D2D0-0x000000018141D340
		public BigInteger(BigInteger bi); // 0x000000018141D1E0-0x000000018141D2D0
		[CLSCompliant(false)]
		public BigInteger(BigInteger bi, uint len); // 0x000000018141D670-0x000000018141D740
		public BigInteger(byte[] inData); // 0x000000018141D340-0x000000018141D5E0
		[CLSCompliant(false)]
		public BigInteger(uint ui); // 0x000000018141D5E0-0x000000018141D670
		static BigInteger(); // 0x000000018141D150-0x000000018141D1E0
	
		// Methods
		[CLSCompliant(false)]
		public static implicit operator BigInteger(uint value); // 0x000000018141D970-0x000000018141D9D0
		public static implicit operator BigInteger(int value); // 0x000000018141D9D0-0x000000018141DA70
		public static BigInteger operator -(BigInteger bi1, BigInteger bi2); // 0x000000018141DF60-0x000000018141E210
		[CLSCompliant(false)]
		public static uint operator %(BigInteger bi, uint ui); // 0x000000018141DC10-0x000000018141DC70
		public static BigInteger operator %(BigInteger bi1, BigInteger bi2); // 0x000000018141DBE0-0x000000018141DC10
		public static BigInteger operator /(BigInteger bi1, BigInteger bi2); // 0x000000018141D7E0-0x000000018141D810
		public static BigInteger operator *(BigInteger bi1, BigInteger bi2); // 0x000000018141DC70-0x000000018141DF50
		public static BigInteger operator <<(BigInteger bi1, int shiftVal); // 0x000000018141DB90-0x000000018141DBA0
		public static BigInteger operator >>(BigInteger bi1, int shiftVal); // 0x000000018141DF50-0x000000018141DF60
		public static BigInteger GenerateRandom(int bits, RandomNumberGenerator rng); // 0x000000018141C470-0x000000018141C660
		public static BigInteger GenerateRandom(int bits); // 0x000000018141C660-0x000000018141C740
		public int BitCount(); // 0x000000018141C1A0-0x000000018141C250
		public bool TestBit(int bitNum); // 0x000000018141CC80-0x000000018141CD20
		[CLSCompliant(false)]
		public void SetBit(uint bitNum); // 0x000000018141CBD0-0x000000018141CC20
		[CLSCompliant(false)]
		public void SetBit(uint bitNum, bool value); // 0x000000018141CC20-0x000000018141CC80
		public int LowestSetBit(); // 0x000000018141C9F0-0x000000018141CAE0
		public byte[] GetBytes(); // 0x000000018141C740-0x000000018141C910
		[CLSCompliant(false)]
		public static bool operator ==(BigInteger bi1, uint ui); // 0x000000018141D810-0x000000018141D890
		[CLSCompliant(false)]
		public static bool operator !=(BigInteger bi1, uint ui); // 0x000000018141DB10-0x000000018141DB90
		public static bool operator ==(BigInteger bi1, BigInteger bi2); // 0x000000018141D890-0x000000018141D930
		public static bool operator !=(BigInteger bi1, BigInteger bi2); // 0x000000018141DA70-0x000000018141DB10
		public static bool operator >(BigInteger bi1, BigInteger bi2); // 0x000000018141D950-0x000000018141D970
		public static bool operator <(BigInteger bi1, BigInteger bi2); // 0x000000018141DBC0-0x000000018141DBE0
		public static bool operator >=(BigInteger bi1, BigInteger bi2); // 0x000000018141D930-0x000000018141D950
		public static bool operator <=(BigInteger bi1, BigInteger bi2); // 0x000000018141DBA0-0x000000018141DBC0
		[CLSCompliant(false)]
		public string ToString(uint radix); // 0x000000018141D0B0-0x000000018141D100
		[CLSCompliant(false)]
		public string ToString(uint radix, string characterSet); // 0x000000018141CD20-0x000000018141D0B0
		private void Normalize(); // 0x000000018141CB80-0x000000018141CBD0
		public void Clear(); // 0x000000018141C250-0x000000018141C2B0
		public override int GetHashCode(); // 0x000000018141C910-0x000000018141C950
		public override string ToString(); // 0x000000018141D100-0x000000018141D150
		public override bool Equals(object o); // 0x000000018141C2B0-0x000000018141C400
		public BigInteger ModInverse(BigInteger modulus); // 0x000000018141CAE0-0x000000018141CAF0
		public BigInteger ModPow(BigInteger exp, BigInteger n); // 0x000000018141CAF0-0x000000018141CB80
		public static BigInteger GeneratePseudoPrime(int bits); // 0x000000018141C400-0x000000018141C470
		public void Incr2(); // 0x000000018141C950-0x000000018141C9F0
	}
}
