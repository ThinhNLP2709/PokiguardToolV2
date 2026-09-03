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

namespace System.Reflection
{
	[Serializable]
	public sealed class ReflectionTypeLoadException : SystemException, ISerializable // TypeDefIndex: 3318
	{
		// Fields
		[CompilerGenerated]
		private readonly Type[] _Types_k__BackingField; // 0x90
		[CompilerGenerated]
		private readonly Exception[] _LoaderExceptions_k__BackingField; // 0x98
	
		// Properties
		public Exception[] LoaderExceptions { [CompilerGenerated] get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
		public override string Message { get; } // 0x0000000181534590-0x0000000181534690 
	
		// Constructors
		public ReflectionTypeLoadException(Type[] classes, Exception[] exceptions); // 0x0000000181534520-0x0000000181534590
		private ReflectionTypeLoadException(SerializationInfo info, StreamingContext context); // 0x0000000181534400-0x0000000181534520
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181534210-0x0000000181534300
		public override string ToString(); // 0x0000000181534300-0x0000000181534400
		private string CreateString(bool isMessage); // 0x00000001815340E0-0x0000000181534210
	}
}
