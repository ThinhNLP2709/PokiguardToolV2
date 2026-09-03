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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyCheckInAdapter : MonoBehaviour // TypeDefIndex: 1900
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
		private const float POLL_SEC = 0.4f; // Metadata: 0x0064DDD4
		private const string LABEL_READY = "\u0110i\u1EC3m Danh"; // Metadata: 0x0064DDD8
		private const string LABEL_DONE = "\u0110\u00E3 \u0110i\u1EC3m Danh"; // Metadata: 0x0064DDE5
		private const string COUNT_PREFIX = "S\u1ED1 l\u1EA7n \u0111i\u1EC3m danh: "; // Metadata: 0x0064DDF7
		private readonly List<DayButton> _buf; // 0x40
		private int _lastCount; // 0x48
		private bool _lastReady; // 0x4C
	
		// Nested types
		[CompilerGenerated]
		private sealed class _Loop_d__13 : IEnumerator<object> // TypeDefIndex: 1901
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PokyCheckInAdapter __4__this; // 0x20
			private WaitForSeconds _wait_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _Loop_d__13(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
			private bool MoveNext(); // 0x000000018063C5C0-0x000000018063C690
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018063C690-0x000000018063C6D0
		}
	
		// Constructors
		public PokyCheckInAdapter(); // 0x0000000180629B40-0x0000000180629BD0
	
		// Methods
		private void Awake(); // 0x0000000180629330-0x0000000180629450
		private void OnEnable(); // 0x0000000180629750-0x00000001806297D0
		[IteratorStateMachine(typeof(_Loop_d__13))]
		private IEnumerator Loop(); // 0x00000001806295B0-0x0000000180629620
		private DayButton FindClaimable(); // 0x0000000180629450-0x00000001806295B0
		private void Refresh(); // 0x00000001806297D0-0x0000000180629B40
		private void OnClickCheckIn(); // 0x0000000180629620-0x0000000180629750
	}
}
