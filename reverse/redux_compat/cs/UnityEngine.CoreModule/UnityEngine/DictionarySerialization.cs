/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	internal static class DictionarySerialization // TypeDefIndex: 7798
	{
		// Fields
		[CompilerGenerated]
		private static IDictionaryIgnoredEntriesCache _s_IgnoredEntriesForDictionaries_k__BackingField; // 0x00
		[CompilerGenerated]
		private static Action<EntityId, string, bool, bool> _s_PostDictionaryKeyWarning_k__BackingField; // 0x08
		[NoAutoStaticsCleanup]
		private static readonly MethodInfo s_SetEntriesTypedInfo; // 0x10
		[AutoStaticsCleanupOnCodeReload]
		private static readonly ConcurrentDictionary<Type, SetEntriesTypedDelegate> s_SetEntriesTypedCache; // 0x18
		[NoAutoStaticsCleanup]
		private static readonly MethodInfo s_GetEntriesTypedInfo; // 0x20
		[AutoStaticsCleanupOnCodeReload]
		private static readonly ConcurrentDictionary<Type, GetEntriesTypedDelegate> s_GetEntriesTypedCache; // 0x28
		[NoAutoStaticsCleanup]
		private static readonly MethodInfo s_CreateEmptyDictionaryTypedInfo; // 0x30
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x38
	
		// Properties
		[AutoStaticsCleanupOnCodeReload]
		internal static IDictionaryIgnoredEntriesCache s_IgnoredEntriesForDictionaries { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001822054A0-0x00000001822054F0 0x0000000182205540-0x00000001822055B0
		[AutoStaticsCleanupOnCodeReload]
		internal static Action<EntityId, string, bool, bool> s_PostDictionaryKeyWarning { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001822054F0-0x0000000182205540 0x00000001822055B0-0x0000000182205620
	
		// Nested types
		[Serializable]
		internal struct SerializedKeyValue<TKey, TValue> // TypeDefIndex: 7799
		{
			// Fields
			[SerializeField]
			public TKey key;
			[SerializeField]
			public TValue value;
	
			// Constructors
			public SerializedKeyValue(TKey key, TValue value);
		}
	
		private delegate bool SetEntriesTypedDelegate(EntityId hostingEntityId, object dictionary, Array array, string dictionaryIdentifier, bool warnAboutIgnoredEntries); // TypeDefIndex: 7800; 0x000000018221D480-0x000000018221D4A0
	
		private delegate Array GetEntriesTypedDelegate(EntityId hostingEntityId, object dictionary, IntPtr dictionaryIdentifierTemplateUtf8); // TypeDefIndex: 7801; 0x0000000180A72B30-0x0000000180A72B50
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass23_0 // TypeDefIndex: 7802
		{
			// Fields
			public Type[] dictArgs; // 0x10
	
			// Constructors
			public __c__DisplayClass23_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal SetEntriesTypedDelegate _GetSetEntriesTypedDelegate_b__0(Type _); // 0x0000000182226C30-0x0000000182226D20
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass26_0 // TypeDefIndex: 7803
		{
			// Fields
			public Type[] dictArgs; // 0x10
	
			// Constructors
			public __c__DisplayClass26_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal GetEntriesTypedDelegate _GetGetEntriesTypedDelegate_b__0(Type _); // 0x0000000182226D20-0x0000000182226E10
		}
	
		// Constructors
		static DictionarySerialization(); // 0x0000000182205110-0x00000001822054A0
	
		// Methods
		[FreeFunction("DictionaryFieldUniqueIdentifierBindings::FormatDictionaryFieldUniqueIdentifierForActiveContext", IsThreadSafe = true)]
		[NativeHeader("Runtime/Mono/SerializationBackend_DirectMemoryAccess/DictionaryFieldUniqueIdentifierStack.h")]
		private static string Internal_FormatDictionaryFieldUniqueIdentifierForActiveContext(IntPtr dictionaryIdentifierTemplateUtf8); // 0x00000001822044C0-0x00000001822045C0
		private static string ResolveDictionaryFieldUniqueIdentifierForIgnoredLookups(EntityId hostingEntityId, IntPtr dictionaryIdentifierTemplateUtf8); // 0x0000000182204950-0x0000000182204B20
		private static bool SetEntriesTyped<TKey, TValue>(EntityId hostingEntityId, object dictionary, Array array, string dictionaryIdentifier, bool warnAboutIgnoredEntries);
		private static SetEntriesTypedDelegate GetSetEntriesTypedDelegate(Type[] dictArgs); // 0x0000000182203FB0-0x0000000182204120
		private static Array GetEntriesTyped<TKey, TValue>(EntityId hostingEntityId, object dictionary, IntPtr dictionaryIdentifierTemplateUtf8);
		private static Array GetArrayWithHandledIgnoredEntries<TKey, TValue>(Dictionary<TKey, TValue> dict, EntityId hostingEntityId, string dictionaryPath, int count, IgnoredEntriesData storedIgnored, int ignoredCount);
		private static GetEntriesTypedDelegate GetGetEntriesTypedDelegate(Type[] dictArgs); // 0x0000000182203E40-0x0000000182203FB0
		private static object CreateEmptyDictionaryTyped<TKey, TValue>();
		private static int InternClosedDelegateForDictionaryType(IntPtr dictTypeRaw, MethodInfo openMethod, Type delegateType); // 0x0000000182204120-0x0000000182204290
		[RequiredByNativeCode]
		internal static int InternGetEntriesTypedDelegate(IntPtr dictTypeRaw); // 0x0000000182204330-0x00000001822043D0
		[RequiredByNativeCode]
		internal static int InternSetEntriesTypedDelegate(IntPtr dictTypeRaw); // 0x00000001822043D0-0x0000000182204470
		internal static Array InvokeGetEntriesTyped(int idx, EntityId hostingEntityId, object dictionary, IntPtr dictionaryIdentifierTemplate); // 0x00000001822045C0-0x00000001822046D0
		internal static bool InvokeSetEntriesTyped(int idx, EntityId hostingEntityId, object dictionary, Array entries, string dictionaryIdentifier, bool warnAboutIgnoredEntries); // 0x00000001822046D0-0x0000000182204810
		[RequiredByNativeCode]
		internal static int InternDictionaryDefaultAllocateFactory(IntPtr dictTypeRaw); // 0x0000000182204290-0x0000000182204330
		[RequiredByNativeCode]
		internal static bool SetEntriesFromSerializedData(EntityId hostingEntityId, object dictionary, object entriesArray, string dictionaryIdentifier, bool warnAboutIgnoredEntries); // 0x0000000182204B20-0x0000000182204F10
		[RequiredByNativeCode]
		internal static Type GetDictionaryEntryTypeForSerialization(Type dictionaryType); // 0x0000000182203D70-0x0000000182203E40
		[RequiredByNativeCode]
		internal static Array GetDictionaryEntriesForSerialization(EntityId hostingEntityId, object dictionary, IntPtr dictionaryIdentifierTemplateUtf8); // 0x0000000182203B30-0x0000000182203D70
		private static bool IsGenericDictionaryEntryType(Type entryType, Type[] dictGenericArgs); // 0x0000000182204810-0x0000000182204950
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x0000000182204F10-0x0000000182205110
		private static void Internal_FormatDictionaryFieldUniqueIdentifierForActiveContext_Injected(IntPtr dictionaryIdentifierTemplateUtf8, ); // 0x0000000182204470-0x00000001822044C0
	}
}
