/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	[Serializable]
	public abstract class MethodInfo : MethodBase // TypeDefIndex: 3308
	{
		// Properties
		public override MemberTypes MemberType { get; } // 0x0000000180740830-0x0000000180740840 
		public virtual ParameterInfo ReturnParameter { get; } // 0x000000018152D3C0-0x000000018152D3F0 
		public virtual Type ReturnType { get; } // 0x000000018152D3F0-0x000000018152D420 
		internal virtual int GenericParameterCount { get; } // 0x000000018152D390-0x000000018152D3C0 
	
		// Constructors
		protected MethodInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public override Type[] GetGenericArguments(); // 0x000000018152D2A0-0x000000018152D2F0
		public virtual MethodInfo GetGenericMethodDefinition(); // 0x000000018152D2F0-0x000000018152D340
		public virtual MethodInfo MakeGenericMethod(params Type[] typeArguments); // 0x000000018152D340-0x000000018152D390
		public abstract MethodInfo GetBaseDefinition();
		public virtual Delegate CreateDelegate(Type delegateType); // 0x000000018152D200-0x000000018152D250
		public virtual Delegate CreateDelegate(Type delegateType, object target); // 0x000000018152D250-0x000000018152D2A0
		public override bool Equals(object obj); // 0x0000000181524170-0x0000000181524180
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
		public static bool operator ==(MethodInfo left, MethodInfo right); // 0x0000000181524F10-0x0000000181524F40
		public static bool operator !=(MethodInfo left, MethodInfo right); // 0x0000000181528E10-0x0000000181528E50
	}
}
