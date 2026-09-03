/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_ParameterInfo))]
	[ComVisible(true)]
	internal class RuntimeParameterInfo : ParameterInfo // TypeDefIndex: 3356
	{
		// Fields
		internal MarshalAsAttribute marshalAs; // 0x40
	
		// Properties
		public override object DefaultValue { get; } // 0x000000018153A8F0-0x000000018153AB50 
	
		// Constructors
		internal RuntimeParameterInfo(string name, Type type, int position, int attrs, object defaultValue, MemberInfo member, MarshalAsAttribute marshalAs); // 0x000000018153A650-0x000000018153A6F0
		internal RuntimeParameterInfo(ParameterInfo pinfo, MemberInfo member); // 0x000000018153A780-0x000000018153A8F0
		internal RuntimeParameterInfo(Type type, MemberInfo member, MarshalAsAttribute marshalAs); // 0x000000018153A6F0-0x000000018153A780
	
		// Methods
		internal static void FormatParameters(StringBuilder sb, ParameterInfo[] p, CallingConventions callingConvention, bool serialization); // 0x0000000181539760-0x0000000181539950
		public override object[] GetCustomAttributes(bool inherit); // 0x00000001815399B0-0x0000000181539A00
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x0000000181539950-0x00000001815399B0
		internal object GetDefaultValueImpl(ParameterInfo pinfo); // 0x0000000181539A00-0x0000000181539AB0
		public override bool IsDefined(Type attributeType, bool inherit); // 0x000000018153A3C0-0x000000018153A430
		internal object[] GetPseudoCustomAttributes(); // 0x000000018153A0A0-0x000000018153A3C0
		internal CustomAttributeData[] GetPseudoCustomAttributesData(); // 0x0000000181539AB0-0x000000018153A0A0
		internal static ParameterInfo New(ParameterInfo pinfo, MemberInfo member); // 0x000000018153A430-0x000000018153A5B0
		internal static ParameterInfo New(Type type, MemberInfo member, MarshalAsAttribute marshalAs); // 0x000000018153A5B0-0x000000018153A650
	}
}
