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

public class PointerSpin : MonoBehaviour // TypeDefIndex: 1779
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
	private sealed class _CheckWheelCount_d__25 : IEnumerator<object> // TypeDefIndex: 1780
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PointerSpin __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CheckWheelCount_d__25(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180697530-0x00000001806976B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806976B0-0x00000001806976F0
	}

	[CompilerGenerated]
	private sealed class _ShowAnimationThenPanelThenUpdateStar_d__39 : IEnumerator<object> // TypeDefIndex: 1781
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PointerSpin __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShowAnimationThenPanelThenUpdateStar_d__39(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018069B870-0x000000018069BCB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018069BCB0-0x000000018069BCF0
	}

	[CompilerGenerated]
	private sealed class _SpinPointerToAngle_d__36 : IEnumerator<object> // TypeDefIndex: 1782
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PointerSpin __4__this; // 0x20
		public float serverAngle; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SpinPointerToAngle_d__36(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018069BCF0-0x000000018069BE50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018069BE50-0x000000018069BE90
	}

	[CompilerGenerated]
	private sealed class _SpinWheelAPI_d__33 : IEnumerator<object> // TypeDefIndex: 1783
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PointerSpin __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SpinWheelAPI_d__33(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018069BE90-0x000000018069C0C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018069C0C0-0x000000018069C100
	}

	// Constructors
	public PointerSpin(); // 0x0000000180693A70-0x0000000180693AD0

	// Methods
	private void OnDisable(); // 0x000000018059BAC0-0x000000018059BAD0
	private void Start(); // 0x0000000180692E10-0x00000001806930B0
	private void OnEnable(); // 0x0000000180692070-0x0000000180692120
	[IteratorStateMachine(typeof(_CheckWheelCount_d__25))]
	private IEnumerator CheckWheelCount(); // 0x0000000180691E40-0x0000000180691EB0
	private void UpdateWheelUI(); // 0x00000001806936F0-0x00000001806937B0
	private void UpdateYourWheelUI(); // 0x00000001806937B0-0x0000000180693870
	private void OnSpinButtonClicked(); // 0x0000000180692190-0x00000001806923A0
	private void ShowNoWheelPanel(); // 0x0000000180692B20-0x0000000180692C20
	private void UpdateUI(); // 0x00000001806935D0-0x00000001806936F0
	private void Update(); // 0x0000000180693870-0x0000000180693A70
	private void StartSpin(); // 0x0000000180692D10-0x0000000180692E10
	[IteratorStateMachine(typeof(_SpinWheelAPI_d__33))]
	private IEnumerator SpinWheelAPI(); // 0x0000000180692CA0-0x0000000180692D10
	private void OnSpinSuccess(SpinWheelResponse response); // 0x00000001806926A0-0x0000000180692AB0
	private void OnSpinError(string error); // 0x0000000180692540-0x00000001806926A0
	[IteratorStateMachine(typeof(_SpinPointerToAngle_d__36))]
	private IEnumerator SpinPointerToAngle(float serverAngle); // 0x0000000180692C20-0x0000000180692CA0
	private void OnSpinComplete(); // 0x00000001806923A0-0x0000000180692540
	private void UpdateResultTextWithOutline(string prize); // 0x00000001806930E0-0x0000000180693410
	[IteratorStateMachine(typeof(_ShowAnimationThenPanelThenUpdateStar_d__39))]
	private IEnumerator ShowAnimationThenPanelThenUpdateStar(); // 0x0000000180692AB0-0x0000000180692B20
	private void UpdateStarWithEffect(); // 0x0000000180693410-0x00000001806935D0
	private void PlayStarAddEffect(); // 0x00000001802EB6C0-0x00000001802EB6D0
	private void ClosePanelResult(); // 0x0000000180691EB0-0x0000000180691F30
	private void OnError(string error); // 0x0000000180692120-0x0000000180692190
	private void OnDestroy(); // 0x0000000180691F30-0x0000000180692070
	[CompilerGenerated]
	private void _CheckWheelCount_b__25_0(SpinWheelResponse response); // 0x00000001806930B0-0x00000001806930E0
}

