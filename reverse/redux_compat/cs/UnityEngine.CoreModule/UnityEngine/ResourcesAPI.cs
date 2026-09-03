/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	public class ResourcesAPI // TypeDefIndex: 7703
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static readonly ResourcesAPI s_DefaultAPI; // 0x00
		[CompilerGenerated]
		private static ResourcesAPI _overrideAPI_k__BackingField; // 0x08
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x10
	
		// Properties
		internal static ResourcesAPI ActiveAPI { get; } // 0x00000001821F8D40-0x00000001821F8DE0 
		[AutoStaticsCleanupOnCodeReload]
		public static ResourcesAPI overrideAPI { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001821F8DE0-0x00000001821F8E30 0x00000001821F8E30-0x00000001821F8EA0
	
		// Constructors
		protected internal ResourcesAPI(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static ResourcesAPI(); // 0x00000001821F8BE0-0x00000001821F8D40
	
		// Methods
		protected internal virtual Object[] FindObjectsOfTypeAll(Type systemTypeInstance); // 0x00000001821F89B0-0x00000001821F89F0
		protected internal virtual Shader FindShaderByName(string name); // 0x00000001821F89F0-0x00000001821F8A00
		protected internal virtual Object Load(string path, Type systemTypeInstance); // 0x00000001821F8A90-0x00000001821F8AB0
		protected internal virtual Object[] LoadAll(string path, Type systemTypeInstance); // 0x00000001821F8A00-0x00000001821F8A20
		protected internal virtual ResourceRequest LoadAsync(string path, Type systemTypeInstance); // 0x00000001821F8A20-0x00000001821F8A90
		protected internal virtual void UnloadAsset(Object assetToUnload); // 0x00000001821F8AB0-0x00000001821F8AF0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001821F8AF0-0x00000001821F8BE0
	}
}
