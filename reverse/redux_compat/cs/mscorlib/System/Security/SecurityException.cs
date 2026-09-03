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

namespace System.Security
{
	[Serializable]
	[ComVisible(true)]
	public class SecurityException : SystemException // TypeDefIndex: 2754
	{
		// Fields
		private string permissionState; // 0x90
	
		// Constructors
		public SecurityException(); // 0x0000000181483D30-0x0000000181483D80
		public SecurityException(string message); // 0x0000000181483CF0-0x0000000181483D10
		protected SecurityException(SerializationInfo info, StreamingContext context); // 0x0000000181483D80-0x0000000181483EC0
		public SecurityException(string message, Exception inner); // 0x0000000181483D10-0x0000000181483D30
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181483C50-0x0000000181483CE0
		public override string ToString(); // 0x0000000181483CE0-0x0000000181483CF0
	}
}
