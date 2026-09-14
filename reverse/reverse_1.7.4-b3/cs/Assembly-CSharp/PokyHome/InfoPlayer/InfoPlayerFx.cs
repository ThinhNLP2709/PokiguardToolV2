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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerFx : MonoBehaviour // TypeDefIndex: 2836
	{
		// Fields
		public const string FLAG = "infoplayer.fx"; // Metadata: 0x005F1CB0
		public const string SWEEP_SPRITE = "Image/InfoPlayer/sweep"; // Metadata: 0x005F1CBE
		[Tooltip("Khung 1774\u00D7887 \u2014 hi\u1EC7u \u1EE9ng m\u1EDF popup ch\u1EA1y tr\u00EAn ch\u00EDnh node n\u00E0y.")]
		public InfoPlayerFitRoot fitRoot; // 0x20
		[Tooltip("\u00D4 ch\u1EEF d\u00F9ng l\u00E0m KHU\u00D4N cho d\u00F2ng \'+N\' bay l\u00EAn (th\u01B0\u1EDDng l\u00E0 txt_EquipPowerValue). Kh\u00F4ng b\u1ECB \u0111\u1EE5ng t\u1EDBi, ch\u1EC9 nh\u00E2n b\u1EA3n.")]
		public UnityEngine.UI.Text statDeltaTemplate; // 0x28
		private InfoPlayerTapSpark _spark; // 0x30
		private readonly List<Transform> _pulsing; // 0x38
		private bool _flag; // 0x40
		private bool _flagRead; // 0x41
		private static bool _globalFlag; // 0x00
		private static bool _globalFlagRead; // 0x01
	
		// Properties
		public bool Enabled { get; } // 0x0000000180CF4290-0x0000000180CF4370 
		public static bool EnabledGlobally { get; } // 0x0000000180CF43C0-0x0000000180CF44F0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass19_0 // TypeDefIndex: 2837
		{
			// Fields
			public RectTransform rt; // 0x10
	
			// Constructors
			public __c__DisplayClass19_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _CoSweep_b__0(float v); // 0x0000000180CF6970-0x0000000180CF6A80
		}
	
		[CompilerGenerated]
		private sealed class _CoSweep_d__19 : IEnumerator<object> // TypeDefIndex: 2838
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public RectTransform slot; // 0x20
			private RectMask2D _mask_5__2; // 0x28
			private bool _addedMask_5__3; // 0x30
			private GameObject _go_5__4; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _CoSweep_d__19(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180CF6A80-0x0000000180CF6BB0
			private bool MoveNext(); // 0x0000000180CF6BB0-0x0000000180CF79B0
			private void __m__Finally1(); // 0x0000000180CF79B0-0x0000000180CF7C10
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180CF7C10-0x0000000180CF7C50
		}
	
		// Constructors
		public InfoPlayerFx(); // 0x0000000180CF66C0-0x0000000180CF6820
	
		// Methods
		public void RefreshFlag(); // 0x0000000180CF4370-0x0000000180CF43C0
		private void OnDisable(); // 0x0000000180CF44F0-0x0000000180CF4A30
		public void PlayOpen(); // 0x0000000180CF4A30-0x0000000180CF4EA0
		public void SweepSlot(RectTransform slot); // 0x0000000180CF4EA0-0x0000000180CF5020
		public static void SweepOnce(MonoBehaviour host, RectTransform target); // 0x0000000180CF5020-0x0000000180CF5210
		[IteratorStateMachine(typeof(_CoSweep_d__19))]
		private static IEnumerator CoSweep(RectTransform slot); // 0x0000000180CF5210-0x0000000180CF52B0
		public void ShowPowerDelta(long delta, RectTransform anchor); // 0x0000000180CF52B0-0x0000000180CF5460
		public void Spark(RectTransform anchor); // 0x0000000180CF5460-0x0000000180CF5700
		private void EnsureSpark(); // 0x0000000180CF5700-0x0000000180CF5F80
		public void PulseNewBadges(EquipSlotsPresenter presenter); // 0x0000000180CF5F80-0x0000000180CF6450
		private void StopPulses(); // 0x0000000180CF6450-0x0000000180CF66C0
		[CompilerGenerated]
		private void _PlayOpen_b__16_0(); // 0x0000000180CF6820-0x0000000180CF6970
	}
}
