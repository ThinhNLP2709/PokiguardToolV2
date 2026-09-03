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
	public class ArgumentOutOfRangeException : ArgumentException // TypeDefIndex: 2209
	{
		// Fields
		private object _actualValue; // 0x98
	
		// Properties
		public override string Message { get; } // 0x000000018155CEE0-0x000000018155D000 
	
		// Constructors
		public ArgumentOutOfRangeException(); // 0x000000018155CDD0-0x000000018155CE20
		public ArgumentOutOfRangeException(string paramName); // 0x000000018155CE20-0x000000018155CE90
		public ArgumentOutOfRangeException(string paramName, string message); // 0x000000018155CE90-0x000000018155CEE0
		public ArgumentOutOfRangeException(string paramName, object actualValue, string message); // 0x000000018155CC50-0x000000018155CCC0
		protected ArgumentOutOfRangeException(SerializationInfo info, StreamingContext context); // 0x000000018155CCC0-0x000000018155CDD0
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018155CB20-0x000000018155CC50
	}
}
