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
	public abstract class PropertyInfo : MemberInfo // TypeDefIndex: 3317
	{
		// Properties
		public override MemberTypes MemberType { get; } // 0x00000001808F5E70-0x00000001808F5E80 
		public abstract Type PropertyType { get; }
		public abstract bool CanRead { get; }
		public abstract bool CanWrite { get; }
		public virtual MethodInfo GetMethod { get; } // 0x00000001815340C0-0x00000001815340E0 
	
		// Constructors
		protected PropertyInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract ParameterInfo[] GetIndexParameters();
		public MethodInfo GetGetMethod(); // 0x0000000181533FB0-0x0000000181533FD0
		public abstract MethodInfo GetGetMethod(bool nonPublic);
		public MethodInfo GetSetMethod(); // 0x0000000181533FD0-0x0000000181533FF0
		public abstract MethodInfo GetSetMethod(bool nonPublic);
		[DebuggerHidden]
		[DebuggerStepThrough]
		public object GetValue(object obj); // 0x0000000181533FF0-0x0000000181534010
		[DebuggerHidden]
		[DebuggerStepThrough]
		public virtual object GetValue(object obj, object[] index); // 0x0000000181534010-0x0000000181534050
		public abstract object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture);
		[DebuggerHidden]
		[DebuggerStepThrough]
		public void SetValue(object obj, object value); // 0x0000000181534050-0x0000000181534080
		[DebuggerHidden]
		[DebuggerStepThrough]
		public virtual void SetValue(object obj, object value, object[] index); // 0x0000000181534080-0x00000001815340C0
		public abstract void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture);
		public override bool Equals(object obj); // 0x0000000181524170-0x0000000181524180
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
		public static bool operator ==(PropertyInfo left, PropertyInfo right); // 0x0000000181524F10-0x0000000181524F40
		public static bool operator !=(PropertyInfo left, PropertyInfo right); // 0x0000000181528E10-0x0000000181528E50
	}
}
