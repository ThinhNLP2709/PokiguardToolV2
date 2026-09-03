/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

// Image 42: UnityEngine.MathematicsModule.dll - Assembly: UnityEngine.MathematicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15208-15250

namespace Unity.Mathematics
{
	[Serializable]
	[Il2CppEagerStaticClassConstruction]
	public struct Random // TypeDefIndex: 15243
	{
		// Fields
		public uint state; // 0x00
	
		// Constructors
		public Random(uint seed); // 0x00000001822B3650-0x00000001822B3670
	
		// Methods
		public int NextInt(int min, int max); // 0x00000001822B3600-0x00000001822B3630
		private uint NextState(); // 0x00000001822B3630-0x00000001822B3650
	}
}
