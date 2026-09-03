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

namespace System
{
	[Serializable]
	public abstract class Delegate : ICloneable, ISerializable // TypeDefIndex: 2455
	{
		// Fields
		private IntPtr method_ptr; // 0x10
		private IntPtr invoke_impl; // 0x18
		private object m_target; // 0x20
		private IntPtr method; // 0x28
		private IntPtr delegate_trampoline; // 0x30
		private IntPtr extra_arg; // 0x38
		private IntPtr method_code; // 0x40
		private IntPtr interp_method; // 0x48
		private IntPtr interp_invoke_impl; // 0x50
		private MethodInfo method_info; // 0x58
		private MethodInfo original_method_info; // 0x60
		private DelegateData data; // 0x68
		private bool method_is_virtual; // 0x70
	
		// Properties
		public MethodInfo Method { get; } // 0x0000000181624290-0x00000001816242B0 
		public object Target { get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Methods
		private MethodInfo GetVirtualMethod_internal(); // 0x00000001816505A0-0x00000001816505B0
		internal static Delegate CreateDelegate_internal(Type type, object target, MethodInfo info, bool throwOnBindFailure); // 0x000000018164E6C0-0x000000018164E6D0
		private static bool arg_type_match(Type delArgType, Type argType); // 0x0000000181650850-0x00000001816509A0
		private static bool arg_type_match_this(Type delArgType, Type argType, bool boxedThis); // 0x00000001816509A0-0x0000000181650AF0
		private static bool return_type_match(Type delReturnType, Type returnType); // 0x0000000181650B70-0x0000000181650D40
		private static Delegate CreateDelegate(Type type, object firstArgument, MethodInfo method, bool throwOnBindFailure, bool allowClosed); // 0x000000018164E7C0-0x000000018164F170
		public static Delegate CreateDelegate(Type type, object firstArgument, MethodInfo method); // 0x000000018164F490-0x000000018164F4B0
		public static Delegate CreateDelegate(Type type, MethodInfo method, bool throwOnBindFailure); // 0x000000018164F460-0x000000018164F490
		public static Delegate CreateDelegate(Type type, MethodInfo method); // 0x000000018164F170-0x000000018164F1A0
		public static Delegate CreateDelegate(Type type, object target, string method); // 0x000000018164F290-0x000000018164F370
		private static MethodInfo GetCandidateMethod(Type type, Type target, string method, BindingFlags bflags, bool ignoreCase, bool throwOnBindFailure); // 0x000000018164FC80-0x0000000181650130
		public static Delegate CreateDelegate(Type type, Type target, string method, bool ignoreCase, bool throwOnBindFailure); // 0x000000018164F4B0-0x000000018164F5C0
		public static Delegate CreateDelegate(Type type, Type target, string method); // 0x000000018164F370-0x000000018164F460
		public static Delegate CreateDelegate(Type type, object target, string method, bool ignoreCase, bool throwOnBindFailure); // 0x000000018164F1A0-0x000000018164F290
		public static Delegate CreateDelegate(Type type, object target, string method, bool ignoreCase); // 0x000000018164E6D0-0x000000018164E7C0
		public object DynamicInvoke(params object[] args); // 0x000000018164FA90-0x000000018164FAB0
		private void InitializeDelegateData(); // 0x00000001816505B0-0x00000001816506C0
		protected virtual object DynamicInvokeImpl(object[] args); // 0x000000018164F5C0-0x000000018164FA90
		public virtual object Clone(); // 0x000000018164E330-0x000000018164E340
		public override bool Equals(object obj); // 0x000000018164FAB0-0x000000018164FC80
		public override int GetHashCode(); // 0x0000000181650130-0x00000001816501D0
		protected virtual MethodInfo GetMethodImpl(); // 0x0000000181650270-0x0000000181650370
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181650370-0x00000001816505A0
		public virtual Delegate[] GetInvocationList(); // 0x00000001816501D0-0x0000000181650270
		public static Delegate Combine(Delegate a, Delegate b); // 0x000000018164E3A0-0x000000018164E500
		[ComVisible(true)]
		public static Delegate Combine(params Delegate[] delegates); // 0x000000018164E500-0x000000018164E6C0
		protected virtual Delegate CombineImpl(Delegate d); // 0x000000018164E340-0x000000018164E3A0
		public static Delegate Remove(Delegate source, Delegate value); // 0x00000001816506F0-0x0000000181650850
		protected virtual Delegate RemoveImpl(Delegate d); // 0x00000001816506C0-0x00000001816506F0
		public static bool operator ==(Delegate d1, Delegate d2); // 0x0000000181650AF0-0x0000000181650B20
		public static bool operator !=(Delegate d1, Delegate d2); // 0x0000000181650B20-0x0000000181650B70
		internal static MulticastDelegate AllocDelegateLike_internal(Delegate d); // 0x000000018164E320-0x000000018164E330
	}
}
