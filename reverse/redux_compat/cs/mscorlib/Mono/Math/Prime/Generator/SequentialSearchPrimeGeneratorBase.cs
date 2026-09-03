/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mono.Math;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Mono.Math.Prime.Generator
{
	internal class SequentialSearchPrimeGeneratorBase : PrimeGeneratorBase // TypeDefIndex: 2145
	{
		// Constructors
		public SequentialSearchPrimeGeneratorBase(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		protected virtual BigInteger GenerateSearchBase(int bits, object context); // 0x0000000181453720-0x00000001814537E0
		public override BigInteger GenerateNewPrime(int bits); // 0x0000000181429E80-0x0000000181429EA0
		public virtual BigInteger GenerateNewPrime(int bits, object context); // 0x0000000181453370-0x0000000181453720
		protected virtual bool IsPrimeAcceptable(BigInteger bi, object context); // 0x00000001802E7990-0x00000001802E79A0
	}
}
