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

public class PointerSpin : MonoBehaviour // TypeDefIndex: 2142
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
	private sealed class _CheckWheelCount_d__25 : IEnumerator<object> // TypeDefIndex: 2143
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PointerSpin __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CheckWheelCount_d__25(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A1C490-0x0000000180A1C760
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A1C760-0x0000000180A1C7A0
	}

	[CompilerGenerated]
	private sealed class _ShowAnimationThenPanelThenUpdateStar_d__39 : IEnumerator<object> // TypeDefIndex: 2144
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PointerSpin __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowAnimationThenPanelThenUpdateStar_d__39(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A1C7A0-0x0000000180A1CD20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A1CD20-0x0000000180A1CD60
	}

	[CompilerGenerated]
	private sealed class _SpinPointerToAngle_d__36 : IEnumerator<object> // TypeDefIndex: 2145
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PointerSpin __4__this; // 0x20
		public float serverAngle; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SpinPointerToAngle_d__36(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A1CD60-0x0000000180A1D050
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A1D050-0x0000000180A1D090
	}

	[CompilerGenerated]
	private sealed class _SpinWheelAPI_d__33 : IEnumerator<object> // TypeDefIndex: 2146
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PointerSpin __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SpinWheelAPI_d__33(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A1D090-0x0000000180A1D480
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A1D480-0x0000000180A1D4C0
	}

	// Constructors
	public PointerSpin(); // 0x0000000180A1C390-0x0000000180A1C460

	// Methods
	private void OnDisable(); // 0x00000001808B4110-0x00000001808B4120
	private void Start(); // 0x0000000180A195A0-0x0000000180A19940
	private void OnEnable(); // 0x0000000180A19940-0x0000000180A19A70
	[IteratorStateMachine(typeof(_CheckWheelCount_d__25))]
	private IEnumerator CheckWheelCount(); // 0x0000000180A19A70-0x0000000180A19B10
	private void UpdateWheelUI(); // 0x0000000180A19B10-0x0000000180A19CB0
	private void UpdateYourWheelUI(); // 0x0000000180A19CB0-0x0000000180A19E50
	private void OnSpinButtonClicked(); // 0x0000000180A19E50-0x0000000180A19E70
	private void ShowNoWheelPanel(); // 0x0000000180A19E70-0x0000000180A1A150
	private void UpdateUI(); // 0x0000000180A1A150-0x0000000180A1A3D0
	private void Update(); // 0x0000000180A1A3D0-0x0000000180A1A6E0
	private void StartSpin(); // 0x0000000180A1A6E0-0x0000000180A1A8F0
	[IteratorStateMachine(typeof(_SpinWheelAPI_d__33))]
	private IEnumerator SpinWheelAPI(); // 0x0000000180A1A8F0-0x0000000180A1A990
	private void OnSpinSuccess(SpinWheelResponse response); // 0x0000000180A1A990-0x0000000180A1AFF0
	private void OnSpinError(string error); // 0x0000000180A1AFF0-0x0000000180A1B1A0
	[IteratorStateMachine(typeof(_SpinPointerToAngle_d__36))]
	private IEnumerator SpinPointerToAngle(float serverAngle); // 0x0000000180A1B1A0-0x0000000180A1B260
	private void OnSpinComplete(); // 0x0000000180A1B260-0x0000000180A1B6B0
	private void UpdateResultTextWithOutline(string prize); // 0x0000000180A1B6B0-0x0000000180A1BB40
	[IteratorStateMachine(typeof(_ShowAnimationThenPanelThenUpdateStar_d__39))]
	private IEnumerator ShowAnimationThenPanelThenUpdateStar(); // 0x0000000180A1BB40-0x0000000180A1BBE0
	private void UpdateStarWithEffect(); // 0x0000000180A1BBE0-0x0000000180A1BF10
	private void PlayStarAddEffect(); // 0x000000018028A320-0x000000018028A330
	private void ClosePanelResult(); // 0x0000000180A1BF10-0x0000000180A1C050
	private void OnError(string error); // 0x0000000180A1C050-0x0000000180A1C0D0
	private void OnDestroy(); // 0x0000000180A1C0D0-0x0000000180A1C390
	[CompilerGenerated]
	private void _CheckWheelCount_b__25_0(SpinWheelResponse response); // 0x0000000180A1C460-0x0000000180A1C490
}

