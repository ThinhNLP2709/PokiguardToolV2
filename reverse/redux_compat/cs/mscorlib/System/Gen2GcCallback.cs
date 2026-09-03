/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	internal sealed class Gen2GcCallback : CriticalFinalizerObject // TypeDefIndex: 2247
	{
		// Fields
		private Func<object, bool> _callback; // 0x10
		private GCHandle _weakTargetObj; // 0x18
	
		// Constructors
		private Gen2GcCallback(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static void Register(Func<object, bool> callback, object targetObj); // 0x00000001815F74E0-0x00000001815F7570
		private void Setup(Func<object, bool> callback, object targetObj); // 0x00000001815F7570-0x00000001815F7840
		~Gen2GcCallback(); // 0x00000001815F7360-0x00000001815F74E0
	}
}
