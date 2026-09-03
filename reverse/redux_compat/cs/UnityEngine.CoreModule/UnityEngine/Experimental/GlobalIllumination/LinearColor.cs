/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Experimental.GlobalIllumination
{
	public struct LinearColor // TypeDefIndex: 8212
	{
		// Fields
		private float m_red; // 0x00
		private float m_green; // 0x04
		private float m_blue; // 0x08
		private float m_intensity; // 0x0C
	
		// Properties
		public float red { get; set; } // 0x000000018035C780-0x000000018035C790 0x000000018224A9F0-0x000000018224AAB0
		public float green { get; set; } // 0x000000018035C790-0x000000018035C7A0 0x000000018224A880-0x000000018224A940
		public float blue { get; set; } // 0x00000001802DB050-0x00000001802DB060 0x000000018224A7C0-0x000000018224A880
		public float intensity { get; set; } // 0x00000001802DB040-0x00000001802DB050 0x000000018224A940-0x000000018224A9F0
	
		// Methods
		public static LinearColor Convert(Color color, float intensity); // 0x000000018224A450-0x000000018224A7C0
		public static LinearColor Black(); // 0x000000018224A440-0x000000018224A450
	}
}
