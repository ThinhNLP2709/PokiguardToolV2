/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokySettingsPopup : MonoBehaviour // TypeDefIndex: 2197
	{
		// Fields
		private const string KEY_MASTER = "MasterVolume"; // Metadata: 0x0068E18E
		private const string KEY_BGM = "BGMVolume"; // Metadata: 0x0068E19B
		private const string KEY_SFX = "SFXVolume"; // Metadata: 0x0068E1A5
		private const float DEFAULT_BGM = 0.5f; // Metadata: 0x0068E1AF
		private const float DEFAULT_SFX = 0.8f; // Metadata: 0x0068E1B3
		private const float OFF_THRESHOLD = 0.01f; // Metadata: 0x0068E1B7
		[Tooltip("B\u1EA3ng c\u00E0i \u0111\u1EB7t g\u1ED1c (m\u1EDF/\u0111\u00F3ng + \u0111\u0103ng xu\u1EA5t) tr\u00EAn c\u00F9ng GameObject.")]
		public HomeSettingsPopup basePopup; // 0x20
		[Tooltip("C\u00F4ng t\u1EAFc \'\u0110ang b\u1EADn\' \u2014 PokyHubBinder tr\u1ECF ManagerQuangTruong.toggleBusy v\u00E0o \u0111\u00E2y.")]
		public Toggle toggleBusy; // 0x28
		[Tooltip("N\u00FAt m\u1EDF \u0110i\u1EC1u kho\u1EA3n s\u1EED d\u1EE5ng.")]
		public Button termsButton; // 0x30
		[Header("\u00C2m thanh (thi\u1EBFt k\u1EBF g\u1ED1c Poky: n\u00FAt b\u1EADt/t\u1EAFt, kh\u00F4ng ph\u1EA3i thanh tr\u01B0\u1EE3t)")]
		public Button bgmButton; // 0x38
		public Image bgmImage; // 0x40
		public Button sfxButton; // 0x48
		public Image sfxImage; // 0x50
		[Tooltip("Setting::btnSound0001 \u2014 tr\u1EA1ng th\u00E1i B\u1EACT.")]
		public Sprite spriteSoundOn; // 0x58
		[Tooltip("Setting::btnSound0002 \u2014 tr\u1EA1ng th\u00E1i T\u1EAET.")]
		public Sprite spriteSoundOff; // 0x60
		private static bool _termsLoading; // 0x00
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass28_0 // TypeDefIndex: 2198
		{
			// Fields
			public TermsContentData data; // 0x10
	
			// Constructors
			public __c__DisplayClass28_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _FetchThenShow_b__0(TermsContentData c); // 0x0000000180317090-0x00000001803170A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass29_0 // TypeDefIndex: 2199
		{
			// Fields
			public TermsContentData data; // 0x10
			public int userId; // 0x18
	
			// Constructors
			public __c__DisplayClass29_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _ShowTermsPanel_b__0(GameObject panel); // 0x000000018077D030-0x000000018077D180
		}
	
		[CompilerGenerated]
		private sealed class _FetchThenShow_d__28 : IEnumerator<object> // TypeDefIndex: 2200
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			private __c__DisplayClass28_0 __8__1; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _FetchThenShow_d__28(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001804AE160-0x00000001804AE190
			private bool MoveNext(); // 0x0000000180778BE0-0x0000000180778DB0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180778DB0-0x0000000180778DF0
		}
	
		// Constructors
		public PokySettingsPopup(); // 0x00000001802EBA70-0x00000001802EBAF0
	
		// Methods
		private void Awake(); // 0x0000000180777260-0x0000000180777450
		private void OnEnable(); // 0x0000000180777750-0x0000000180777760
		private void OnDestroy(); // 0x00000001807775A0-0x0000000180777750
		public void Open(); // 0x0000000180777990-0x0000000180777A10
		public void Close(); // 0x0000000180777450-0x00000001807774D0
		private void OnBgmClicked(); // 0x0000000180777520-0x00000001807775A0
		private void OnSfxClicked(); // 0x0000000180777760-0x00000001807777F0
		private void ApplyAudio(); // 0x0000000180777190-0x0000000180777260
		public void RefreshSoundIcons(); // 0x0000000180777A10-0x0000000180777BB0
		private void SetSoundIcon(Image img, bool on); // 0x0000000180777BB0-0x0000000180777C50
		private void OnTermsClicked(); // 0x00000001807777F0-0x0000000180777810
		public static void OpenTerms(MonoBehaviour host); // 0x0000000180777810-0x0000000180777990
		[IteratorStateMachine(typeof(_FetchThenShow_d__28))]
		private static IEnumerator FetchThenShow(); // 0x00000001807774D0-0x0000000180777520
		private static void ShowTermsPanel(TermsContentData data); // 0x0000000180777C50-0x0000000180777DB0
	}
}
