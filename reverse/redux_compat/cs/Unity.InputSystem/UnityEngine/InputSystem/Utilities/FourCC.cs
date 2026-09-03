/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	public struct FourCC : IEquatable<UnityEngine.InputSystem.Utilities.FourCC> // TypeDefIndex: 6599
	{
		// Fields
		private int m_Code; // 0x00
	
		// Constructors
		public FourCC(int code); // 0x0000000180732D50-0x0000000180732D60
		public FourCC(char a, char b = ' ' /* Metadata: 0x006991A6 */, char c = ' ' /* Metadata: 0x006991A8 */, char d = ' ' /* Metadata: 0x006991AA */); // 0x0000000181CE7060-0x0000000181CE7090
		public FourCC(string str); // 0x0000000181CE6EC0-0x0000000181CE7060
	
		// Methods
		public static implicit operator int(FourCC fourCC); // 0x0000000180815D70-0x0000000180815D80
		public static implicit operator FourCC(int i); // 0x0000000180815D70-0x0000000180815D80
		public override string ToString(); // 0x0000000181CE6CA0-0x0000000181CE6EC0
		public bool Equals(FourCC other); // 0x00000001815FCAB0-0x00000001815FCAC0
		public override bool Equals(object obj); // 0x0000000181CE6C20-0x0000000181CE6CA0
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
		public static bool operator ==(FourCC left, FourCC right); // 0x0000000180A2DD00-0x0000000180A2DD10
		public static bool operator !=(FourCC left, FourCC right); // 0x0000000181CA6840-0x0000000181CA6850
		public static FourCC FromInt32(int i); // 0x0000000180815D70-0x0000000180815D80
		public static int ToInt32(FourCC fourCC); // 0x0000000180815D70-0x0000000180815D80
	}
}
