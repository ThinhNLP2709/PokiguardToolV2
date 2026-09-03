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

// Image 53: UnityEngine.SubsystemsModule.dll - Assembly: UnityEngine.SubsystemsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15572-15596

namespace UnityEngine.SubsystemsImplementation
{
	[NativeHeader("Modules/Subsystems/SubsystemManager.h")]
	public static class SubsystemDescriptorStore // TypeDefIndex: 15590
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static List<IntegratedSubsystemDescriptor> s_IntegratedDescriptors; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		private static List<SubsystemDescriptorWithProvider> s_StandaloneDescriptors; // 0x08
		[AutoStaticsCleanupOnCodeReload]
		private static List<SubsystemDescriptor> s_DeprecatedDescriptors; // 0x10
	
		// Constructors
		static SubsystemDescriptorStore(); // 0x00000001822E8780-0x00000001822E88D0
	
		// Methods
		[RequiredByNativeCode]
		internal static void InitializeManagedDescriptor(IntPtr ptr, IntegratedSubsystemDescriptor desc); // 0x00000001822E83D0-0x00000001822E84C0
		[RequiredByNativeCode]
		internal static void ClearManagedDescriptors(); // 0x00000001822E8280-0x00000001822E83D0
		private static void ReportSingleSubsystemAnalytics(string id); // 0x00000001822E8600-0x00000001822E8780
		public static void RegisterDescriptor(SubsystemDescriptorWithProvider descriptor); // 0x00000001822E8530-0x00000001822E85C0
		internal static void GetSubsystemDescriptors<T>(List<T> descriptors)
			where T : ISubsystemDescriptor;
		private static void AddDescriptorSubset<TBaseTypeInList, TQueryType>(List<TBaseTypeInList> copyFrom, List<TQueryType> copyTo)
			where TBaseTypeInList : ISubsystemDescriptor
			where TQueryType : ISubsystemDescriptor;
		internal static void RegisterDescriptor<TDescriptor, TBaseTypeInList>(TDescriptor descriptor, List<TBaseTypeInList> storeInList)
			where TDescriptor : TBaseTypeInList
			where TBaseTypeInList : ISubsystemDescriptor;
		internal static void RegisterDeprecatedDescriptor(SubsystemDescriptor descriptor); // 0x00000001822E84C0-0x00000001822E8530
		private static void ReportSingleSubsystemAnalytics_Injected(ref ManagedSpanWrapper id); // 0x00000001822E85C0-0x00000001822E8600
	}
}
