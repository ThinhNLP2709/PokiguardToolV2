/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class SlotMachine : MonoBehaviour // TypeDefIndex: 1260
{
	// Fields
	public List<SlotColumn> columns; // 0x20
	public List<UvAnimation> uvColumns; // 0x28
	public HorizontalLayoutGroup slotLayout; // 0x30
	public SpinBtn spinBtn; // 0x38
	public List<SlotResource> resources; // 0x40
	public List<BlurryResource> blurryResources; // 0x48
	[SerializeField]
	private BlurLevel blurLevel; // 0x50
	[Range(0.8f, 1f)]
	[SerializeField]
	private float shaderBlurAmount; // 0x54
	[SerializeField]
	private Vector2 shaderSlotTiling; // 0x58
	[Range(0f, 10f)]
	[SerializeField]
	private float spinSpeed; // 0x60
	public Ease easeIn; // 0x64
	[Range(0f, 5f)]
	public float speedIn; // 0x68
	public float startYPosIn; // 0x6C
	public float targetYPosIn; // 0x70
	public Ease easeOut; // 0x74
	[Range(0f, 5f)]
	public float speedOut; // 0x78
	public float startYPosOut; // 0x7C
	public float targetYPosOut; // 0x80
	public Vector2 spinDuration; // 0x84
	[SerializeField]
	private float delayAmongSlots; // 0x8C
	[HideInInspector]
	public float randomSpinDuration; // 0x90

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass30_0 // TypeDefIndex: 1261
	{
		// Fields
		public BlurLevel level; // 0x10

		// Constructors
		public __c__DisplayClass30_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal bool _GetBlurrySprite_b__0(BlurryResource r); // 0x00000001805A5790-0x00000001805A57A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass31_0 // TypeDefIndex: 1262
	{
		// Fields
		public SlotType type; // 0x10

		// Constructors
		public __c__DisplayClass31_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal bool _GetSlotByType_b__0(SlotResource r); // 0x00000001805A5790-0x00000001805A57A0
	}

	[CompilerGenerated]
	private sealed class _WaitAndSpinNext_d__28 : IEnumerator<object> // TypeDefIndex: 1263
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public SlotMachine __4__this; // 0x20
		public int nextIndex; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndSpinNext_d__28(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805A6600-0x00000001805A66C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A66C0-0x00000001805A6700
	}

	// Constructors
	public SlotMachine(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Start(); // 0x00000001805A2560-0x00000001805A2780
	private void OnDestroy(); // 0x00000001805A22D0-0x00000001805A2340
	private void OnColumnSpinComplete(int index); // 0x00000001805A2200-0x00000001805A22D0
	public void StartSpin(); // 0x00000001805A2500-0x00000001805A2560
	public void StopSpinWithResult(List<SlotType> topRow); // 0x00000001805A2780-0x00000001805A28A0
	public void StopSpin(); // 0x00000001805A28A0-0x00000001805A29C0
	private void SpinColumn(int index); // 0x00000001805A2340-0x00000001805A2500
	[IteratorStateMachine(typeof(_WaitAndSpinNext_d__28))]
	private IEnumerator WaitAndSpinNext(int nextIndex); // 0x00000001805A29C0-0x00000001805A2A40
	public void UVAnimationVisibility(int index, bool status); // 0x00000001802EB6C0-0x00000001802EB6D0
	public Sprite GetBlurrySprite(BlurLevel level, int index); // 0x00000001805A2020-0x00000001805A2110
	public SlotResource GetSlotByType(SlotType type); // 0x00000001805A2110-0x00000001805A2200
}

