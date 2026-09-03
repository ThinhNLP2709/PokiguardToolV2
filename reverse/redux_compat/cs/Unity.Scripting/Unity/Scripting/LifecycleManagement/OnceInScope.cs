/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement.CodeGen;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting.LifecycleManagement
{
	[Nullable(0)]
	[NullableContext(1)]
	internal static class OnceInScope // TypeDefIndex: 14879
	{
		// Nested types
		[Nullable(0)]
		private class OnceInScopeCleanup : ClassAutoCleanup // TypeDefIndex: 14880
		{
			// Fields
			private readonly Action _toRun; // 0x10
			private object _lock; // 0x18
			private bool _hasRun; // 0x20
	
			// Constructors
			public OnceInScopeCleanup(Action toRun, Type scopeType); // 0x0000000182067D80-0x0000000182067E30
	
			// Methods
			public override void Cleanup(); // 0x0000000182067C00-0x0000000182067CA0
			public void Run(); // 0x0000000182067CA0-0x0000000182067D80
		}
	
		// Methods
		public static Action OnceIn(Action todo, Type scopeType); // 0x0000000182067F70-0x0000000182068090
		public static Action OnceIn<ScopeType>(Action todo);
		public static Action OnceInCodeLoaded(Action todo); // 0x0000000182067E30-0x0000000182067F70
	}
}
