/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.SubsystemsImplementation;

// Image 53: UnityEngine.SubsystemsModule.dll - Assembly: UnityEngine.SubsystemsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15572-15596

namespace UnityEngine
{
	[NativeHeader("Modules/Subsystems/SubsystemManager.h")]
	public static class SubsystemManager // TypeDefIndex: 15588
	{
		// Fields
		[CompilerGenerated]
		private static Action beforeReloadSubsystems; // 0x00
		[CompilerGenerated]
		private static Action afterReloadSubsystems; // 0x08
		[AutoStaticsCleanupOnCodeReload]
		private static List<IntegratedSubsystem> s_IntegratedSubsystems; // 0x10
		[AutoStaticsCleanupOnCodeReload]
		private static List<SubsystemWithProvider> s_StandaloneSubsystems; // 0x18
		[AutoStaticsCleanupOnCodeReload]
		private static List<Subsystem> s_DeprecatedSubsystems; // 0x20
		[CompilerGenerated]
		private static Action reloadSubsytemsStarted; // 0x28
		[CompilerGenerated]
		private static Action reloadSubsytemsCompleted; // 0x30
	
		// Nested types
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 15589
		{
			// Fields
			public static Action _0___StaticConstructScriptingClassMap; // 0x00
		}
	
		// Constructors
		static SubsystemManager(); // 0x00000001822E9410-0x00000001822E9560
	
		// Methods
		[RequiredByNativeCode]
		private static void ReloadSubsystemsStarted(); // 0x00000001822E8FB0-0x00000001822E9040
		[RequiredByNativeCode]
		private static void ReloadSubsystemsCompleted(); // 0x00000001822E8F20-0x00000001822E8FB0
		[RequiredByNativeCode]
		private static void InitializeIntegratedSubsystem(IntPtr ptr, IntegratedSubsystem subsystem); // 0x00000001822E8E00-0x00000001822E8F20
		[RequiredByNativeCode]
		private static void ClearSubsystems(); // 0x00000001822E89A0-0x00000001822E8B60
		private static void StaticConstructScriptingClassMap(); // 0x00000001822E9290-0x00000001822E92C0
		public static void GetSubsystemDescriptors<T>(List<T> descriptors)
			where T : ISubsystemDescriptor;
		public static void GetSubsystems<T>(List<T> subsystems)
			where T : ISubsystem;
		private static void AddSubsystemSubset<TBaseTypeInList, TQueryType>(List<TBaseTypeInList> copyFrom, List<TQueryType> copyTo)
			where TBaseTypeInList : ISubsystem
			where TQueryType : ISubsystem;
		[VisibleToOtherModules(new string[1] {"UnityEngine.XRModule" })]
		internal static IntegratedSubsystem GetIntegratedSubsystemByPtr(IntPtr ptr); // 0x00000001822E8CC0-0x00000001822E8E00
		internal static void RemoveIntegratedSubsystemByPtr(IntPtr ptr); // 0x00000001822E90C0-0x00000001822E9210
		internal static void AddStandaloneSubsystem(SubsystemWithProvider subsystem); // 0x00000001822E88D0-0x00000001822E89A0
		internal static bool RemoveStandaloneSubsystem(SubsystemWithProvider subsystem); // 0x00000001822E9210-0x00000001822E9290
		internal static SubsystemWithProvider FindStandaloneSubsystemByDescriptor(SubsystemDescriptorWithProvider descriptor); // 0x00000001822E8B60-0x00000001822E8CC0
		internal static bool RemoveDeprecatedSubsystem(Subsystem subsystem); // 0x00000001822E9040-0x00000001822E90C0
		[CompilerGenerated]
		internal static void UnityEngine_SubsystemManager_StaticConstructScriptingClassMap_RegisterLifecycleMethod(); // 0x00000001822E92C0-0x00000001822E9410
	}
}
