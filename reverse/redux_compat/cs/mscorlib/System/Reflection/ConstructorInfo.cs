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
	public abstract class ConstructorInfo : MethodBase // TypeDefIndex: 3288
	{
		// Fields
		public static readonly string ConstructorName; // 0x00
		public static readonly string TypeConstructorName; // 0x08
	
		// Properties
		public override MemberTypes MemberType { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Constructors
		protected ConstructorInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static ConstructorInfo(); // 0x0000000181524E60-0x0000000181524F10
	
		// Methods
		[DebuggerHidden]
		[DebuggerStepThrough]
		public object Invoke(object[] parameters); // 0x0000000181524E20-0x0000000181524E60
		public abstract object Invoke(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture);
		public override bool Equals(object obj); // 0x0000000181524170-0x0000000181524180
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
		public static bool operator ==(ConstructorInfo left, ConstructorInfo right); // 0x0000000181524F10-0x0000000181524F40
		public static bool operator !=(ConstructorInfo left, ConstructorInfo right); // 0x0000000181524F40-0x0000000181524FE0
	}
}
