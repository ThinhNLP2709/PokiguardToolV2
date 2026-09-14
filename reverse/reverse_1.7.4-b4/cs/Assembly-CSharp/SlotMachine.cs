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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class SlotMachine : MonoBehaviour // TypeDefIndex: 1663
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
	private sealed class __c__DisplayClass30_0 // TypeDefIndex: 1664
	{
		// Fields
		public BlurLevel level; // 0x10

		// Constructors
		public __c__DisplayClass30_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _GetBlurrySprite_b__0(BlurryResource r); // 0x00000001808B1FA0-0x00000001808B1FB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass31_0 // TypeDefIndex: 1665
	{
		// Fields
		public SlotType type; // 0x10

		// Constructors
		public __c__DisplayClass31_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _GetSlotByType_b__0(SlotResource r); // 0x00000001808B1FA0-0x00000001808B1FB0
	}

	[CompilerGenerated]
	private sealed class _WaitAndSpinNext_d__28 : IEnumerator<object> // TypeDefIndex: 1666
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public SlotMachine __4__this; // 0x20
		public int nextIndex; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndSpinNext_d__28(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808B1FB0-0x00000001808B20A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808B20A0-0x00000001808B20E0
	}

	// Constructors
	public SlotMachine(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Start(); // 0x00000001808B1030-0x00000001808B13E0
	private void OnDestroy(); // 0x00000001808B13E0-0x00000001808B1460
	private void OnColumnSpinComplete(int index); // 0x00000001808B1460-0x00000001808B1650
	public void StartSpin(); // 0x00000001808B1650-0x00000001808B1700
	public void StopSpinWithResult(List<SlotType> topRow); // 0x00000001808B1700-0x00000001808B18C0
	public void StopSpin(); // 0x00000001808B18C0-0x00000001808B1A80
	private void SpinColumn(int index); // 0x00000001808B1A80-0x00000001808B1BA0
	[IteratorStateMachine(typeof(_WaitAndSpinNext_d__28))]
	private IEnumerator WaitAndSpinNext(int nextIndex); // 0x00000001808B1BA0-0x00000001808B1C50
	public void UVAnimationVisibility(int index, bool status); // 0x000000018028A320-0x000000018028A330
	public Sprite GetBlurrySprite(BlurLevel level, int index); // 0x00000001808B1C50-0x00000001808B1E00
	public SlotResource GetSlotByType(SlotType type); // 0x00000001808B1E00-0x00000001808B1FA0
}

