/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties.Internal
{
	internal static class PropertyBagStore // TypeDefIndex: 14592
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		private static readonly ConcurrentDictionary<Type, IPropertyBag> s_PropertyBags; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		private static readonly List<Type> s_RegisteredTypes; // 0x08
		[NoAutoStaticsCleanup]
		private static ReflectedPropertyBagProvider s_PropertyBagProvider; // 0x10
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x18
	
		// Properties
		private static ReflectedPropertyBagProvider ReflectedPropertyBagProvider { get; } // 0x00000001822DCCB0-0x00000001822DCD70 
	
		// Nested types
		internal struct TypedStore<TContainer> // TypeDefIndex: 14593
		{
			// Fields
			[AutoStaticsCleanupOnCodeReload]
			public static IPropertyBag<TContainer> PropertyBag;
			[CompilerGenerated]
			private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting;
	
			// Constructors
			static TypedStore();
	
			// Methods
			[CompilerGenerated]
			private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting();
		}
	
		// Constructors
		static PropertyBagStore(); // 0x00000001822DCAA0-0x00000001822DCCB0
	
		// Methods
		internal static void CreatePropertyBagProvider(); // 0x00000001822DC390-0x00000001822DC450
		internal static void AddPropertyBag<TContainer>(IPropertyBag<TContainer> propertyBag);
		internal static IPropertyBag<TContainer> GetPropertyBag<TContainer>();
		internal static IPropertyBag GetPropertyBag(Type type); // 0x00000001822DC450-0x00000001822DC9F0
		internal static bool TryGetPropertyBagForValue<TValue>(ref ref TValue value, out IPropertyBag propertyBag);
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001822DC9F0-0x00000001822DCAA0
	}
}
