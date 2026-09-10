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
public class GachaHistoryView : MonoBehaviour // TypeDefIndex: 631
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
	private sealed class _LoadCo_d__13 : IEnumerator<object> // TypeDefIndex: 632
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaHistoryView __4__this; // 0x20
		public int userId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadCo_d__13(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018040EDA0-0x000000018040EFC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018040EFC0-0x000000018040F000
	}

	// Constructors
	public GachaHistoryView(); // 0x00000001803F9010-0x00000001803F9090

	// Methods
	private void OnDisable(); // 0x00000001803F82F0-0x00000001803F8300
	private void Awake(); // 0x00000001803F7E00-0x00000001803F7E10
	private void EnsureWired(); // 0x00000001803F7E10-0x00000001803F8130
	public void Show(int userId); // 0x00000001803F8DE0-0x00000001803F8F00
	public void Hide(); // 0x00000001803F8240-0x00000001803F8270
	[IteratorStateMachine(typeof(_LoadCo_d__13))]
	private IEnumerator LoadCo(int userId); // 0x00000001803F8270-0x00000001803F82F0
	private void Render(GachaHistoryData data); // 0x00000001803F8300-0x00000001803F8BE0
	private static string ShortTime(string iso); // 0x00000001803F8BE0-0x00000001803F8DE0
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001803F8130-0x00000001803F8240
	[CompilerGenerated]
	private void _LoadCo_b__13_0(GachaHistoryData data); // 0x00000001803F8F00-0x00000001803F8F10
	[CompilerGenerated]
	private void _LoadCo_b__13_1(string err); // 0x00000001803F8F10-0x00000001803F9010
}

