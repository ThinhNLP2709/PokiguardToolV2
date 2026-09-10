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

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerFx : MonoBehaviour // TypeDefIndex: 2391
	{
		// Fields
		public const string FLAG = "infoplayer.fx"; // Metadata: 0x0068EE34
		public const string SWEEP_SPRITE = "Image/InfoPlayer/sweep"; // Metadata: 0x0068EE42
		[Tooltip("Khung 1774\u00D7887 \u2014 hi\u1EC7u \u1EE9ng m\u1EDF popup ch\u1EA1y tr\u00EAn ch\u00EDnh node n\u00E0y.")]
		public InfoPlayerFitRoot fitRoot; // 0x20
		[Tooltip("\u00D4 ch\u1EEF d\u00F9ng l\u00E0m KHU\u00D4N cho d\u00F2ng \'+N\' bay l\u00EAn (th\u01B0\u1EDDng l\u00E0 txt_EquipPowerValue). Kh\u00F4ng b\u1ECB \u0111\u1EE5ng t\u1EDBi, ch\u1EC9 nh\u00E2n b\u1EA3n.")]
		public UnityEngine.UI.Text statDeltaTemplate; // 0x28
		private InfoPlayerTapSpark _spark; // 0x30
		private readonly List<Transform> _pulsing; // 0x38
		private bool _flag; // 0x40
		private bool _flagRead; // 0x41
	
		// Properties
		public bool Enabled { get; } // 0x00000001807DEC00-0x00000001807DECC0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass14_0 // TypeDefIndex: 2392
		{
			// Fields
			public RectTransform rt; // 0x10
	
			// Constructors
			public __c__DisplayClass14_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _CoSweep_b__0(float v); // 0x00000001807F55F0-0x00000001807F5680
		}
	
		[CompilerGenerated]
		private sealed class _CoSweep_d__14 : IEnumerator<object> // TypeDefIndex: 2393
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public RectTransform slot; // 0x20
			private RectMask2D _mask_5__2; // 0x28
			private bool _addedMask_5__3; // 0x30
			private GameObject _go_5__4; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _CoSweep_d__14(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001807F4680-0x00000001807F46C0
			private bool MoveNext(); // 0x00000001807F3E00-0x00000001807F4640
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807F4640-0x00000001807F4680
		}
	
		// Constructors
		public InfoPlayerFx(); // 0x00000001807DEB80-0x00000001807DEC00
	
		// Methods
		public void RefreshFlag(); // 0x00000001807DE680-0x00000001807DE690
		private void OnDisable(); // 0x00000001807DDDC0-0x00000001807DDFC0
		public void PlayOpen(); // 0x00000001807DDFC0-0x00000001807DE260
		public void SweepSlot(RectTransform slot); // 0x00000001807DEA00-0x00000001807DEAF0
		[IteratorStateMachine(typeof(_CoSweep_d__14))]
		private IEnumerator CoSweep(RectTransform slot); // 0x00000001807DD980-0x00000001807DD9F0
		public void ShowPowerDelta(long delta, RectTransform anchor); // 0x00000001807DE690-0x00000001807DE7C0
		public void Spark(RectTransform anchor); // 0x00000001807DE7C0-0x00000001807DE880
		private void EnsureSpark(); // 0x00000001807DD9F0-0x00000001807DDDC0
		public void PulseNewBadges(EquipSlotsPresenter presenter); // 0x00000001807DE260-0x00000001807DE680
		private void StopPulses(); // 0x00000001807DE880-0x00000001807DEA00
		[CompilerGenerated]
		private void _PlayOpen_b__12_0(); // 0x00000001807DEAF0-0x00000001807DEB80
	}
}
