/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	[Serializable]
	public class CookieException : FormatException, ISerializable // TypeDefIndex: 9095
	{
		// Constructors
		public CookieException(); // 0x0000000181B569B0-0x0000000181B569C0
		internal CookieException(string message); // 0x0000000181B569D0-0x0000000181B569E0
		internal CookieException(string message, Exception inner); // 0x0000000181B569C0-0x0000000181B569D0
		protected CookieException(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181526520-0x0000000181526540
	
		// Methods
		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181B56990-0x0000000181B569B0
		public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181B56990-0x0000000181B569B0
	}
}
