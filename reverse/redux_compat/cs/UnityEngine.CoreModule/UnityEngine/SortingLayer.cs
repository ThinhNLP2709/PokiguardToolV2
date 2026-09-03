/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/BaseClasses/TagManager.h")]
	public struct SortingLayer // TypeDefIndex: 7471
	{
		// Fields
		private int m_Id; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		public static LayerCallback onLayerAdded; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		public static LayerCallback onLayerRemoved; // 0x08
		[AutoStaticsCleanupOnCodeReload]
		internal static LayerChangedCallback onLayerChanged; // 0x10
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x18
	
		// Nested types
		public delegate void LayerCallback(SortingLayer layer); // TypeDefIndex: 7472; 0x00000001804A78A0-0x00000001804A78B0
	
		internal delegate void LayerChangedCallback(); // TypeDefIndex: 7473; 0x0000000180313920-0x00000001803139C0
	
		// Constructors
		static SortingLayer(); // 0x0000000182194530-0x0000000182194650
	
		// Methods
		[FreeFunction("GetTagManager().GetSortingLayerValueFromUniqueID")]
		public static int GetLayerValueFromID(int id); // 0x0000000182194410-0x0000000182194450
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x0000000182194450-0x0000000182194530
	}
}
