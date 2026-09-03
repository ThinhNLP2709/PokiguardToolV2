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

public class PointerSpin : MonoBehaviour // TypeDefIndex: 1516
{
	// Fields
	[Header("Pointer Settings")]
	public Transform pointerTransform; // 0x20
	public float spinDuration; // 0x28
	public AnimationCurve spinCurve; // 0x30
	[Header("UI Elements")]
	public Button spinButton; // 0x38
	public UnityEngine.UI.Text resultText; // 0x40
	public UnityEngine.UI.Text titleText; // 0x48
	public UnityEngine.UI.Text countdownText; // 0x50
	public UnityEngine.UI.Text yourWheel; // 0x58
	[Header("Result Panel")]
	public GameObject panelResult; // 0x60
	public Button btnOke; // 0x68
	public Animator animatorRW; // 0x70
	public string animationName; // 0x78
	[Header("Visual Effects")]
	public ParticleSystem spinParticles; // 0x80
	public ParticleSystem winParticles; // 0x88
	[Header("Star Update Settings")]
	public float starUpdateDelay; // 0x90
	private bool isSpinning; // 0x94
	private float targetAngle; // 0x98
	private float startAngle; // 0x9C
	private float spinStartTime; // 0xA0
	private int currentWheelCount; // 0xA4
	private int userId; // 0xA8
	private SpinWheelResponse spinResult; // 0xB0

	// Nested types
	[CompilerGenerated]
	private sealed class _CheckWheelCount_d__25 : IEnumerator<object> // TypeDefIndex: 1517
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PointerSpin __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CheckWheelCount_d__25(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805793E0-0x0000000180579560
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180579560-0x00000001805795A0
	}

	[CompilerGenerated]
	private sealed class _ShowAnimationThenPanelThenUpdateStar_d__39 : IEnumerator<object> // TypeDefIndex: 1518
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PointerSpin __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ShowAnimationThenPanelThenUpdateStar_d__39(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018057D700-0x000000018057D990
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057D990-0x000000018057D9D0
	}

	[CompilerGenerated]
	private sealed class _SpinPointerToAngle_d__36 : IEnumerator<object> // TypeDefIndex: 1519
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PointerSpin __4__this; // 0x20
		public float serverAngle; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SpinPointerToAngle_d__36(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018057D9D0-0x000000018057DB30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057DB30-0x000000018057DB70
	}

	[CompilerGenerated]
	private sealed class _SpinWheelAPI_d__33 : IEnumerator<object> // TypeDefIndex: 1520
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PointerSpin __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SpinWheelAPI_d__33(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018057DB70-0x000000018057DDA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057DDA0-0x000000018057DDE0
	}

	// Constructors
	public PointerSpin(); // 0x0000000180570990-0x00000001805709F0

	// Methods
	private void OnDisable(); // 0x00000001804A3A80-0x00000001804A3A90
	private void Start(); // 0x000000018056FC90-0x000000018056FF30
	private void OnEnable(); // 0x000000018056EEF0-0x000000018056EFA0
	[IteratorStateMachine(typeof(_CheckWheelCount_d__25))]
	private IEnumerator CheckWheelCount(); // 0x000000018056ECC0-0x000000018056ED30
	private void UpdateWheelUI(); // 0x0000000180570610-0x00000001805706D0
	private void UpdateYourWheelUI(); // 0x00000001805706D0-0x0000000180570790
	private void OnSpinButtonClicked(); // 0x000000018056F010-0x000000018056F220
	private void ShowNoWheelPanel(); // 0x000000018056F9A0-0x000000018056FAA0
	private void UpdateUI(); // 0x00000001805704F0-0x0000000180570610
	private void Update(); // 0x0000000180570790-0x0000000180570990
	private void StartSpin(); // 0x000000018056FB90-0x000000018056FC90
	[IteratorStateMachine(typeof(_SpinWheelAPI_d__33))]
	private IEnumerator SpinWheelAPI(); // 0x000000018056FB20-0x000000018056FB90
	private void OnSpinSuccess(SpinWheelResponse response); // 0x000000018056F520-0x000000018056F930
	private void OnSpinError(string error); // 0x000000018056F3C0-0x000000018056F520
	[IteratorStateMachine(typeof(_SpinPointerToAngle_d__36))]
	private IEnumerator SpinPointerToAngle(float serverAngle); // 0x000000018056FAA0-0x000000018056FB20
	private void OnSpinComplete(); // 0x000000018056F220-0x000000018056F3C0
	private void UpdateResultTextWithOutline(string prize); // 0x000000018056FF60-0x0000000180570290
	[IteratorStateMachine(typeof(_ShowAnimationThenPanelThenUpdateStar_d__39))]
	private IEnumerator ShowAnimationThenPanelThenUpdateStar(); // 0x000000018056F930-0x000000018056F9A0
	private void UpdateStarWithEffect(); // 0x0000000180570290-0x00000001805704F0
	private void PlayStarAddEffect(); // 0x00000001802E76C0-0x00000001802E76D0
	private void ClosePanelResult(); // 0x000000018056ED30-0x000000018056EDB0
	private void OnError(string error); // 0x000000018056EFA0-0x000000018056F010
	private void OnDestroy(); // 0x000000018056EDB0-0x000000018056EEF0
	[CompilerGenerated]
	private void _CheckWheelCount_b__25_0(SpinWheelResponse response); // 0x000000018056FF30-0x000000018056FF60
}

