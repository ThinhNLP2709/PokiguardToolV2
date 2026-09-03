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

public class SkillPetEspect : MonoBehaviour // TypeDefIndex: 1709
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
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 1710
	{
		// Fields
		public string targetSpriteName; // 0x10

		// Constructors
		public __c__DisplayClass16_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _UpdateNutSprite_b__0(Sprite sprite); // 0x00000001805E8C20-0x00000001805E8C60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass16_1 // TypeDefIndex: 1711
	{
		// Fields
		public string newTargetSpriteName; // 0x10

		// Constructors
		public __c__DisplayClass16_1(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _UpdateNutSprite_b__1(Sprite sprite); // 0x00000001805E8C20-0x00000001805E8C60
	}

	[CompilerGenerated]
	private sealed class _ScrollSlider_d__18 : IEnumerator<object> // TypeDefIndex: 1712
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public SkillPetEspect __4__this; // 0x20
		public float duration; // 0x28
		private float _elapsed_5__2; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ScrollSlider_d__18(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805E7F50-0x00000001805E80E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E80E0-0x00000001805E8120
	}

	// Constructors
	public SkillPetEspect(); // 0x00000001805E4080-0x00000001805E4160

	// Methods
	private void Start(); // 0x00000001805E3A60-0x00000001805E3B90
	private void Update(); // 0x00000001805E3F00-0x00000001805E4080
	private void HandleKeyPress(string key); // 0x00000001805E3970-0x00000001805E39E0
	private void UpdateNutSprite(int index); // 0x00000001805E3B90-0x00000001805E3F00
	private void CreateNuts(); // 0x00000001805E3270-0x00000001805E3970
	[IteratorStateMachine(typeof(_ScrollSlider_d__18))]
	private IEnumerator ScrollSlider(float duration); // 0x00000001805E39E0-0x00000001805E3A60
}

