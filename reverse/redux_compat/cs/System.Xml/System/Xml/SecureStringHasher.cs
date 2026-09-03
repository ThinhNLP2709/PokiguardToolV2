/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class SecureStringHasher : IEqualityComparer<string> // TypeDefIndex: 6731
	{
		// Fields
		private static HashCodeOfStringDelegate hashCodeDelegate; // 0x00
		private int hashCodeRandomizer; // 0x10
	
		// Nested types
		private delegate int HashCodeOfStringDelegate(string s, int sLen, long additionalEntropy); // TypeDefIndex: 6732; 0x0000000180A72B30-0x0000000180A72B50
	
		// Constructors
		public SecureStringHasher(); // 0x0000000181A36510-0x0000000181A36530
	
		// Methods
		public bool Equals(string x, string y); // 0x0000000181A36210-0x0000000181A36230
		public int GetHashCode(string key); // 0x0000000181A36450-0x0000000181A36510
		private static int GetHashCodeOfString(string key, int sLen, long additionalEntropy); // 0x0000000181A363D0-0x0000000181A36450
		private static HashCodeOfStringDelegate GetHashCodeDelegate(); // 0x0000000181A36230-0x0000000181A363D0
	}
}
