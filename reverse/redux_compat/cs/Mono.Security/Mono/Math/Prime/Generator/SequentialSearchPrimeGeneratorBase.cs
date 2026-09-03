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

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Math.Prime.Generator
{
	public class SequentialSearchPrimeGeneratorBase : PrimeGeneratorBase // TypeDefIndex: 13898
	{
		// Constructors
		public SequentialSearchPrimeGeneratorBase(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		protected virtual BigInteger GenerateSearchBase(int bits, object context); // 0x0000000181429EA0-0x0000000181429F20
		public override BigInteger GenerateNewPrime(int bits); // 0x0000000181429E80-0x0000000181429EA0
		public virtual BigInteger GenerateNewPrime(int bits, object context); // 0x0000000181429AD0-0x0000000181429E80
		protected virtual bool IsPrimeAcceptable(BigInteger bi, object context); // 0x00000001802E7990-0x00000001802E79A0
	}
}
