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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class SlotMachine : MonoBehaviour // TypeDefIndex: 1061
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
	private sealed class __c__DisplayClass30_0 // TypeDefIndex: 1062
	{
		// Fields
		public BlurLevel level; // 0x10

		// Constructors
		public __c__DisplayClass30_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _GetBlurrySprite_b__0(BlurryResource r); // 0x00000001804AA970-0x00000001804AA980
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass31_0 // TypeDefIndex: 1063
	{
		// Fields
		public SlotType type; // 0x10

		// Constructors
		public __c__DisplayClass31_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _GetSlotByType_b__0(SlotResource r); // 0x00000001804AA970-0x00000001804AA980
	}

	[CompilerGenerated]
	private sealed class _WaitAndSpinNext_d__28 : IEnumerator<object> // TypeDefIndex: 1064
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public SlotMachine __4__this; // 0x20
		public int nextIndex; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndSpinNext_d__28(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804AB1D0-0x00000001804AB290
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804AB290-0x00000001804AB2D0
	}

	// Constructors
	public SlotMachine(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Start(); // 0x00000001804A7EC0-0x00000001804A80E0
	private void OnDestroy(); // 0x00000001804A7C30-0x00000001804A7CA0
	private void OnColumnSpinComplete(int index); // 0x00000001804A7B60-0x00000001804A7C30
	public void StartSpin(); // 0x00000001804A7E60-0x00000001804A7EC0
	public void StopSpinWithResult(List<SlotType> topRow); // 0x00000001804A80E0-0x00000001804A8200
	public void StopSpin(); // 0x00000001804A8200-0x00000001804A8320
	private void SpinColumn(int index); // 0x00000001804A7CA0-0x00000001804A7E60
	[IteratorStateMachine(typeof(_WaitAndSpinNext_d__28))]
	private IEnumerator WaitAndSpinNext(int nextIndex); // 0x00000001804A8320-0x00000001804A83A0
	public void UVAnimationVisibility(int index, bool status); // 0x00000001802E76C0-0x00000001802E76D0
	public Sprite GetBlurrySprite(BlurLevel level, int index); // 0x00000001804A7980-0x00000001804A7A70
	public SlotResource GetSlotByType(SlotType type); // 0x00000001804A7A70-0x00000001804A7B60
}

