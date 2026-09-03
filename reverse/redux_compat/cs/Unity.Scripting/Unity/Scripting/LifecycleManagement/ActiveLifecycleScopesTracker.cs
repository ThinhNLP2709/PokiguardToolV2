/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement.CodeGen;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting.LifecycleManagement
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class ActiveLifecycleScopesTracker // TypeDefIndex: 14837
	{
		// Fields
		private readonly Dictionary<LifecycleScopeKey, ActiveLifecycleScopeBase> _activeScopes; // 0x10
		private readonly ScopeTransitionHelper _scopeTransitionHelper; // 0x18
		private readonly Queue<ScopeTransitionRequestBase> _transitionRequestQueue; // 0x20
		private readonly Dictionary<Type, Dictionary<ScopeTransitionType, List<ClassAutoCleanup>>> _autoCleanups; // 0x28
		private readonly object _autoCleanupsLock; // 0x30
	
		// Properties
		internal IReadOnlyDictionary<LifecycleScopeKey, ActiveLifecycleScopeBase> ActiveScopes { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Nested types
		[NullableContext(0)]
		private enum ScopeTransitionType // TypeDefIndex: 14838
		{
			EnterScope = 0,
			ExitScope = 1
		}
	
		[DebuggerDisplay("Scope Transition Request {Scope.Name}")]
		[Nullable(0)]
		private abstract class ScopeTransitionRequestBase // TypeDefIndex: 14839
		{
			// Fields
			[CompilerGenerated]
			private LifecycleScopeBase _Scope_k__BackingField; // 0x10
			[CompilerGenerated]
			private ScopeTransitionType _TransitionType_k__BackingField; // 0x18
			[CompilerGenerated]
			private bool _AlsoExitNestedScopes_k__BackingField; // 0x1C
	
			// Properties
			public LifecycleScopeBase Scope { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
			public ScopeTransitionType TransitionType { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
			public bool AlsoExitNestedScopes { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180E38E30-0x0000000180E38E40 0x0000000181E92340-0x0000000181E92350
	
			// Constructors
			public ScopeTransitionRequestBase(LifecycleScopeBase scope, ScopeTransitionType scopeTransitionType, bool alsoExitNestedScopes); // 0x000000018162DD70-0x000000018162DDD0
	
			// Methods
			public abstract void Transition(ActiveLifecycleScopesTracker tracker);
		}
	
		[Nullable(0)]
		private class ScopeTransitionRequest : ScopeTransitionRequestBase // TypeDefIndex: 14840
		{
			// Constructors
			public ScopeTransitionRequest(LifecycleScope scope, ScopeTransitionType scopeTransitionType, bool alsoExitNestedScopes); // 0x000000018162DD70-0x000000018162DDD0
	
			// Methods
			public override void Transition(ActiveLifecycleScopesTracker tracker); // 0x0000000182069C70-0x0000000182069D30
		}
	
		[Nullable(0)]
		private class ScopeTransitionRequestWithContext<T> : ScopeTransitionRequestBase // TypeDefIndex: 14841
			where T : class
		{
			// Properties
			public T Context { get; }
	
			// Constructors
			public ScopeTransitionRequestWithContext(LifecycleScopeWithContext<T> scope, ScopeTransitionType scopeTransitionType, bool alsoExitNestedScopes);
	
			// Methods
			public override void Transition(ActiveLifecycleScopesTracker tracker);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass40_0 // TypeDefIndex: 14842
		{
			// Fields
			[Nullable(0)]
			public ReadOnlyAssemblyList unloadingAssemblies; // 0x10
			[Nullable(new byte[2] {0, 1 })]
			public Predicate<ClassAutoCleanup> __9__0; // 0x18
	
			// Constructors
			public __c__DisplayClass40_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _ClearUnloadingAutoStaticsCleanupCallbacks_b__0(ClassAutoCleanup cleanup); // 0x000000018206C330-0x000000018206C360
		}
	
		// Constructors
		public ActiveLifecycleScopesTracker(ScopeTransitionHelper scopeTransitionHelper); // 0x0000000182062620-0x0000000182062770
	
		// Methods
		public void RequestEnterScope(LifecycleScope lifecycleScope); // 0x0000000182061E50-0x0000000182061FB0
		public void RequestEnterScope<T>(LifecycleScopeWithContext<T> lifecycleScope)
			where T : class;
		public void RequestExitScope(LifecycleScope lifecycleScope, bool alsoExitNestedScopes = true /* Metadata: 0x006A98B8 */); // 0x0000000182061FB0-0x0000000182062130
		public void RequestExitScope<T>(LifecycleScopeWithContext<T> lifecycleScope, bool alsoExitNestedScopes = true /* Metadata: 0x006A98B9 */)
			where T : class;
		internal bool HasAnyPresentScopes(); // 0x0000000182060810-0x0000000182060840
		[Obsolete("This overload will be deprecated once this becomes Net8, use the strongly typed overloads instead")]
		public bool IsInsideScope(string scopeName); // 0x0000000182060840-0x0000000182060990
		[NullableContext(0)]
		public bool IsInsideScope<TScope>()
			where TScope : LifecycleScopeBase;
		public bool IsInsideScope(LifecycleScope scope); // 0x0000000182060990-0x0000000182060AD0
		internal bool IsInsideScopeWithActivationContext<TScope, TContext>(TContext scopeContext)
			where TScope : LifecycleScopeWithContext<TContext>
			where TContext : class;
		public bool IsInsideScopeWithActivationContext<TContext>(LifecycleScopeWithContext<TContext> scopeWithContext)
			where TContext : class;
		internal bool IsOrWillBeInsideScope(LifecycleScope scope); // 0x0000000182060AD0-0x0000000182060CD0
		public bool IsOrWillBeInsideScopeWithActivationContext<TScope, TContext>(TContext activationContext)
			where TScope : LifecycleScopeWithContext<TContext>
			where TContext : class;
		public bool TryGetActiveScope<TScope>(out ref TScope scope)
			where TScope : LifecycleScope;
		public bool TryGetActiveScope<TScope, TContext>(TContext context, out ref TScope scope)
			where TScope : LifecycleScopeWithContext<TContext>
			where TContext : class;
		private bool PrepareTryEnterScope<TScope>(TScope lifecycleScope)
			where TScope : LifecycleScope;
		private bool PrepareTryEnterScopeWithContext<TContext>(LifecycleScopeWithContext<TContext> lifecycleScope)
			where TContext : class;
		private void RaiseAutoCleanups(Type lifecycleScopeType, ScopeTransitionType scopeTransitionType); // 0x00000001820615E0-0x0000000182061AE0
		private void TryEnterScope(LifecycleScope lifecycleScope); // 0x0000000182062130-0x0000000182062400
		private void TryEnterScope<TContext>(LifecycleScopeWithContext<TContext> lifecycleScope)
			where TContext : class;
		private void CollectNestedScopesToExit(string scopeName, List<ActiveLifecycleScopeBase> nestedActiveScopesInOrder); // 0x0000000182060310-0x0000000182060510
		private bool PrepareTryExitScope(LifecycleScope lifecycleScope, bool alsoExitNestedScopes); // 0x0000000182060E60-0x00000001820615E0
		private bool PrepareTryExitScope<T>(LifecycleScopeWithContext<T> lifecycleScope, T activationContext, bool alsoExitNestedScopes)
			where T : class;
		private void TryExitScope(LifecycleScope lifecycleScope, bool alsoExitNestedScopes); // 0x0000000182062400-0x0000000182062620
		private void TryExitScope<T>(LifecycleScopeWithContext<T> lifecycleScope, T activationContext, bool alsoExitNestedScopes)
			where T : class;
		private void CreateScopeTransitionRequest(LifecycleScope lifecycleScope, ScopeTransitionType scopeTransitionType, bool alsoExitNestedScopes); // 0x0000000182060510-0x00000001820606E0
		private void CreateScopeTransitionRequest<T>(LifecycleScopeWithContext<T> lifecycleScope, ScopeTransitionType scopeTransitionType, bool alsoExitNestedScopes)
			where T : class;
		private void ExecuteTransitions(bool executeAndPop); // 0x00000001820606E0-0x0000000182060810
		internal void RegisterAutoCleanup(ClassAutoCleanup classAutoCleanup, Type scopeType, ScopeTransitionType cleanOn); // 0x0000000182061AE0-0x0000000182061E50
		internal void ClearUnloadingAutoStaticsCleanupCallbacks(ReadOnlyAssemblyList unloadingAssemblies); // 0x000000018205FC10-0x0000000182060310
		private static bool IsTypeInUnloadingAssembly(Type type, ReadOnlyAssemblyList unloadingAssemblies); // 0x0000000182060CD0-0x0000000182060E60
	}
}
