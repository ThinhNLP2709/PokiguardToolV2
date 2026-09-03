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

namespace UnityEngine.SceneManagement
{
	public class SceneManagerAPI // TypeDefIndex: 8003
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static readonly SceneManagerAPI s_DefaultAPI; // 0x00
		[CompilerGenerated]
		private static SceneManagerAPI _overrideAPI_k__BackingField; // 0x08
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x10
	
		// Properties
		internal static SceneManagerAPI ActiveAPI { get; } // 0x0000000182250880-0x0000000182250920 
		[AutoStaticsCleanupOnCodeReload]
		public static SceneManagerAPI overrideAPI { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182250920-0x0000000182250970 0x0000000182250970-0x00000001822509E0
	
		// Constructors
		protected internal SceneManagerAPI(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static SceneManagerAPI(); // 0x0000000182250720-0x0000000182250880
	
		// Methods
		protected internal virtual AsyncOperation LoadSceneAsyncByNameOrIndex(string sceneName, int sceneBuildIndex, LoadSceneParameters parameters, bool mustCompleteNextFrame); // 0x00000001822505C0-0x00000001822505F0
		protected internal virtual AsyncOperation UnloadSceneAsyncByNameOrIndex(string sceneName, int sceneBuildIndex, bool immediately, UnloadSceneOptions options, out bool outSuccess); // 0x00000001822505F0-0x0000000182250630
		protected internal virtual AsyncOperation LoadFirstScene(bool mustLoadAsync); // 0x00000001802E7860-0x00000001802E7870
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x0000000182250630-0x0000000182250720
	}
}
