/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal struct TextureId // TypeDefIndex: 4339
	{
		// Fields
		private readonly int m_Index; // 0x00
		public static readonly TextureId invalid; // 0x00
	
		// Properties
		public int index { get; } // 0x00000001824DD1D0-0x00000001824DD1E0 
	
		// Constructors
		public TextureId(int index); // 0x00000001824DD1C0-0x00000001824DD1D0
		static TextureId(); // 0x00000001824DD180-0x00000001824DD1C0
	
		// Methods
		public bool IsValid(); // 0x00000001824DD170-0x00000001824DD180
		public float ConvertToGpu(); // 0x00000001824DD080-0x00000001824DD0D0
		public override bool Equals(object obj); // 0x00000001824DD0D0-0x00000001824DD170
		public override int GetHashCode(); // 0x00000001814330E0-0x00000001814330F0
		public static bool operator ==(TextureId left, TextureId right); // 0x0000000180A2DD00-0x0000000180A2DD10
		public static bool operator !=(TextureId left, TextureId right); // 0x00000001824DD1E0-0x00000001824DD230
	}
}
