/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[RequiredByNativeCode]
	public struct Resolution : IEquatable<UnityEngine.Resolution> // TypeDefIndex: 7559
	{
		// Fields
		private int m_Width; // 0x00
		private int m_Height; // 0x04
		private RefreshRate m_RefreshRate; // 0x08
	
		// Properties
		public int width { get; } // 0x0000000180732D10-0x0000000180732D20 
		public int height { get; } // 0x00000001802E7C60-0x00000001802E7DA0 
		public RefreshRate refreshRateRatio { get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
	
		// Methods
		public bool Equals(Resolution other); // 0x00000001821BF690-0x00000001821BF6E0
		public override bool Equals(object obj); // 0x00000001821BF5B0-0x00000001821BF690
		public override int GetHashCode(); // 0x00000001821BF6E0-0x00000001821BF750
		public override string ToString(); // 0x00000001821BF750-0x00000001821BF800
	}
}
