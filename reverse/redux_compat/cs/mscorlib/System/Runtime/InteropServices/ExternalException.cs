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

namespace System.Runtime.InteropServices
{
	[Serializable]
	public class ExternalException : SystemException // TypeDefIndex: 3116
	{
		// Properties
		public virtual int ErrorCode { get; } // 0x000000018150C180-0x000000018150C190 
	
		// Constructors
		public ExternalException(); // 0x000000018150AD90-0x000000018150ADE0
		public ExternalException(string message); // 0x000000018150C160-0x000000018150C180
		public ExternalException(string message, int errorCode); // 0x000000018150ADE0-0x000000018150AE10
		protected ExternalException(SerializationInfo info, StreamingContext context); // 0x000000018148BDC0-0x000000018148BDE0
	
		// Methods
		public override string ToString(); // 0x000000018150BF90-0x000000018150C160
	}
}
