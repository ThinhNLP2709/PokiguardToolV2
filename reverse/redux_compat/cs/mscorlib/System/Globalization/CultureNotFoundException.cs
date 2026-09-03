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

namespace System.Globalization
{
	[Serializable]
	public class CultureNotFoundException : ArgumentException // TypeDefIndex: 3392
	{
		// Fields
		private string _invalidCultureName; // 0x98
		private int? _invalidCultureId; // 0xA0
	
		// Properties
		public virtual int? InvalidCultureId { get; } // 0x00000001805B5990-0x00000001805B59A0 
		public virtual string InvalidCultureName { get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
		private static string DefaultMessage { get; } // 0x00000001815481C0-0x00000001815481F0 
		private string FormatedInvalidCultureId { get; } // 0x00000001815481F0-0x00000001815482E0 
		public override string Message { get; } // 0x00000001815482E0-0x0000000181548450 
	
		// Constructors
		public CultureNotFoundException(); // 0x0000000181547FD0-0x0000000181548010
		public CultureNotFoundException(string paramName, string message); // 0x0000000181547FB0-0x0000000181547FD0
		protected CultureNotFoundException(SerializationInfo info, StreamingContext context); // 0x0000000181548010-0x00000001815481C0
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181547E80-0x0000000181547FB0
	}
}
