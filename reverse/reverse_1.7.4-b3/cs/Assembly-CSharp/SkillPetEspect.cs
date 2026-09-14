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

public class SkillPetEspect : MonoBehaviour // TypeDefIndex: 2385
{
	// Fields
	public GameObject openBoard; // 0x20
	public GameObject closeCardEspect; // 0x28
	public GameObject nutPrefab; // 0x30
	public Transform parentTransform; // 0x38
	public Slider timeCombo; // 0x40
	public int nutCount; // 0x48
	public float spacing; // 0x4C
	public float scaleFactor; // 0x50
	private int dem; // 0x54
	private List<GameObject> nutObjects; // 0x58
	private List<string> nutNames; // 0x60
	private string[] keyBindings; // 0x68
	private Sprite[] nutSpriteComplete; // 0x70

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 2386
	{
		// Fields
		public string targetSpriteName; // 0x10

		// Constructors
		public __c__DisplayClass16_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _UpdateNutSprite_b__0(Sprite sprite); // 0x0000000180B59610-0x0000000180B59680
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass16_1 // TypeDefIndex: 2387
	{
		// Fields
		public string newTargetSpriteName; // 0x10

		// Constructors
		public __c__DisplayClass16_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _UpdateNutSprite_b__1(Sprite sprite); // 0x0000000180B59610-0x0000000180B59680
	}

	[CompilerGenerated]
	private sealed class _ScrollSlider_d__18 : IEnumerator<object> // TypeDefIndex: 2388
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public SkillPetEspect __4__this; // 0x20
		public float duration; // 0x28
		private float _elapsed_5__2; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ScrollSlider_d__18(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B59680-0x0000000180B59930
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B59930-0x0000000180B59970
	}

	// Constructors
	public SkillPetEspect(); // 0x0000000180B59450-0x0000000180B59610

	// Methods
	private void Start(); // 0x0000000180B57B10-0x0000000180B57CE0
	private void Update(); // 0x0000000180B57CE0-0x0000000180B57EB0
	private void HandleKeyPress(string key); // 0x0000000180B57EB0-0x0000000180B57F40
	private void UpdateNutSprite(int index); // 0x0000000180B57F40-0x0000000180B58750
	private void CreateNuts(); // 0x0000000180B58750-0x0000000180B59390
	[IteratorStateMachine(typeof(_ScrollSlider_d__18))]
	private IEnumerator ScrollSlider(float duration); // 0x0000000180B59390-0x0000000180B59450
}

