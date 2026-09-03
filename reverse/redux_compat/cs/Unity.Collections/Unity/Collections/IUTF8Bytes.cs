/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	public interface IUTF8Bytes // TypeDefIndex: 11541
	{
		// Properties
		bool IsEmpty { get; }
	
		// Methods
		byte* GetUnsafePtr();
		bool TryResize(int newLength, NativeArrayOptions clearOptions = NativeArrayOptions.ClearMemory /* Metadata: 0x006A1C07 */);
	}
}
