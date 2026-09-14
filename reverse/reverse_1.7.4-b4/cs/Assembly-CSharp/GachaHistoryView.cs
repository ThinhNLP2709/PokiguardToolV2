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

[DisallowMultipleComponent]
public class GachaHistoryView : MonoBehaviour // TypeDefIndex: 723
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
	private sealed class _LoadCo_d__13 : IEnumerator<object> // TypeDefIndex: 724
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaHistoryView __4__this; // 0x20
		public int userId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadCo_d__13(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001804C1030-0x00000001804C14A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C14A0-0x00000001804C14E0
	}

	// Constructors
	public GachaHistoryView(); // 0x00000001804C0D90-0x00000001804C0E90

	// Methods
	private void OnDisable(); // 0x00000001804BECE0-0x00000001804BECF0
	private void Awake(); // 0x00000001804BECF0-0x00000001804BED00
	private void EnsureWired(); // 0x00000001804BED00-0x00000001804BF530
	public void Show(int userId); // 0x00000001804BF530-0x00000001804BF740
	public void Hide(); // 0x00000001804BF740-0x00000001804BF7C0
	[IteratorStateMachine(typeof(_LoadCo_d__13))]
	private IEnumerator LoadCo(int userId); // 0x00000001804BF7C0-0x00000001804BF870
	private void Render(GachaHistoryData data); // 0x00000001804BF870-0x00000001804C0900
	private static string ShortTime(string iso); // 0x00000001804C0900-0x00000001804C0B30
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001804C0B30-0x00000001804C0D90
	[CompilerGenerated]
	private void _LoadCo_b__13_0(GachaHistoryData data); // 0x00000001804C0E90-0x00000001804C0EA0
	[CompilerGenerated]
	private void _LoadCo_b__13_1(string err); // 0x00000001804C0EA0-0x00000001804C1030
}

