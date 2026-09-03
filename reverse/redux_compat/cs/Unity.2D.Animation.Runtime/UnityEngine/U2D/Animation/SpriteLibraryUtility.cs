/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal static class SpriteLibraryUtility // TypeDefIndex: 14405
	{
		// Fields
		internal static Func<string, int> GetStringHash; // 0x00
	
		// Constructors
		static SpriteLibraryUtility(); // 0x0000000181C21F80-0x0000000181C22010
	
		// Methods
		internal static int Convert32BitTo30BitHash(int input); // 0x0000000181C21EC0-0x0000000181C21F10
		private static int Bit30Hash_GetStringHash(string value); // 0x0000000181C21E60-0x0000000181C21EC0
		private static int PreserveFirst30Bits(int input); // 0x0000000181C21F70-0x0000000181C21F80
		internal static long GenerateHash(); // 0x0000000181C21F10-0x0000000181C21F70
	}
}
