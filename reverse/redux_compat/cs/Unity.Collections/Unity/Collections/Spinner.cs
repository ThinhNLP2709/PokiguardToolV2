/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	internal struct Spinner // TypeDefIndex: 11443
	{
		// Fields
		private int m_Lock; // 0x00
	
		// Methods
		internal void Acquire(); // 0x0000000181C9F6F0-0x0000000181C9F730
		internal bool TryAcquire(); // 0x0000000181C9F750-0x0000000181C9F7A0
		internal bool TryAcquire(bool spin); // 0x0000000181C9F7A0-0x0000000181C9F830
		internal void Release(); // 0x0000000181C9F730-0x0000000181C9F750
	}
}
