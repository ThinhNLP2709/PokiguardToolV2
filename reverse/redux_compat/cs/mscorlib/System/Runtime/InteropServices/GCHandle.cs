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

namespace System.Runtime.InteropServices
{
	[ComVisible(true)]
	public struct GCHandle // TypeDefIndex: 3153
	{
		// Fields
		private IntPtr handle; // 0x00
	
		// Properties
		public bool IsAllocated { get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
		public object Target { get; set; } // 0x000000018150CC20-0x000000018150CCA0 0x000000018150CCA0-0x000000018150CD00
	
		// Constructors
		private GCHandle(IntPtr h); // 0x0000000180CBE820-0x0000000180CBE830
		private GCHandle(object obj); // 0x000000018150CBF0-0x000000018150CC20
		internal GCHandle(object value, GCHandleType type); // 0x000000018150CBC0-0x000000018150CBF0
	
		// Methods
		internal static object GetRef(IntPtr handle); // 0x000000018150CB50-0x000000018150CB70
		internal static void SetRef(IntPtr handle, object value); // 0x000000018150CB90-0x000000018150CBC0
		internal static bool CanDereferenceHandle(IntPtr handle); // 0x000000018150C950-0x000000018150C960
		public IntPtr AddrOfPinnedObject(); // 0x000000018150C850-0x000000018150C920
		public static GCHandle Alloc(object value); // 0x000000018150C940-0x000000018150C950
		public static GCHandle Alloc(object value, GCHandleType type); // 0x000000018150C920-0x000000018150C940
		public void Free(); // 0x000000018150CA00-0x000000018150CA80
		public static explicit operator IntPtr(GCHandle value); // 0x0000000180370C60-0x0000000180370C70
		public static explicit operator GCHandle(IntPtr value); // 0x000000018150CA80-0x000000018150CB40
		private static bool CheckCurrentDomain(IntPtr handle); // 0x000000018150C960-0x000000018150C970
		private static object GetTarget(IntPtr handle); // 0x000000018150CB80-0x000000018150CB90
		private static IntPtr GetTargetHandle(object obj, IntPtr handle, GCHandleType type); // 0x000000018150CB70-0x000000018150CB80
		private static void FreeHandle(IntPtr handle); // 0x000000018150C9F0-0x000000018150CA00
		private static IntPtr GetAddrOfPinnedObject(IntPtr handle); // 0x000000018150CB40-0x000000018150CB50
		public static bool operator ==(GCHandle a, GCHandle b); // 0x0000000180A29AB0-0x0000000180A29AC0
		public override bool Equals(object o); // 0x000000018150C970-0x000000018150C9F0
		public override int GetHashCode(); // 0x00000001814330E0-0x00000001814330F0
		public static GCHandle FromIntPtr(IntPtr value); // 0x000000018150CA80-0x000000018150CB40
		public static IntPtr ToIntPtr(GCHandle value); // 0x0000000180370C60-0x0000000180370C70
	}
}
