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
	internal class RuntimeConstructorInfo : ConstructorInfo, ISerializable // TypeDefIndex: 3354
	{
		// Fields
		internal IntPtr mhandle; // 0x10
		private string name; // 0x18
		private Type reftype; // 0x20
	
		// Properties
		public override Module Module { get; } // 0x00000001815355A0-0x0000000181535610 
		internal BindingFlags BindingFlags { get; } // 0x00000001802E7860-0x00000001802E7870 
		private RuntimeType ReflectedTypeInternal { get; } // 0x0000000181535C10-0x0000000181535C70 
		public override RuntimeMethodHandle MethodHandle { get; } // 0x0000000180377550-0x0000000180377560 
		public override MethodAttributes Attributes { get; } // 0x0000000181535B40-0x0000000181535B50 
		public override CallingConventions CallingConvention { get; } // 0x0000000181535B50-0x0000000181535B80 
		public override bool ContainsGenericParameters { get; } // 0x0000000181535B80-0x0000000181535BC0 
		public override Type ReflectedType { get; } // 0x00000001802F8630-0x00000001802F8640 
		public override Type DeclaringType { get; } // 0x0000000181535BC0-0x0000000181535BF0 
		public override string Name { get; } // 0x0000000181535C00-0x0000000181535C10 
		public override bool IsSecurityCritical { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override int MetadataToken { get; } // 0x0000000181535BF0-0x0000000181535C00 
	
		// Constructors
		public RuntimeConstructorInfo(); // 0x0000000181535AF0-0x0000000181535B40
	
		// Methods
		internal RuntimeModule GetRuntimeModule(); // 0x00000001815355A0-0x0000000181535610
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181535400-0x0000000181535560
		internal string SerializationToString(); // 0x0000000181535A70-0x0000000181535A90
		internal void SerializationInvoke(object target, SerializationInfo info, StreamingContext context); // 0x0000000181535900-0x0000000181535A70
		public override MethodImplAttributes GetMethodImplementationFlags(); // 0x00000001815353D0-0x0000000181535400
		public override ParameterInfo[] GetParameters(); // 0x0000000181535590-0x00000001815355A0
		internal override ParameterInfo[] GetParametersInternal(); // 0x0000000181535590-0x00000001815355A0
		internal override int GetParametersCount(); // 0x0000000181535560-0x0000000181535590
		internal object InternalInvoke(object obj, object[] parameters, out Exception exc); // 0x0000000181535610-0x0000000181535620
		[DebuggerHidden]
		[DebuggerStepThrough]
		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture); // 0x0000000181535740-0x0000000181535890
		private object DoInvoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture); // 0x00000001815350C0-0x0000000181535300
		public object InternalInvoke(object obj, object[] parameters, bool wrapExceptions); // 0x0000000181535620-0x0000000181535710
		[DebuggerHidden]
		[DebuggerStepThrough]
		public override object Invoke(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture); // 0x0000000181535710-0x0000000181535740
		public override bool IsDefined(Type attributeType, bool inherit); // 0x0000000181535890-0x0000000181535900
		public override object[] GetCustomAttributes(bool inherit); // 0x0000000181535300-0x0000000181535360
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x0000000181535360-0x00000001815353D0
		public override string ToString(); // 0x0000000181535A90-0x0000000181535AF0
		public override IList<CustomAttributeData> GetCustomAttributesData(); // 0x0000000181525600-0x0000000181525650
		private static int get_core_clr_security_level(); // 0x0000000180472790-0x00000001804727A0
		internal static int get_metadata_token(RuntimeConstructorInfo method); // 0x0000000181535BF0-0x0000000181535C00
	}
}
