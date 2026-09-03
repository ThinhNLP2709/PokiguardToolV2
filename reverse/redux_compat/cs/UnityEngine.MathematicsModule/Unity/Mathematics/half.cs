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
	public struct half : IEquatable<Unity.Mathematics.half>, IFormattable // TypeDefIndex: 15235
	{
		// Fields
		public ushort value; // 0x00
	
		// Properties
		public static float MinValue { get; } // 0x00000001822BA000-0x00000001822BA010 
	
		// Methods
		public bool Equals(half rhs); // 0x0000000181560960-0x0000000181560970
		public override bool Equals(object o); // 0x00000001822B9EA0-0x00000001822B9F00
		public override int GetHashCode(); // 0x000000018123AD30-0x000000018123AD40
		public override string ToString(); // 0x00000001822B9F00-0x00000001822B9F80
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822B9F80-0x00000001822BA000
	}
}
