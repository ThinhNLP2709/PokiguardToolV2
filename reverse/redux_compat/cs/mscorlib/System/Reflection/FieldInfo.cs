/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	[Serializable]
	public abstract class FieldInfo : MemberInfo // TypeDefIndex: 3296
	{
		// Properties
		public override MemberTypes MemberType { get; } // 0x00000001804CB980-0x00000001804CB990 
		public abstract FieldAttributes Attributes { get; }
		public abstract Type FieldType { get; }
		public bool IsInitOnly { get; } // 0x0000000181529D50-0x0000000181529D80 
		public bool IsLiteral { get; } // 0x0000000181529D80-0x0000000181529DB0 
		public bool IsNotSerialized { get; } // 0x0000000181529DB0-0x0000000181529DE0 
		public bool IsStatic { get; } // 0x0000000181529E40-0x0000000181529E70 
		public bool IsPrivate { get; } // 0x0000000181529DE0-0x0000000181529E10 
		public bool IsPublic { get; } // 0x0000000181529E10-0x0000000181529E40 
		public abstract RuntimeFieldHandle FieldHandle { get; }
	
		// Constructors
		protected FieldInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181524170-0x0000000181524180
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
		public static bool operator ==(FieldInfo left, FieldInfo right); // 0x0000000181524F10-0x0000000181524F40
		public static bool operator !=(FieldInfo left, FieldInfo right); // 0x0000000181528E10-0x0000000181528E50
		public abstract object GetValue(object obj);
		[DebuggerHidden]
		[DebuggerStepThrough]
		public void SetValue(object obj, object value); // 0x0000000181529CD0-0x0000000181529D50
		public abstract void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture);
		[CLSCompliant(false)]
		public virtual void SetValueDirect(TypedReference obj, object value); // 0x0000000181529C80-0x0000000181529CD0
		public virtual object GetRawConstantValue(); // 0x0000000181529C30-0x0000000181529C80
		private static FieldInfo internal_from_handle_type(IntPtr field_handle, IntPtr type_handle); // 0x0000000181529E70-0x0000000181529E80
		public static FieldInfo GetFieldFromHandle(RuntimeFieldHandle handle); // 0x00000001815291B0-0x0000000181529220
		[ComVisible(false)]
		public static FieldInfo GetFieldFromHandle(RuntimeFieldHandle handle, RuntimeTypeHandle declaringType); // 0x0000000181529220-0x00000001815292D0
		internal virtual int GetFieldOffset(); // 0x00000001815292D0-0x0000000181529320
		private MarshalAsAttribute get_marshal_info(); // 0x00000001814CAEE0-0x00000001814CAEF0
		internal object[] GetPseudoCustomAttributes(); // 0x00000001815299A0-0x0000000181529C30
		internal CustomAttributeData[] GetPseudoCustomAttributesData(); // 0x0000000181529320-0x00000001815299A0
	}
}
