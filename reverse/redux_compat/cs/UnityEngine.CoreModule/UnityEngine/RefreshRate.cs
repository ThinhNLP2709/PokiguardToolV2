/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Graphics/RefreshRate.h")]
	public struct RefreshRate : IEquatable<UnityEngine.RefreshRate>, IComparable<UnityEngine.RefreshRate> // TypeDefIndex: 7544
	{
		// Fields
		public uint numerator; // 0x00
		public uint denominator; // 0x04
	
		// Properties
		public double value { get; } // 0x00000001821BCE80-0x00000001821BCEA0 
	
		// Methods
		public bool Equals(RefreshRate other); // 0x00000001821BCC30-0x00000001821BCC70
		public int CompareTo(RefreshRate other); // 0x00000001821BCBD0-0x00000001821BCC30
		public override bool Equals(object obj); // 0x00000001821BCC70-0x00000001821BCD30
		public override int GetHashCode(); // 0x00000001821BCD60-0x00000001821BCE00
		private static uint Gcd(uint a, uint b); // 0x00000001821BCD30-0x00000001821BCD60
		public override string ToString(); // 0x00000001821BCE00-0x00000001821BCE80
	}
}
