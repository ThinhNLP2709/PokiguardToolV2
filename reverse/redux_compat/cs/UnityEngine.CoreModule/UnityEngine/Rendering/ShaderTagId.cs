/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct ShaderTagId : IEquatable<UnityEngine.Rendering.ShaderTagId> // TypeDefIndex: 8435
	{
		// Fields
		public static readonly ShaderTagId none; // 0x00
		private int m_Id; // 0x00
	
		// Properties
		internal int id { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
	
		// Constructors
		public ShaderTagId(string name); // 0x0000000182269400-0x0000000182269420
	
		// Methods
		public override bool Equals(object obj); // 0x0000000182269360-0x00000001822693E0
		public bool Equals(ShaderTagId other); // 0x00000001815FCAB0-0x00000001815FCAC0
		public override int GetHashCode(); // 0x00000001822693E0-0x0000000182269400
		public static bool operator ==(ShaderTagId tag1, ShaderTagId tag2); // 0x0000000180A2DD00-0x0000000180A2DD10
		public static bool operator !=(ShaderTagId tag1, ShaderTagId tag2); // 0x0000000181CA6840-0x0000000181CA6850
	}
}
