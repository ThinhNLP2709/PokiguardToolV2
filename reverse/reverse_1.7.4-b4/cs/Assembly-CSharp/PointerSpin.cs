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

public class PointerSpin : MonoBehaviour // TypeDefIndex: 2144
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
	private sealed class _CheckWheelCount_d__25 : IEnumerator<object> // TypeDefIndex: 2145
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180A1FFB0-0x0000000180A202B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A202B0-0x0000000180A202F0
	}

	[CompilerGenerated]
	private sealed class _ShowAnimationThenPanelThenUpdateStar_d__39 : IEnumerator<object> // TypeDefIndex: 2146
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180A202F0-0x0000000180A20870
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A20870-0x0000000180A208B0
	}

	[CompilerGenerated]
	private sealed class _SpinPointerToAngle_d__36 : IEnumerator<object> // TypeDefIndex: 2147
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180A208B0-0x0000000180A20BA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A20BA0-0x0000000180A20BE0
	}

	[CompilerGenerated]
	private sealed class _SpinWheelAPI_d__33 : IEnumerator<object> // TypeDefIndex: 2148
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180A20BE0-0x0000000180A20FF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A20FF0-0x0000000180A21030
	}

	// Constructors
	public PointerSpin(); // 0x0000000180A1FEB0-0x0000000180A1FF80

	// Methods
	private void OnDisable(); // 0x00000001808B6A90-0x00000001808B6AA0
	private void Start(); // 0x0000000180A1D190-0x0000000180A1D530
	private void OnEnable(); // 0x0000000180A1D530-0x0000000180A1D690
	[IteratorStateMachine(typeof(_CheckWheelCount_d__25))]
	private IEnumerator CheckWheelCount(); // 0x0000000180A1D690-0x0000000180A1D730
	private void UpdateWheelUI(); // 0x0000000180A1D730-0x0000000180A1D8D0
	private void UpdateYourWheelUI(); // 0x0000000180A1D8D0-0x0000000180A1DA70
	private void OnSpinButtonClicked(); // 0x0000000180A1DA70-0x0000000180A1DA90
	private void ShowNoWheelPanel(); // 0x0000000180A1DA90-0x0000000180A1DD70
	private void UpdateUI(); // 0x0000000180A1DD70-0x0000000180A1DFF0
	private void Update(); // 0x0000000180A1DFF0-0x0000000180A1E300
	private void StartSpin(); // 0x0000000180A1E300-0x0000000180A1E530
	[IteratorStateMachine(typeof(_SpinWheelAPI_d__33))]
	private IEnumerator SpinWheelAPI(); // 0x0000000180A1E530-0x0000000180A1E5D0
	private void OnSpinSuccess(SpinWheelResponse response); // 0x0000000180A1E5D0-0x0000000180A1EAE0
	private void OnSpinError(string error); // 0x0000000180A1EAE0-0x0000000180A1ECC0
	[IteratorStateMachine(typeof(_SpinPointerToAngle_d__36))]
	private IEnumerator SpinPointerToAngle(float serverAngle); // 0x0000000180A1ECC0-0x0000000180A1ED80
	private void OnSpinComplete(); // 0x0000000180A1ED80-0x0000000180A1F1D0
	private void UpdateResultTextWithOutline(string prize); // 0x0000000180A1F1D0-0x0000000180A1F660
	[IteratorStateMachine(typeof(_ShowAnimationThenPanelThenUpdateStar_d__39))]
	private IEnumerator ShowAnimationThenPanelThenUpdateStar(); // 0x0000000180A1F660-0x0000000180A1F700
	private void UpdateStarWithEffect(); // 0x0000000180A1F700-0x0000000180A1FA30
	private void PlayStarAddEffect(); // 0x000000018028A320-0x000000018028A330
	private void ClosePanelResult(); // 0x0000000180A1FA30-0x0000000180A1FB70
	private void OnError(string error); // 0x0000000180A1FB70-0x0000000180A1FBF0
	private void OnDestroy(); // 0x0000000180A1FBF0-0x0000000180A1FEB0
	[CompilerGenerated]
	private void _CheckWheelCount_b__25_0(SpinWheelResponse response); // 0x0000000180A1FF80-0x0000000180A1FFB0
}

