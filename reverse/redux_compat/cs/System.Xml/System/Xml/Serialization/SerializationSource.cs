/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	internal abstract class SerializationSource // TypeDefIndex: 6925
	{
		// Fields
		private Type[] includedTypes; // 0x10
		private string namspace; // 0x18
		private bool canBeGenerated; // 0x20
	
		// Constructors
		public SerializationSource(string namspace, Type[] includedTypes); // 0x0000000181A8D010-0x0000000181A8D070
	
		// Methods
		protected bool BaseEquals(SerializationSource other); // 0x0000000181A8CF00-0x0000000181A8D010
	}
}
