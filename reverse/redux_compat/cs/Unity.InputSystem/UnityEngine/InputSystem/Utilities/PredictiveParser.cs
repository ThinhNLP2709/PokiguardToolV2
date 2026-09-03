/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal struct PredictiveParser // TypeDefIndex: 6630
	{
		// Fields
		private int m_Position; // 0x00
	
		// Methods
		public void ExpectSingleChar(ReadOnlySpan<char> str, char c); // 0x0000000181CFC180-0x0000000181CFC270
		public int ExpectInt(ReadOnlySpan<char> str); // 0x0000000181CFC040-0x0000000181CFC180
		public ReadOnlySpan<char> ExpectString(ReadOnlySpan<char> str); // 0x0000000181CFC270-0x0000000181CFC4A0
		public bool AcceptSingleChar(ReadOnlySpan<char> str, char c); // 0x0000000181CFBEE0-0x0000000181CFBF20
		public bool AcceptString(ReadOnlySpan<char> input, out ReadOnlySpan<char> output); // 0x0000000181CFBF20-0x0000000181CFC040
		public void AcceptInt(ReadOnlySpan<char> str); // 0x0000000181CFBE80-0x0000000181CFBEE0
	}
}
