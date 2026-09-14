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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokySettingsPopup : MonoBehaviour // TypeDefIndex: 2640
	{
		// Fields
		private const string KEY_MASTER = "MasterVolume"; // Metadata: 0x005F26C3
		private const string KEY_BGM = "BGMVolume"; // Metadata: 0x005F26D0
		private const string KEY_SFX = "SFXVolume"; // Metadata: 0x005F26DA
		private const float DEFAULT_BGM = 0.5f; // Metadata: 0x005F26E4
		private const float DEFAULT_SFX = 0.8f; // Metadata: 0x005F26E8
		private const float OFF_THRESHOLD = 0.01f; // Metadata: 0x005F26EC
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
		private sealed class __c__DisplayClass28_0 // TypeDefIndex: 2641
		{
			// Fields
			public TermsContentData data; // 0x10
	
			// Constructors
			public __c__DisplayClass28_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _FetchThenShow_b__0(TermsContentData c); // 0x00000001802D8AB0-0x00000001802D8B10
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass29_0 // TypeDefIndex: 2642
		{
			// Fields
			public TermsContentData data; // 0x10
			public int userId; // 0x18
	
			// Constructors
			public __c__DisplayClass29_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _ShowTermsPanel_b__0(GameObject panel); // 0x0000000180C29BB0-0x0000000180C29DF0
		}
	
		[CompilerGenerated]
		private sealed class _FetchThenShow_d__28 : IEnumerator<object> // TypeDefIndex: 2643
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			private __c__DisplayClass28_0 __8__1; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _FetchThenShow_d__28(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001805EFDE0-0x00000001805EFE50
			private bool MoveNext(); // 0x0000000180C29DF0-0x0000000180C2A0C0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C2A0C0-0x0000000180C2A100
		}
	
		// Constructors
		public PokySettingsPopup(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void Awake(); // 0x0000000180C28480-0x0000000180C28890
		private void OnEnable(); // 0x0000000180C28890-0x0000000180C288A0
		private void OnDestroy(); // 0x0000000180C288A0-0x0000000180C28C50
		public void Open(); // 0x0000000180C28C50-0x0000000180C28D50
		public void Close(); // 0x0000000180C28D50-0x0000000180C28E50
		private void OnBgmClicked(); // 0x0000000180C28E50-0x0000000180C28F10
		private void OnSfxClicked(); // 0x0000000180C28F10-0x0000000180C29020
		private void ApplyAudio(); // 0x0000000180C29020-0x0000000180C291C0
		public void RefreshSoundIcons(); // 0x0000000180C291C0-0x0000000180C29280
		private void SetSoundIcon(Image img, bool on); // 0x0000000180C29280-0x0000000180C29420
		private void OnTermsClicked(); // 0x0000000180C29420-0x0000000180C29440
		public static void OpenTerms(MonoBehaviour host); // 0x0000000180C29440-0x0000000180C29610
		[IteratorStateMachine(typeof(_FetchThenShow_d__28))]
		private static IEnumerator FetchThenShow(); // 0x0000000180C29610-0x0000000180C29650
		private static void ShowTermsPanel(TermsContentData data); // 0x0000000180C29650-0x0000000180C29BB0
	}
}
