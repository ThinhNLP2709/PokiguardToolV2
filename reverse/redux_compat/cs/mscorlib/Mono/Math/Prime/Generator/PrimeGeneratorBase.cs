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
using Mono.Math.Prime;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Mono.Math.Prime.Generator
{
	internal abstract class PrimeGeneratorBase // TypeDefIndex: 2144
	{
		// Properties
		public virtual ConfidenceFactor Confidence { get; } // 0x0000000180476390-0x00000001804763A0 
		public virtual PrimalityTest PrimalityTest { get; } // 0x000000018144E360-0x000000018144E4A0 
		public virtual int TrialDivisionBounds { get; } // 0x0000000181426600-0x0000000181426610 
	
		// Constructors
		protected PrimeGeneratorBase(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract BigInteger GenerateNewPrime(int bits);
	}
}
