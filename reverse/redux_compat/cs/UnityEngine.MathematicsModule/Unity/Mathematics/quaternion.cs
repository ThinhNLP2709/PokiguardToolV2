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
	public struct quaternion : IEquatable<Unity.Mathematics.quaternion>, IFormattable // TypeDefIndex: 15242
	{
		// Fields
		public float4 value; // 0x00
		public static readonly quaternion identity; // 0x00
	
		// Constructors
		public quaternion(float x, float y, float z, float w); // 0x0000000182082140-0x0000000182082160
		public quaternion(float4 value); // 0x0000000180D17CD0-0x0000000180D17CE0
		static quaternion(); // 0x00000001822BF910-0x00000001822BF930
	
		// Methods
		public static quaternion EulerXYZ(float3 xyz); // 0x00000001822BF340-0x00000001822BF4F0
		public static quaternion EulerXYZ(float x, float y, float z); // 0x00000001822BF300-0x00000001822BF340
		public bool Equals(quaternion x); // 0x000000018192E0B0-0x000000018192E0F0
		public override bool Equals(object x); // 0x000000018074E370-0x000000018074E400
		public override int GetHashCode(); // 0x00000001822B7850-0x00000001822B78A0
		public override string ToString(); // 0x00000001822BF700-0x00000001822BF910
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822BF4F0-0x00000001822BF700
	}
}
