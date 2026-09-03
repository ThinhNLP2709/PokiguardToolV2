/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[NativeHeader("Modules/NativeKernel/Include/NativeKernel/Utilities/Hash128.h")]
	[NativeHeader("Runtime/Export/Hashing/Hash128.bindings.h")]
	[UsedByNativeCode]
	public struct Hash128 : IComparable, IComparable<UnityEngine.Hash128>, IEquatable<UnityEngine.Hash128> // TypeDefIndex: 7640
	{
		// Fields
		[VisibleToOtherModules(new string[2] {"UnityEditor.GraphToolkitModule", "UnityEditor.BurstModule" })]
		internal ulong u64_0; // 0x00
		[VisibleToOtherModules(new string[2] {"UnityEditor.GraphToolkitModule", "UnityEditor.BurstModule" })]
		internal ulong u64_1; // 0x08
	
		// Properties
		public bool isValid { get; } // 0x00000001821CD3B0-0x00000001821CD3D0 
	
		// Constructors
		public Hash128(ulong u64_0, ulong u64_1); // 0x0000000180C13E40-0x0000000180C13E50
	
		// Methods
		public int CompareTo(Hash128 rhs); // 0x00000001821CCC50-0x00000001821CCCA0
		public override string ToString(); // 0x00000001821CD390-0x00000001821CD3B0
		[FreeFunction("StringToHash128", IsThreadSafe = true)]
		public static Hash128 Parse(string hashString); // 0x00000001821CD090-0x00000001821CD220
		[FreeFunction("Hash128ToString", IsThreadSafe = true)]
		private static string Hash128ToStringImpl(Hash128 hash); // 0x00000001821CCF80-0x00000001821CD040
		[FreeFunction("ComputeHash128FromScriptPointer", IsThreadSafe = true)]
		private static void ComputeFromPtr(IntPtr data, int start, int count, int elemSize, ref Hash128 hash); // 0x00000001821CCCA0-0x00000001821CCD00
		public static Hash128 Compute<T>(ref ref T val)
			where T : struct;
		public static Hash128 Compute(int val); // 0x00000001821CCD00-0x00000001821CCE50
		public void Append<T>(ref ref T val)
			where T : struct;
		public void Append(int val); // 0x00000001821CCA20-0x00000001821CCB60
		public override bool Equals(object obj); // 0x00000001821CCE50-0x00000001821CCEE0
		public bool Equals(Hash128 obj); // 0x00000001821CCEE0-0x00000001821CCF00
		public override int GetHashCode(); // 0x00000001821CCF00-0x00000001821CCF30
		public int CompareTo(object obj); // 0x00000001821CCB60-0x00000001821CCC50
		public static bool operator ==(Hash128 hash1, Hash128 hash2); // 0x0000000181EA30E0-0x0000000181EA3100
		public static bool operator !=(Hash128 hash1, Hash128 hash2); // 0x00000001821CD400-0x00000001821CD430
		public static bool operator <(Hash128 x, Hash128 y); // 0x00000001821CD430-0x00000001821CD450
		public static bool operator >(Hash128 x, Hash128 y); // 0x00000001821CD3D0-0x00000001821CD400
		private void ShortHash4(uint data); // 0x00000001821CCA20-0x00000001821CCB60
		private static void ShortEnd(ref ulong h0, ref ulong h1, ref ulong h2, ref ulong h3); // 0x00000001821CD240-0x00000001821CD390
		private static void Rot64(ref ulong x, int k); // 0x00000001821CD220-0x00000001821CD240
		private static void Parse_Injected(ref ManagedSpanWrapper hashString, ); // 0x00000001821CD040-0x00000001821CD090
		private static void Hash128ToStringImpl_Injected(in Hash128 hash, ); // 0x00000001821CCF30-0x00000001821CCF80
	}
}
