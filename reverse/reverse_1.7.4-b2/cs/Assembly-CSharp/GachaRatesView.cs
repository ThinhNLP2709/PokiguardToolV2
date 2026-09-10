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

[DisallowMultipleComponent]
public class GachaRatesView : MonoBehaviour // TypeDefIndex: 653
{
	// Fields
	[SerializeField]
	private UnityEngine.UI.Text txtTitle; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtPityNote; // 0x28
	[SerializeField]
	private RectTransform content; // 0x30
	[SerializeField]
	private GameObject rowTemplate; // 0x38
	[SerializeField]
	private Button btnClose; // 0x40
	private readonly List<GameObject> _spawned; // 0x48
	private bool _wired; // 0x50
	private bool _loading; // 0x51
	private long _loadedBannerId; // 0x58

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass14_0 // TypeDefIndex: 654
	{
		// Fields
		public GachaRatesView __4__this; // 0x10
		public long bannerId; // 0x18

		// Constructors
		public __c__DisplayClass14_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadCo_b__0(GachaRatesData data); // 0x000000018040FA10-0x000000018040FB00
		internal void _LoadCo_b__1(string err); // 0x000000018040FB00-0x000000018040FC20
	}

	[CompilerGenerated]
	private sealed class _LoadCo_d__14 : IEnumerator<object> // TypeDefIndex: 655
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaRatesView __4__this; // 0x20
		public long bannerId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadCo_d__14(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018040F000-0x000000018040F240
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018040F240-0x000000018040F280
	}

	// Constructors
	public GachaRatesView(); // 0x0000000180400510-0x0000000180400590

	// Methods
	private void OnDisable(); // 0x00000001803F82F0-0x00000001803F8300
	private void Awake(); // 0x00000001803FF480-0x00000001803FF490
	private void EnsureWired(); // 0x00000001803FF490-0x00000001803FF7B0
	public void Show(long bannerId); // 0x00000001804003D0-0x0000000180400510
	public void Hide(); // 0x00000001803F8240-0x00000001803F8270
	[IteratorStateMachine(typeof(_LoadCo_d__14))]
	private IEnumerator LoadCo(long bannerId); // 0x00000001803FF8C0-0x00000001803FF940
	private void Render(GachaRatesData data); // 0x00000001803FF940-0x00000001804003D0
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001803FF7B0-0x00000001803FF8C0
}

