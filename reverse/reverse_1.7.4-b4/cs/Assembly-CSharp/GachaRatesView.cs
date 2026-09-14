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
public class GachaRatesView : MonoBehaviour // TypeDefIndex: 745
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
	private sealed class __c__DisplayClass14_0 // TypeDefIndex: 746
	{
		// Fields
		public GachaRatesView __4__this; // 0x10
		public long bannerId; // 0x18

		// Constructors
		public __c__DisplayClass14_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadCo_b__0(GachaRatesData data); // 0x00000001804CDFF0-0x00000001804CE170
		internal void _LoadCo_b__1(string err); // 0x00000001804CE170-0x00000001804CE320
	}

	[CompilerGenerated]
	private sealed class _LoadCo_d__14 : IEnumerator<object> // TypeDefIndex: 747
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaRatesView __4__this; // 0x20
		public long bannerId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadCo_d__14(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001804CE320-0x00000001804CE6C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804CE6C0-0x00000001804CE700
	}

	// Constructors
	public GachaRatesView(); // 0x00000001804CDEF0-0x00000001804CDFF0

	// Methods
	private void OnDisable(); // 0x00000001804BECE0-0x00000001804BECF0
	private void Awake(); // 0x00000001804CBF30-0x00000001804CBF40
	private void EnsureWired(); // 0x00000001804CBF40-0x00000001804CC770
	public void Show(long bannerId); // 0x00000001804CC770-0x00000001804CC9A0
	public void Hide(); // 0x00000001804BF740-0x00000001804BF7C0
	[IteratorStateMachine(typeof(_LoadCo_d__14))]
	private IEnumerator LoadCo(long bannerId); // 0x00000001804CC9A0-0x00000001804CCA60
	private void Render(GachaRatesData data); // 0x00000001804CCA60-0x00000001804CDC90
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001804CDC90-0x00000001804CDEF0
}

