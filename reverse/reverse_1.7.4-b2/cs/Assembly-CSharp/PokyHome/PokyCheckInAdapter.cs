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
	public class PokyCheckInAdapter : MonoBehaviour // TypeDefIndex: 2227
	{
		// Fields
		[Tooltip("DayContainer \u2014 n\u01A1i DailyCheckInManager Instantiate c\u00E1c \u00F4 ng\u00E0y.")]
		public Transform listRoot; // 0x20
		[Tooltip("N\u00FAt \'\u0110i\u1EC3m Danh\' c\u1EE7a khung Poky.")]
		public Button btnCheckIn; // 0x28
		[Tooltip("Ch\u1EEF tr\u00EAn n\u00FAt (\u0111\u1ED5i th\u00E0nh \'\u0110\u00E3 \u0110i\u1EC3m Danh\' khi h\u00F4m nay h\u1EBFt l\u01B0\u1EE3t).")]
		public UnityEngine.UI.Text btnLabel; // 0x30
		[Tooltip("D\u00F2ng \'S\u1ED1 l\u1EA7n \u0111i\u1EC3m danh: N\'.")]
		public UnityEngine.UI.Text txtCount; // 0x38
		private const float POLL_SEC = 0.4f; // Metadata: 0x0068E254
		private const string LABEL_READY = "\u0110i\u1EC3m Danh"; // Metadata: 0x0068E258
		private const string LABEL_DONE = "\u0110\u00E3 \u0110i\u1EC3m Danh"; // Metadata: 0x0068E265
		private const string COUNT_PREFIX = "S\u1ED1 l\u1EA7n \u0111i\u1EC3m danh: "; // Metadata: 0x0068E277
		private readonly List<DayButton> _buf; // 0x40
		private int _lastCount; // 0x48
		private bool _lastReady; // 0x4C
	
		// Nested types
		[CompilerGenerated]
		private sealed class _Loop_d__13 : IEnumerator<object> // TypeDefIndex: 2228
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyCheckInAdapter __4__this; // 0x20
			private WaitForSeconds _wait_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _Loop_d__13(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
			private bool MoveNext(); // 0x0000000180790BB0-0x0000000180790C80
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180790C80-0x0000000180790CC0
		}
	
		// Constructors
		public PokyCheckInAdapter(); // 0x000000018077E880-0x000000018077E910
	
		// Methods
		private void Awake(); // 0x000000018077E070-0x000000018077E190
		private void OnEnable(); // 0x000000018077E490-0x000000018077E510
		[IteratorStateMachine(typeof(_Loop_d__13))]
		private IEnumerator Loop(); // 0x000000018077E2F0-0x000000018077E360
		private DayButton FindClaimable(); // 0x000000018077E190-0x000000018077E2F0
		private void Refresh(); // 0x000000018077E510-0x000000018077E880
		private void OnClickCheckIn(); // 0x000000018077E360-0x000000018077E490
	}
}
