/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mono;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	[Serializable]
	public abstract class EventInfo : MemberInfo // TypeDefIndex: 3292
	{
		// Fields
		private AddEventAdapter cached_add_event; // 0x10
	
		// Properties
		public override MemberTypes MemberType { get; } // 0x0000000180476390-0x00000001804763A0 
		public virtual Type EventHandlerType { get; } // 0x0000000181528CF0-0x0000000181528E00 
	
		// Nested types
		private delegate void AddEventAdapter(object _this, Delegate dele); // TypeDefIndex: 3293; 0x0000000180A70FB0-0x0000000180A70FC0
	
		// Constructors
		protected EventInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public MethodInfo GetAddMethod(); // 0x00000001814CCEC0-0x00000001814CCEE0
		public MethodInfo GetRemoveMethod(); // 0x0000000181528B70-0x0000000181528B90
		public abstract MethodInfo GetAddMethod(bool nonPublic);
		public abstract MethodInfo GetRemoveMethod(bool nonPublic);
		public abstract MethodInfo GetRaiseMethod(bool nonPublic);
		[DebuggerHidden]
		[DebuggerStepThrough]
		public virtual void RemoveEventHandler(object target, Delegate handler); // 0x0000000181528B90-0x0000000181528CF0
		public override bool Equals(object obj); // 0x0000000181524170-0x0000000181524180
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
		public static bool operator ==(EventInfo left, EventInfo right); // 0x0000000181524F10-0x0000000181524F40
		public static bool operator !=(EventInfo left, EventInfo right); // 0x0000000181528E10-0x0000000181528E50
		[DebuggerHidden]
		[DebuggerStepThrough]
		public virtual void AddEventHandler(object target, Delegate handler); // 0x00000001815288F0-0x0000000181528AC0
		private static EventInfo internal_from_handle_type(IntPtr event_handle, IntPtr type_handle); // 0x0000000181528E00-0x0000000181528E10
		internal static EventInfo GetEventFromHandle(RuntimeEventHandle handle, RuntimeTypeHandle reflectedType); // 0x0000000181528AC0-0x0000000181528B70
	}
}
