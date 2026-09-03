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
	internal class RuntimeMethodInfo : MethodInfo, ISerializable // TypeDefIndex: 3353
	{
		// Fields
		internal IntPtr mhandle; // 0x10
		private string name; // 0x18
		private Type reftype; // 0x20
	
		// Properties
		internal BindingFlags BindingFlags { get; } // 0x00000001802E7860-0x00000001802E7870 
		public override Module Module { get; } // 0x0000000181536200-0x0000000181536270 
		private RuntimeType ReflectedTypeInternal { get; } // 0x0000000181535C10-0x0000000181535C70 
		public override ParameterInfo ReturnParameter { get; } // 0x000000018152DB50-0x000000018152DC20 
		public override Type ReturnType { get; } // 0x0000000181539360-0x0000000181539390 
		public override int MetadataToken { get; } // 0x0000000181535BF0-0x0000000181535C00 
		public override RuntimeMethodHandle MethodHandle { get; } // 0x0000000180377550-0x0000000180377560 
		public override MethodAttributes Attributes { get; } // 0x0000000181535B40-0x0000000181535B50 
		public override CallingConventions CallingConvention { get; } // 0x0000000181535B50-0x0000000181535B80 
		public override Type ReflectedType { get; } // 0x00000001802F8630-0x00000001802F8640 
		public override Type DeclaringType { get; } // 0x0000000181535BC0-0x0000000181535BF0 
		public override string Name { get; } // 0x0000000181535C00-0x0000000181535C10 
		public override bool IsGenericMethodDefinition { get; } // 0x0000000181539340-0x0000000181539350 
		public override bool IsGenericMethod { get; } // 0x0000000181539350-0x0000000181539360 
		public override bool ContainsGenericParameters { get; } // 0x0000000181539250-0x0000000181539340 
		public override bool IsSecurityCritical { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Constructors
		internal RuntimeMethodInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal override string FormatNameAndSig(bool serialization); // 0x0000000181537440-0x0000000181537740
		public override Delegate CreateDelegate(Type delegateType); // 0x0000000181537400-0x0000000181537420
		public override Delegate CreateDelegate(Type delegateType, object target); // 0x0000000181537420-0x0000000181537440
		public override string ToString(); // 0x00000001815391C0-0x0000000181539250
		internal RuntimeModule GetRuntimeModule(); // 0x0000000181536200-0x0000000181536270
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181538430-0x00000001815385E0
		internal string SerializationToString(); // 0x0000000181539120-0x00000001815391C0
		internal static MethodBase GetMethodFromHandleNoGenericCheck(RuntimeMethodHandle handle); // 0x0000000181538410-0x0000000181538420
		internal static MethodBase GetMethodFromHandleNoGenericCheck(RuntimeMethodHandle handle, RuntimeTypeHandle reflectedType); // 0x0000000181538420-0x0000000181538430
		internal static MethodBase GetMethodFromHandleInternalType(IntPtr method_handle, IntPtr type_handle); // 0x00000001815383F0-0x0000000181538400
		private static MethodBase GetMethodFromHandleInternalType_native(IntPtr method_handle, IntPtr type_handle, bool genericCheck); // 0x0000000181538400-0x0000000181538410
		internal static string get_name(MethodBase method); // 0x00000001815393A0-0x00000001815393B0
		internal static RuntimeMethodInfo get_base_method(RuntimeMethodInfo method, bool definition); // 0x0000000181539390-0x00000001815393A0
		internal static int get_metadata_token(RuntimeMethodInfo method); // 0x0000000181535BF0-0x0000000181535C00
		public override MethodInfo GetBaseDefinition(); // 0x0000000181537740-0x0000000181537750
		internal MethodInfo GetBaseMethod(); // 0x0000000181537750-0x0000000181537760
		public override MethodImplAttributes GetMethodImplementationFlags(); // 0x00000001815353D0-0x0000000181535400
		public override ParameterInfo[] GetParameters(); // 0x0000000181538620-0x00000001815386B0
		internal override ParameterInfo[] GetParametersInternal(); // 0x0000000181535590-0x00000001815355A0
		internal override int GetParametersCount(); // 0x00000001815385F0-0x0000000181538620
		internal object InternalInvoke(object obj, object[] parameters, out Exception exc); // 0x0000000181538A60-0x0000000181538A70
		[DebuggerHidden]
		[DebuggerStepThrough]
		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture); // 0x0000000181538A70-0x0000000181538D40
		internal static void ConvertValues(Binder binder, object[] args, ParameterInfo[] pinfo, CultureInfo culture, BindingFlags invokeAttr); // 0x00000001815370B0-0x0000000181537400
		public override bool IsDefined(Type attributeType, bool inherit); // 0x0000000181538D40-0x0000000181538DB0
		public override object[] GetCustomAttributes(bool inherit); // 0x00000001815377D0-0x0000000181537830
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x0000000181537760-0x00000001815377D0
		internal void GetPInvoke(out PInvokeAttributes flags, out string entryPoint, out string dllName); // 0x00000001815385E0-0x00000001815385F0
		internal object[] GetPseudoCustomAttributes(); // 0x00000001815388B0-0x0000000181538A60
		internal CustomAttributeData[] GetPseudoCustomAttributesData(); // 0x00000001815386B0-0x00000001815388B0
		private CustomAttributeData GetDllImportAttributeData(); // 0x0000000181537830-0x0000000181538370
		public override MethodInfo MakeGenericMethod(params Type[] methodInstantiation); // 0x0000000181538DC0-0x0000000181539120
		private MethodInfo MakeGenericMethod_impl(Type[] types); // 0x0000000181538DB0-0x0000000181538DC0
		public override Type[] GetGenericArguments(); // 0x0000000181538370-0x0000000181538380
		private MethodInfo GetGenericMethodDefinition_impl(); // 0x0000000181538380-0x0000000181538390
		public override MethodInfo GetGenericMethodDefinition(); // 0x0000000181538390-0x00000001815383F0
		public override IList<CustomAttributeData> GetCustomAttributesData(); // 0x0000000181525600-0x0000000181525650
		private static int get_core_clr_security_level(); // 0x0000000180472790-0x00000001804727A0
	}
}
