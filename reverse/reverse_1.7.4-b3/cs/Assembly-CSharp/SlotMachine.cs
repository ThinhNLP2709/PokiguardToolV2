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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class SlotMachine : MonoBehaviour // TypeDefIndex: 1661
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
	private sealed class __c__DisplayClass30_0 // TypeDefIndex: 1662
	{
		// Fields
		public BlurLevel level; // 0x10

		// Constructors
		public __c__DisplayClass30_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _GetBlurrySprite_b__0(BlurryResource r); // 0x00000001808AF650-0x00000001808AF660
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass31_0 // TypeDefIndex: 1663
	{
		// Fields
		public SlotType type; // 0x10

		// Constructors
		public __c__DisplayClass31_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _GetSlotByType_b__0(SlotResource r); // 0x00000001808AF650-0x00000001808AF660
	}

	[CompilerGenerated]
	private sealed class _WaitAndSpinNext_d__28 : IEnumerator<object> // TypeDefIndex: 1664
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001808AF660-0x00000001808AF750
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808AF750-0x00000001808AF790
	}

	// Constructors
	public SlotMachine(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Start(); // 0x00000001808AE6E0-0x00000001808AEA90
	private void OnDestroy(); // 0x00000001808AEA90-0x00000001808AEB10
	private void OnColumnSpinComplete(int index); // 0x00000001808AEB10-0x00000001808AED00
	public void StartSpin(); // 0x00000001808AED00-0x00000001808AEDB0
	public void StopSpinWithResult(List<SlotType> topRow); // 0x00000001808AEDB0-0x00000001808AEF70
	public void StopSpin(); // 0x00000001808AEF70-0x00000001808AF130
	private void SpinColumn(int index); // 0x00000001808AF130-0x00000001808AF250
	[IteratorStateMachine(typeof(_WaitAndSpinNext_d__28))]
	private IEnumerator WaitAndSpinNext(int nextIndex); // 0x00000001808AF250-0x00000001808AF300
	public void UVAnimationVisibility(int index, bool status); // 0x000000018028A320-0x000000018028A330
	public Sprite GetBlurrySprite(BlurLevel level, int index); // 0x00000001808AF300-0x00000001808AF4B0
	public SlotResource GetSlotByType(SlotType type); // 0x00000001808AF4B0-0x00000001808AF650
}

