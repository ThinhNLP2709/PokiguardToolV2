/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[IsByRefLike]
	[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
	internal struct HashFNV1A32 // TypeDefIndex: 5779
	{
		// Fields
		private const uint k_Prime = 16777619; // Metadata: 0x00661B01
		private const uint k_OffsetBasis = 2166136261; // Metadata: 0x00661B05
		private uint m_Hash; // 0x00
	
		// Properties
		public int value { get; } // 0x0000000180732D10-0x0000000180732D20 
	
		// Methods
		public static HashFNV1A32 Create(); // 0x0000000181EBF700-0x0000000181EBF710
		public void Append([IsReadOnly] in int input); // 0x0000000181EBF550-0x0000000181EBF560
		public void Append([IsReadOnly] in uint input); // 0x0000000181EBF550-0x0000000181EBF560
		public void Append([IsReadOnly] in bool input); // 0x0000000181EBF650-0x0000000181EBF670
		public void Append([IsReadOnly] in float input); // 0x0000000181EBF510-0x0000000181EBF550
		public void Append([IsReadOnly] in double input); // 0x0000000181EBF670-0x0000000181EBF6B0
		public void Append([IsReadOnly] in Vector2 input); // 0x0000000181EBF6B0-0x0000000181EBF700
		public void Append([IsReadOnly] in Vector3 input); // 0x0000000181EBF560-0x0000000181EBF5D0
		public void Append([IsReadOnly] in Vector4 input); // 0x0000000181EBF5D0-0x0000000181EBF650
		public void Append<T>(T input)
			where T : struct;
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
	}
}
