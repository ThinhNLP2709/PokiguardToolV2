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
public class GachaHistoryView : MonoBehaviour // TypeDefIndex: 554
{
	// Fields
	[SerializeField]
	private UnityEngine.UI.Text txtTitle; // 0x20
	[SerializeField]
	private RectTransform content; // 0x28
	[SerializeField]
	private GameObject rowTemplate; // 0x30
	[SerializeField]
	private Button btnClose; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtEmpty; // 0x40
	private readonly List<GameObject> _spawned; // 0x48
	private bool _wired; // 0x50
	private bool _loading; // 0x51

	// Nested types
	[CompilerGenerated]
	private sealed class _LoadCo_d__13 : IEnumerator<object> // TypeDefIndex: 555
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaHistoryView __4__this; // 0x20
		public int userId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadCo_d__13(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803A55C0-0x00000001803A57E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803A57E0-0x00000001803A5820
	}

	// Constructors
	public GachaHistoryView(); // 0x000000018038F9D0-0x000000018038FA50

	// Methods
	private void OnDisable(); // 0x000000018038ECB0-0x000000018038ECC0
	private void Awake(); // 0x000000018038E7F0-0x000000018038E800
	private void EnsureWired(); // 0x000000018038E800-0x000000018038EB20
	public void Show(int userId); // 0x000000018038F7A0-0x000000018038F8C0
	public void Hide(); // 0x00000001803546C0-0x00000001803546F0
	[IteratorStateMachine(typeof(_LoadCo_d__13))]
	private IEnumerator LoadCo(int userId); // 0x000000018038EC30-0x000000018038ECB0
	private void Render(GachaHistoryData data); // 0x000000018038ECC0-0x000000018038F5A0
	private static string ShortTime(string iso); // 0x000000018038F5A0-0x000000018038F7A0
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x000000018038EB20-0x000000018038EC30
	[CompilerGenerated]
	private void _LoadCo_b__13_0(GachaHistoryData data); // 0x000000018038F8C0-0x000000018038F8D0
	[CompilerGenerated]
	private void _LoadCo_b__13_1(string err); // 0x000000018038F8D0-0x000000018038F9D0
}

