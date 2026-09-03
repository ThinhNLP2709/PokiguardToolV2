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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	public class ObjectDisposedException : InvalidOperationException // TypeDefIndex: 2317
	{
		// Fields
		private string _objectName; // 0x90
	
		// Properties
		public override string Message { get; } // 0x0000000181616930-0x00000001816169E0 
		public string ObjectName { get; } // 0x00000001816169E0-0x0000000181616A10 
	
		// Constructors
		private ObjectDisposedException(); // 0x0000000181616810-0x0000000181616870
		public ObjectDisposedException(string objectName); // 0x00000001816168C0-0x0000000181616930
		public ObjectDisposedException(string objectName, string message); // 0x0000000181616870-0x00000001816168C0
		protected ObjectDisposedException(SerializationInfo info, StreamingContext context); // 0x0000000181616770-0x0000000181616810
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181616680-0x0000000181616770
	}
}
