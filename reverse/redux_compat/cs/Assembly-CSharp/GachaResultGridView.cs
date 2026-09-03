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
public class GachaResultGridView : MonoBehaviour // TypeDefIndex: 579
{
	// Fields
	[SerializeField]
	private UnityEngine.UI.Text txtTitle; // 0x20
	[SerializeField]
	private RectTransform grid; // 0x28
	[SerializeField]
	private GameObject cellTemplate; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtSummary; // 0x38
	[SerializeField]
	private Button btnAgain; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtAgainCost; // 0x48
	[SerializeField]
	private Button btnOk; // 0x50
	private readonly List<GameObject> _spawned; // 0x58
	private readonly List<Cell> _cells; // 0x60
	private Coroutine _revealCo; // 0x68
	private bool _revealDone; // 0x70
	private bool _wired; // 0x71
	public Action OnRollAgain; // 0x78
	public Action OnClosed; // 0x80
	private GachaRollItemDTO[] _lastItems; // 0x88

	// Nested types
	private struct Cell // TypeDefIndex: 580
	{
		// Fields
		public GameObject root; // 0x00
		public Image frame; // 0x08
		public Image icon; // 0x10
		public Image card; // 0x18
		public UnityEngine.UI.Text amount; // 0x20
		public UnityEngine.UI.Text name; // 0x28
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass20_0 // TypeDefIndex: 581
	{
		// Fields
		public GameObject card; // 0x10

		// Constructors
		public __c__DisplayClass20_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _FlipCell_b__0(); // 0x00000001803A64A0-0x00000001803A6520
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass20_1 // TypeDefIndex: 582
	{
		// Fields
		public Image frame; // 0x10
		public Color baseColor; // 0x18

		// Constructors
		public __c__DisplayClass20_1(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _FlipCell_b__1(float t); // 0x00000001803A6520-0x00000001803A6650
		internal void _FlipCell_b__2(); // 0x00000001803A6650-0x00000001803A66E0
	}

	[CompilerGenerated]
	private sealed class _RevealCo_d__19 : IEnumerator<object> // TypeDefIndex: 583
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaResultGridView __4__this; // 0x20
		public GachaRollItemDTO[] items; // 0x28
		private int _i_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RevealCo_d__19(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803A5AA0-0x00000001803A5E90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803A5E90-0x00000001803A5ED0
	}

	// Constructors
	public GachaResultGridView(); // 0x0000000180399E20-0x0000000180399EE0

	// Methods
	private void Awake(); // 0x00000001803971D0-0x00000001803971E0
	private void EnsureWired(); // 0x00000001803985C0-0x00000001803989C0
	public void Show(GachaRollItemDTO[] items, int bulkRollCount, string costText = "" /* Metadata: 0x0064C540 */, string titleWord = "TRI\u1EC6U H\u1ED2I" /* Metadata: 0x0064C541 */); // 0x00000001803993C0-0x0000000180399780
	private void BuildCells(GachaRollItemDTO[] items); // 0x00000001803971E0-0x0000000180397CD0
	[IteratorStateMachine(typeof(_RevealCo_d__19))]
	private IEnumerator RevealCo(GachaRollItemDTO[] items); // 0x0000000180399330-0x00000001803993C0
	private void FlipCell(int index, GachaRollItemDTO item); // 0x0000000180398CF0-0x00000001803992E0
	private void ApplyLegendaryDecor(Cell c, GachaRollItemDTO item); // 0x0000000180396F10-0x00000001803971D0
	private void SkipReveal(); // 0x0000000180399780-0x0000000180399CC0
	private void FinishReveal(GachaRollItemDTO[] items); // 0x0000000180398AD0-0x0000000180398CF0
	private static string BuildSummary(GachaRollItemDTO[] items); // 0x0000000180397CD0-0x0000000180398160
	public void Close(); // 0x0000000180398530-0x00000001803985C0
	private void CancelFx(); // 0x0000000180398160-0x0000000180398530
	private void Update(); // 0x0000000180399D90-0x0000000180399E20
	private void OnDisable(); // 0x00000001803992E0-0x0000000180399330
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001803989C0-0x0000000180398AD0
	[CompilerGenerated]
	private void _EnsureWired_b__16_0(); // 0x0000000180399CC0-0x0000000180399CF0
	[CompilerGenerated]
	private void _EnsureWired_b__16_1(); // 0x0000000180399CF0-0x0000000180399D90
}

