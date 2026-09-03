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

namespace Unity.Profiling
{
	[IsReadOnly]
	[UsedByNativeCode]
	public struct ProfilerCategory // TypeDefIndex: 7351
	{
		// Fields
		private readonly ushort m_CategoryId; // 0x00
	
		// Properties
		public string Name { get; } // 0x0000000182191500-0x0000000182191630 
		public static ProfilerCategory Render { get; } // 0x00000001802E7860-0x00000001802E7870 
		public static ProfilerCategory Scripts { get; } // 0x0000000180472790-0x00000001804727A0 
		public static ProfilerCategory U2D { get; } // 0x0000000181AE6F60-0x0000000181AE6F70 
		public static ProfilerCategory UIToolkit { get; } // 0x0000000180A2FAD0-0x0000000180A2FAE0 
	
		// Constructors
		internal ProfilerCategory(ushort category); // 0x000000018123B250-0x000000018123B260
	
		// Methods
		public override string ToString(); // 0x0000000182191500-0x0000000182191630
		public static implicit operator ushort(ProfilerCategory category); // 0x0000000181565B10-0x0000000181565B20
	}
}
