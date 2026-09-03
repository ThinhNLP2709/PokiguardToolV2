/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting.LifecycleManagement
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class DependencyOrderedNativeCallbackProvider : INativeCallbackProvider // TypeDefIndex: 14858
	{
		// Fields
		private readonly Dictionary<string, SortedSubsystemGroup<DelegateWithContext<INativeCallbackProvider.LifecycleNativeDelegate>, DelegateWithContext<INativeCallbackProvider.LifecycleNativeDelegate>>> _nativeLifecycleEventHandlers; // 0x10
	
		// Constructors
		public DependencyOrderedNativeCallbackProvider(); // 0x0000000182064AB0-0x0000000182064B30
	
		// Methods
		public void RegisterNativeLifecycleEventHandlers(string identifierName, string lifecycleScopeName, IntPtr invocationContext, [Nullable(new byte[2] {2, 1 })] DelegateWithContext<INativeCallbackProvider.LifecycleNativeDelegate> initScopeHandler, [Nullable(new byte[2] {2, 1 })] DelegateWithContext<INativeCallbackProvider.LifecycleNativeDelegate> cleanupScopeHandler, params string[] dependencyIdentifierNames); // 0x0000000182064910-0x0000000182064AB0
		public IReadOnlyList<DelegateWithContext<INativeCallbackProvider.LifecycleNativeDelegate>> GetInitLifecycleNativeEventHandlers(string lifecycleScopeName); // 0x0000000182064830-0x0000000182064910
		public IReadOnlyList<DelegateWithContext<INativeCallbackProvider.LifecycleNativeDelegate>> GetCleanupLifecycleNativeEventHandlers(string lifecycleScopeName); // 0x0000000182064750-0x0000000182064830
	}
}
