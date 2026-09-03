/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting;
using Unity.Scripting.LifecycleManagement.CodeGen;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting.LifecycleManagement
{
	[Nullable(0)]
	[NullableContext(1)]
	internal sealed class LifecycleController // TypeDefIndex: 14864
	{
		// Fields
		[Nullable(2)]
		private static LifecycleController _instance; // 0x00
		private readonly ScopeTransitionHelper _scopeTransitionHelper; // 0x10
		private readonly ActiveLifecycleScopesTracker _lifecycleTracker; // 0x18
		private readonly LifecycleMethodRegistry _lifecycleMethodRegistry; // 0x20
		private readonly object _lock; // 0x28
		[CompilerGenerated]
		private int _MainThreadId_k__BackingField; // 0x30
	
		// Properties
		public static LifecycleController Instance { get; internal set; } // 0x0000000182066330-0x00000001820663C0 0x00000001820663F0-0x0000000182066450
		private bool IsOnMainThread { get; } // 0x00000001820663C0-0x00000001820663F0 
		internal ScopeTransitionHelper ScopeTransitionHelper { get; } // 0x0000000180377550-0x0000000180377560 
		internal int MainThreadId { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		internal ActiveLifecycleScopesTracker LifecycleScopesTracker { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass36_0<TScope> // TypeDefIndex: 14865
			where TScope : LifecycleScope, new()
		{
			// Fields
			[Nullable(0)]
			public LifecycleController __4__this;
			[Nullable(0)]
			public TScope scope;
	
			// Constructors
			public __c__DisplayClass36_0();
	
			// Methods
			internal void _EnterScope_b__0();
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass37_0 // TypeDefIndex: 14866
		{
			// Fields
			[Nullable(0)]
			public LifecycleController __4__this; // 0x10
			[Nullable(0)]
			public LifecycleScope scope; // 0x18
	
			// Constructors
			public __c__DisplayClass37_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _EnterScope_b__0(); // 0x000000018206C1C0-0x000000018206C330
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass38_0<T> // TypeDefIndex: 14867
			where T : class
		{
			// Fields
			[Nullable(0)]
			public LifecycleController __4__this;
			[Nullable(new byte[2] {0, 1 })]
			public LifecycleScopeWithContext<T> scope;
	
			// Constructors
			public __c__DisplayClass38_0();
	
			// Methods
			internal void _EnterScope_b__0();
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass39_0<TScope> // TypeDefIndex: 14868
			where TScope : LifecycleScope, new()
		{
			// Fields
			[Nullable(0)]
			public LifecycleController __4__this;
			[Nullable(0)]
			public string scopeName;
	
			// Constructors
			public __c__DisplayClass39_0();
	
			// Methods
			internal void _ExitScope_b__0();
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass40_0<TScope, TContext> // TypeDefIndex: 14869
			where TScope : LifecycleScopeWithContext<TContext>
			where TContext : class
		{
			// Fields
			[Nullable(0)]
			public LifecycleController __4__this;
			[Nullable(0)]
			public TContext context;
			[Nullable(0)]
			public string scopeName;
	
			// Constructors
			public __c__DisplayClass40_0();
	
			// Methods
			internal void _ExitScope_b__0();
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass41_0 // TypeDefIndex: 14870
		{
			// Fields
			[Nullable(0)]
			public LifecycleController __4__this; // 0x10
			[Nullable(0)]
			public LifecycleScope scope; // 0x18
	
			// Constructors
			public __c__DisplayClass41_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _ExitScope_b__0(); // 0x000000018206C360-0x000000018206C500
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass42_0<TContext> // TypeDefIndex: 14871
			where TContext : class
		{
			// Fields
			[Nullable(0)]
			public LifecycleController __4__this;
			[Nullable(new byte[2] {0, 1 })]
			public LifecycleScopeWithContext<TContext> scope;
	
			// Constructors
			public __c__DisplayClass42_0();
	
			// Methods
			internal void _ExitScope_b__0();
		}
	
		// Constructors
		internal LifecycleController(); // 0x0000000182065F80-0x0000000182066330
	
		// Methods
		public void OnAssembliesLoaded(ReadOnlyAssemblyList loadedAssemblies); // 0x0000000182065B50-0x0000000182065C50
		private void ExecuteInitializationMethods(IReadOnlyList<Assembly> loadedAssemblies); // 0x0000000182064D90-0x0000000182065060
		private bool TryGetInitializationMethod(Assembly assembly, [Nullable(2)] [NotNullWhen(true)] out MethodInfo initializationMethod); // 0x0000000182065E90-0x0000000182065F80
		public bool HasInitializationMethod(Assembly assembly); // 0x0000000182065860-0x0000000182065880
		public void OnAssemblyLoadedScopeExiting(ReadOnlyAssemblyList unloadingAssemblies); // 0x0000000182065C70-0x0000000182065D50
		public void OnAssemblyLoadedScopeExited(ReadOnlyAssemblyList unloadingAssemblies); // 0x0000000182065C50-0x0000000182065C70
		internal INativeCallbackProvider SetDependency_NativeCallbackProvider(INativeCallbackProvider nativeCallbackProvider); // 0x0000000182065DB0-0x0000000182065E90
		internal IReadOnlyList<Assembly> GetAllAssembliesOrdered(); // 0x00000001820656D0-0x0000000182065790
		internal static void InitializeForIl2Cpp(IScriptingCoreDebug depDebug); // 0x0000000182065880-0x00000001820659B0
		[Obsolete("This overload will be deprecated once this becomes Net8, use the strongly typed overloads instead")]
		public bool IsScopePresent(string scopeName); // 0x00000001820659B0-0x0000000182065A80
		public bool IsScopePresent(LifecycleScope scope); // 0x0000000182065A80-0x0000000182065B50
		[NullableContext(0)]
		public bool IsScopePresent<TScope>()
			where TScope : LifecycleScopeBase;
		public bool IsScopePresentWithContext<TContext>(LifecycleScopeWithContext<TContext> scope)
			where TContext : class;
		public bool IsScopePresentWithContext<TScope, TContext>(TContext activationContext)
			where TScope : LifecycleScopeWithContext<TContext>
			where TContext : class;
		internal bool HasAnyPresentScopes(); // 0x0000000182065790-0x0000000182065860
		internal void ExpectPresentScope(string scopeName, LifecycleScopePresence expectation = LifecycleScopePresence.Present /* Metadata: 0x006A98CE */); // 0x0000000182065460-0x00000001820656D0
		private void ExecuteOnMainThread(string transitionType, string scopeName, Action action); // 0x0000000182065060-0x0000000182065350
		[NullableContext(0)]
		internal void EnterScope<TScope>()
			where TScope : LifecycleScope, new();
		internal void EnterScope(LifecycleScope scope); // 0x0000000182064C80-0x0000000182064D90
		internal void EnterScope<T>(LifecycleScopeWithContext<T> scope)
			where T : class;
		[NullableContext(0)]
		internal void ExitScope<TScope>()
			where TScope : LifecycleScope, new();
		internal void ExitScope<TScope, TContext>(TContext context)
			where TScope : LifecycleScopeWithContext<TContext>
			where TContext : class;
		internal void ExitScope(LifecycleScope scope); // 0x0000000182065350-0x0000000182065460
		internal void ExitScope<TContext>(LifecycleScopeWithContext<TContext> scope)
			where TContext : class;
		internal void RegisterAutoCleanup(ClassAutoCleanup classAutoCleanup, Type scopeType, ScopeTransitionType cleanOn); // 0x0000000182065D50-0x0000000182065D80
		internal void RegisterLifecycleMethod(Type lifecycleAttributeType, Assembly assembly, string methodFullName, Action callback); // 0x0000000182065D80-0x0000000182065DB0
	}
}
