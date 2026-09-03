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
	public abstract class MethodBase : MemberInfo // TypeDefIndex: 3306
	{
		// Properties
		public abstract MethodAttributes Attributes { get; }
		public virtual CallingConventions CallingConvention { get; } // 0x0000000180472790-0x00000001804727A0 
		public bool IsAbstract { get; } // 0x000000018152CAE0-0x000000018152CB10 
		public bool IsConstructor { get; } // 0x000000018152CB10-0x000000018152CBB0 
		public bool IsSpecialName { get; } // 0x000000018152CC10-0x000000018152CC40 
		public bool IsStatic { get; } // 0x000000018152CC40-0x000000018152CC70 
		public bool IsVirtual { get; } // 0x000000018152CC70-0x000000018152CCA0 
		public bool IsPublic { get; } // 0x000000018152CBB0-0x000000018152CBE0 
		public virtual bool IsGenericMethod { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual bool IsGenericMethodDefinition { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual bool ContainsGenericParameters { get; } // 0x00000001802E7840-0x00000001802E7850 
		public abstract RuntimeMethodHandle MethodHandle { get; }
		public virtual bool IsSecurityCritical { get; } // 0x000000018152CBE0-0x000000018152CC10 
	
		// Constructors
		protected MethodBase(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract ParameterInfo[] GetParameters();
		public abstract MethodImplAttributes GetMethodImplementationFlags();
		public virtual Type[] GetGenericArguments(); // 0x000000018152C690-0x000000018152C6E0
		[DebuggerHidden]
		[DebuggerStepThrough]
		public object Invoke(object obj, object[] parameters); // 0x000000018152CAA0-0x000000018152CAE0
		public abstract object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture);
		public override bool Equals(object obj); // 0x0000000181524170-0x0000000181524180
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
		public static bool operator ==(MethodBase left, MethodBase right); // 0x000000018152CCA0-0x000000018152CEE0
		public static bool operator !=(MethodBase left, MethodBase right); // 0x000000018152CEE0-0x000000018152CF00
		internal virtual ParameterInfo[] GetParametersInternal(); // 0x000000018152CA80-0x000000018152CAA0
		internal virtual int GetParametersCount(); // 0x000000018152CA50-0x000000018152CA80
		internal virtual string FormatNameAndSig(bool serialization); // 0x000000018152C560-0x000000018152C690
		internal virtual Type[] GetParameterTypes(); // 0x000000018152C910-0x000000018152CA50
		internal virtual ParameterInfo[] GetParametersNoCopy(); // 0x000000018152CA80-0x000000018152CAA0
		public static MethodBase GetMethodFromHandle(RuntimeMethodHandle handle); // 0x000000018152C6E0-0x000000018152C910
		internal static string ConstructParameters(Type[] parameterTypes, CallingConventions callingConvention, bool serialization); // 0x000000018152C370-0x000000018152C560
	}
}
