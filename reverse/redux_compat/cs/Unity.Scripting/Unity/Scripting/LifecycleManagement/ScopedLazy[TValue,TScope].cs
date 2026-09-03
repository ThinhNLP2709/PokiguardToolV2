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
	internal sealed class ScopedLazy<TValue, TScope> : ClassAutoCleanup // TypeDefIndex: 14882
		where TValue : class
		where TScope : LifecycleScopeBase
	{
		// Fields
		[Nullable(2)]
		private TValue _data;
		private readonly Func<TValue> _factory;
		private readonly bool _checkScopeActive;
	
		// Properties
		public TValue Value { get; }
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 14883
		{
			// Fields
			[Nullable(0)]
			public static readonly __c<TValue, TScope> __9;
			[Nullable(new byte[2] {0, 1 })]
			public static Func<TValue> __9__4_0;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal TValue _.ctor_b__4_0();
		}
	
		// Constructors
		public ScopedLazy(Func<TValue> factory, bool checkScopeActive = true /* Metadata: 0x006A98CF */);
		public ScopedLazy(bool checkScopeActive = true /* Metadata: 0x006A98D0 */);
	
		// Methods
		public override void Cleanup();
	}
}
