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

[DisallowMultipleComponent]
public class GachaHistoryView : MonoBehaviour // TypeDefIndex: 722
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
	private sealed class _LoadCo_d__13 : IEnumerator<object> // TypeDefIndex: 723
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001804BFA70-0x00000001804BFEB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804BFEB0-0x00000001804BFEF0
	}

	// Constructors
	public GachaHistoryView(); // 0x00000001804BF7D0-0x00000001804BF8D0

	// Methods
	private void OnDisable(); // 0x00000001804BD720-0x00000001804BD730
	private void Awake(); // 0x00000001804BD730-0x00000001804BD740
	private void EnsureWired(); // 0x00000001804BD740-0x00000001804BDF70
	public void Show(int userId); // 0x00000001804BDF70-0x00000001804BE180
	public void Hide(); // 0x00000001804BE180-0x00000001804BE200
	[IteratorStateMachine(typeof(_LoadCo_d__13))]
	private IEnumerator LoadCo(int userId); // 0x00000001804BE200-0x00000001804BE2B0
	private void Render(GachaHistoryData data); // 0x00000001804BE2B0-0x00000001804BF340
	private static string ShortTime(string iso); // 0x00000001804BF340-0x00000001804BF570
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001804BF570-0x00000001804BF7D0
	[CompilerGenerated]
	private void _LoadCo_b__13_0(GachaHistoryData data); // 0x00000001804BF8D0-0x00000001804BF8E0
	[CompilerGenerated]
	private void _LoadCo_b__13_1(string err); // 0x00000001804BF8E0-0x00000001804BFA70
}

