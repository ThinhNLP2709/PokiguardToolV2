/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Windows.Speech
{
	public static class PhraseRecognitionSystem // TypeDefIndex: 7882
	{
		// Fields
		[CompilerGenerated]
		private static ErrorDelegate OnError; // 0x00
		[CompilerGenerated]
		private static StatusDelegate OnStatusChanged; // 0x08
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x10
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event ErrorDelegate OnError {
			add; // 0x0000000182209530-0x0000000182209600
			remove; // 0x00000001822096D0-0x00000001822097A0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event StatusDelegate OnStatusChanged {
			add; // 0x0000000182209600-0x00000001822096D0
			remove; // 0x00000001822097A0-0x0000000182209870
		}
	
		// Nested types
		public delegate void ErrorDelegate(SpeechError errorCode); // TypeDefIndex: 7883; 0x00000001804A78A0-0x00000001804A78B0
	
		public delegate void StatusDelegate(SpeechSystemStatus status); // TypeDefIndex: 7884; 0x00000001804A78A0-0x00000001804A78B0
	
		// Constructors
		static PhraseRecognitionSystem(); // 0x0000000182209390-0x0000000182209530
	
		// Methods
		[RequiredByNativeCode]
		private static void PhraseRecognitionSystem_InvokeErrorEvent(SpeechError errorCode); // 0x0000000182208F90-0x0000000182209000
		[RequiredByNativeCode]
		private static void PhraseRecognitionSystem_InvokeStatusChangedEvent(SpeechSystemStatus status); // 0x0000000182209000-0x0000000182209070
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x0000000182209070-0x0000000182209390
	}
}
