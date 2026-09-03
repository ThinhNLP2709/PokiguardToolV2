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
	[ComVisible(true)]
	public class TypeLoadException : SystemException, ISerializable // TypeDefIndex: 2438
	{
		// Fields
		private string ClassName; // 0x90
		private string AssemblyName; // 0x98
		private string MessageArg; // 0xA0
		internal int ResourceId; // 0xA8
	
		// Properties
		public override string Message { get; } // 0x0000000181661250-0x0000000181661270 
	
		// Constructors
		public TypeLoadException(); // 0x0000000181661160-0x00000001816611B0
		public TypeLoadException(string message); // 0x0000000181661130-0x0000000181661160
		private TypeLoadException(string className, string assemblyName); // 0x00000001816611B0-0x0000000181661250
		private TypeLoadException(string className, string assemblyName, string messageArg, int resourceId); // 0x0000000181660F10-0x0000000181660FC0
		protected TypeLoadException(SerializationInfo info, StreamingContext context); // 0x0000000181660FC0-0x0000000181661130
	
		// Methods
		private void SetMessageField(); // 0x0000000181660DE0-0x0000000181660F10
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181660C30-0x0000000181660DE0
	}
}
