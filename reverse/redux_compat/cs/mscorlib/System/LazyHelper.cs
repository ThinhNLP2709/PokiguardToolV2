/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	internal class LazyHelper // TypeDefIndex: 2294
	{
		// Fields
		internal static readonly LazyHelper NoneViaConstructor; // 0x00
		internal static readonly LazyHelper NoneViaFactory; // 0x08
		internal static readonly LazyHelper PublicationOnlyViaConstructor; // 0x10
		internal static readonly LazyHelper PublicationOnlyViaFactory; // 0x18
		internal static readonly LazyHelper PublicationOnlyWaitForOtherThreadToPublish; // 0x20
		[CompilerGenerated]
		private readonly LazyState _State_k__BackingField; // 0x10
		private readonly ExceptionDispatchInfo _exceptionDispatch; // 0x18
	
		// Properties
		internal LazyState State { [CompilerGenerated] get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
		// Constructors
		internal LazyHelper(LazyState state); // 0x00000001802F9040-0x00000001802F9070
		internal LazyHelper(LazyThreadSafetyMode mode, Exception exception); // 0x00000001815FEBC0-0x00000001815FEC30
		static LazyHelper(); // 0x00000001815FEA20-0x00000001815FEBC0
	
		// Methods
		internal void ThrowException(); // 0x00000001815FEA00-0x00000001815FEA20
		internal static LazyHelper Create(LazyThreadSafetyMode mode, bool useDefaultConstructor); // 0x00000001815FE850-0x00000001815FE9F0
		internal static object CreateViaDefaultConstructor(Type type); // 0x00000001815FE7E0-0x00000001815FE850
		internal static LazyThreadSafetyMode GetModeFromIsThreadSafe(bool isThreadSafe); // 0x00000001815FE9F0-0x00000001815FEA00
	}
}
