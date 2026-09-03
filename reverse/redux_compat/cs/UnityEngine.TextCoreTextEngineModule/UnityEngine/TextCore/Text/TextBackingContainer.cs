/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	internal struct TextBackingContainer // TypeDefIndex: 12696
	{
		// Fields
		private uint[] m_Array; // 0x00
		private int m_Count; // 0x08
	
		// Properties
		public int Capacity { get; } // 0x0000000180EEFE00-0x0000000180EEFE20 
		public int Count { get; set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		public uint this[int index] { get => default; set {} } // 0x00000001820D1010-0x00000001820D1040 0x0000000182335A30-0x0000000182335AE0
	
		// Constructors
		public TextBackingContainer(int size); // 0x00000001823359D0-0x0000000182335A30
	
		// Methods
		public void Resize(int size); // 0x0000000182335960-0x00000001823359D0
	}
}
