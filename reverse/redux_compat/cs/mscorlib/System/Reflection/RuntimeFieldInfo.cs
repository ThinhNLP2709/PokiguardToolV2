/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	[Serializable]
	internal class RuntimeFieldInfo : RtFieldInfo, ISerializable // TypeDefIndex: 3351
	{
		// Fields
		internal IntPtr klass; // 0x10
		internal RuntimeFieldHandle fhandle; // 0x18
		private string name; // 0x20
		private Type type; // 0x28
		private FieldAttributes attrs; // 0x30
	
		// Properties
		internal BindingFlags BindingFlags { get; } // 0x00000001802E7860-0x00000001802E7870 
		public override Module Module { get; } // 0x0000000181536200-0x0000000181536270 
		private RuntimeType ReflectedTypeInternal { get; } // 0x0000000181535C10-0x0000000181535C70 
		public override FieldAttributes Attributes { get; } // 0x000000018033D100-0x000000018033D110 
		public override RuntimeFieldHandle FieldHandle { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public override Type FieldType { get; } // 0x0000000181537040-0x00000001815370A0 
		public override Type ReflectedType { get; } // 0x00000001815370A0-0x00000001815370B0 
		public override Type DeclaringType { get; } // 0x0000000181537030-0x0000000181537040 
		public override string Name { get; } // 0x00000001802F8630-0x00000001802F8640 
		public override int MetadataToken { get; } // 0x0000000181535BF0-0x0000000181535C00 
	
		// Constructors
		public RuntimeFieldInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal RuntimeType GetDeclaringTypeInternal(); // 0x0000000181535F40-0x0000000181535FA0
		internal RuntimeModule GetRuntimeModule(); // 0x0000000181536200-0x0000000181536270
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181536760-0x00000001815368A0
		internal override object UnsafeGetValue(object obj); // 0x00000001815368C0-0x00000001815368D0
		internal override void CheckConsistency(object target); // 0x0000000181536420-0x00000001815365E0
		[DebuggerHidden]
		[DebuggerStepThrough]
		internal override void UnsafeSetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture); // 0x0000000181536FC0-0x0000000181537030
		[DebuggerHidden]
		[DebuggerStepThrough]
		public override void SetValueDirect(TypedReference obj, object value); // 0x0000000181536B10-0x0000000181536C80
		private Type ResolveType(); // 0x0000000181536B00-0x0000000181536B10
		private Type GetParentType(bool declaring); // 0x00000001815368A0-0x00000001815368B0
		public override bool IsDefined(Type attributeType, bool inherit); // 0x0000000181536A90-0x0000000181536B00
		public override object[] GetCustomAttributes(bool inherit); // 0x0000000181536680-0x00000001815366E0
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x00000001815366E0-0x0000000181536750
		internal override int GetFieldOffset(); // 0x0000000181536750-0x0000000181536760
		private object GetValueInternal(object obj); // 0x00000001815368C0-0x00000001815368D0
		public override object GetValue(object obj); // 0x00000001815368D0-0x0000000181536A90
		public override string ToString(); // 0x0000000181536F60-0x0000000181536FC0
		private static void SetValueInternal(FieldInfo fi, object obj, object value); // 0x0000000181536C80-0x0000000181536C90
		public override void SetValue(object obj, object val, BindingFlags invokeAttr, Binder binder, CultureInfo culture); // 0x0000000181536C90-0x0000000181536F60
		public override object GetRawConstantValue(); // 0x00000001815368B0-0x00000001815368C0
		public override IList<CustomAttributeData> GetCustomAttributesData(); // 0x0000000181525600-0x0000000181525650
		private void CheckGeneric(); // 0x00000001815365E0-0x0000000181536680
		internal static int get_metadata_token(RuntimeFieldInfo monoField); // 0x0000000181535BF0-0x0000000181535C00
	}
}
