/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class ElementIdPool // TypeDefIndex: 5023
	{
		// Fields
		private readonly Stack<ushort> m_Free; // 0x10
		private int m_HighWater; // 0x18
	
		// Constructors
		public ElementIdPool(); // 0x00000001823F8830-0x00000001823F88B0
	
		// Methods
		public bool Acquire(out ushort id); // 0x00000001823F8700-0x00000001823F87A0
		public void Release(ushort id); // 0x00000001823F87D0-0x00000001823F8830
		public void Clear(); // 0x00000001823F87A0-0x00000001823F87D0
	}
}
