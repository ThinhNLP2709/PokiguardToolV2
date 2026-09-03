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
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_Module))]
	[ComVisible(true)]
	internal class RuntimeModule : Module // TypeDefIndex: 3355
	{
		// Fields
		internal IntPtr _impl; // 0x10
		internal Assembly assembly; // 0x18
		internal string fqname; // 0x20
		internal string name; // 0x28
		internal string scopename; // 0x30
		internal bool is_resource; // 0x38
		internal int token; // 0x3C
	
		// Properties
		public override Assembly Assembly { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public override string ScopeName { get; } // 0x000000018031E110-0x000000018031E120 
		public override Guid ModuleVersionId { get; } // 0x0000000181539730-0x0000000181539760 
	
		// Constructors
		public RuntimeModule(); // 0x0000000181539700-0x0000000181539730
	
		// Methods
		public override bool IsResource(); // 0x0000000180476380-0x0000000180476390
		public override object[] GetCustomAttributes(bool inherit); // 0x0000000181539420-0x0000000181539480
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x00000001815393B0-0x0000000181539420
		public override bool IsDefined(Type attributeType, bool inherit); // 0x0000000181539690-0x0000000181539700
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181539510-0x0000000181539620
		internal RuntimeAssembly GetRuntimeAssembly(); // 0x0000000181539620-0x0000000181539690
		internal override Guid GetModuleVersionId(); // 0x0000000181539490-0x0000000181539510
		private static void GetGuidInternal(IntPtr module, byte[] guid); // 0x0000000181539480-0x0000000181539490
	}
}
