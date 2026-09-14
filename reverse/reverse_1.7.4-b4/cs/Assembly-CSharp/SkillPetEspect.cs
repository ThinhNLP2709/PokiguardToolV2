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

public class SkillPetEspect : MonoBehaviour // TypeDefIndex: 2392
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
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 2393
	{
		// Fields
		public string targetSpriteName; // 0x10

		// Constructors
		public __c__DisplayClass16_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _UpdateNutSprite_b__0(Sprite sprite); // 0x0000000180B66950-0x0000000180B669C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass16_1 // TypeDefIndex: 2394
	{
		// Fields
		public string newTargetSpriteName; // 0x10

		// Constructors
		public __c__DisplayClass16_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _UpdateNutSprite_b__1(Sprite sprite); // 0x0000000180B66950-0x0000000180B669C0
	}

	[CompilerGenerated]
	private sealed class _ScrollSlider_d__18 : IEnumerator<object> // TypeDefIndex: 2395
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B669C0-0x0000000180B66C70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B66C70-0x0000000180B66CB0
	}

	// Constructors
	public SkillPetEspect(); // 0x0000000180B66790-0x0000000180B66950

	// Methods
	private void Start(); // 0x0000000180B64E50-0x0000000180B65020
	private void Update(); // 0x0000000180B65020-0x0000000180B651F0
	private void HandleKeyPress(string key); // 0x0000000180B651F0-0x0000000180B65280
	private void UpdateNutSprite(int index); // 0x0000000180B65280-0x0000000180B65A90
	private void CreateNuts(); // 0x0000000180B65A90-0x0000000180B666D0
	[IteratorStateMachine(typeof(_ScrollSlider_d__18))]
	private IEnumerator ScrollSlider(float duration); // 0x0000000180B666D0-0x0000000180B66790
}

