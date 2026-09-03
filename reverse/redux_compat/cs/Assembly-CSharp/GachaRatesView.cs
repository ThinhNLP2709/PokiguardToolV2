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

[DisallowMultipleComponent]
public class GachaRatesView : MonoBehaviour // TypeDefIndex: 576
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
	private sealed class __c__DisplayClass14_0 // TypeDefIndex: 577
	{
		// Fields
		public GachaRatesView __4__this; // 0x10
		public long bannerId; // 0x18

		// Constructors
		public __c__DisplayClass14_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadCo_b__0(GachaRatesData data); // 0x00000001803A6230-0x00000001803A6320
		internal void _LoadCo_b__1(string err); // 0x00000001803A6320-0x00000001803A6440
	}

	[CompilerGenerated]
	private sealed class _LoadCo_d__14 : IEnumerator<object> // TypeDefIndex: 578
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaRatesView __4__this; // 0x20
		public long bannerId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadCo_d__14(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803A5820-0x00000001803A5A60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803A5A60-0x00000001803A5AA0
	}

	// Constructors
	public GachaRatesView(); // 0x0000000180396E90-0x0000000180396F10

	// Methods
	private void OnDisable(); // 0x000000018038ECB0-0x000000018038ECC0
	private void Awake(); // 0x0000000180395E10-0x0000000180395E20
	private void EnsureWired(); // 0x0000000180395E20-0x0000000180396140
	public void Show(long bannerId); // 0x0000000180396D50-0x0000000180396E90
	public void Hide(); // 0x00000001803546C0-0x00000001803546F0
	[IteratorStateMachine(typeof(_LoadCo_d__14))]
	private IEnumerator LoadCo(long bannerId); // 0x0000000180396250-0x00000001803962D0
	private void Render(GachaRatesData data); // 0x00000001803962D0-0x0000000180396D50
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x0000000180396140-0x0000000180396250
}

