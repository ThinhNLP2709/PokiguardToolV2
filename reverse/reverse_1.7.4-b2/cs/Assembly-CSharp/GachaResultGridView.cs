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
public class GachaResultGridView : MonoBehaviour // TypeDefIndex: 656
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
	private struct Cell // TypeDefIndex: 657
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
	private sealed class __c__DisplayClass20_0 // TypeDefIndex: 658
	{
		// Fields
		public GameObject card; // 0x10

		// Constructors
		public __c__DisplayClass20_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FlipCell_b__0(); // 0x000000018040FC80-0x000000018040FD00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass20_1 // TypeDefIndex: 659
	{
		// Fields
		public Image frame; // 0x10
		public Color baseColor; // 0x18

		// Constructors
		public __c__DisplayClass20_1(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FlipCell_b__1(float t); // 0x000000018040FD00-0x000000018040FE30
		internal void _FlipCell_b__2(); // 0x000000018040FE30-0x000000018040FEC0
	}

	[CompilerGenerated]
	private sealed class _RevealCo_d__19 : IEnumerator<object> // TypeDefIndex: 660
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaResultGridView __4__this; // 0x20
		public GachaRollItemDTO[] items; // 0x28
		private int _i_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RevealCo_d__19(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018040F280-0x000000018040F670
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018040F670-0x000000018040F6B0
	}

	// Constructors
	public GachaResultGridView(); // 0x00000001804034A0-0x0000000180403560

	// Methods
	private void Awake(); // 0x0000000180400850-0x0000000180400860
	private void EnsureWired(); // 0x0000000180401C40-0x0000000180402040
	public void Show(GachaRollItemDTO[] items, int bulkRollCount, string costText = "" /* Metadata: 0x0068B6F3 */, string titleWord = "TRI\u1EC6U H\u1ED2I" /* Metadata: 0x0068B6F4 */); // 0x0000000180402A40-0x0000000180402E00
	private void BuildCells(GachaRollItemDTO[] items); // 0x0000000180400860-0x0000000180401350
	[IteratorStateMachine(typeof(_RevealCo_d__19))]
	private IEnumerator RevealCo(GachaRollItemDTO[] items); // 0x00000001804029B0-0x0000000180402A40
	private void FlipCell(int index, GachaRollItemDTO item); // 0x0000000180402370-0x0000000180402960
	private void ApplyLegendaryDecor(Cell c, GachaRollItemDTO item); // 0x0000000180400590-0x0000000180400850
	private void SkipReveal(); // 0x0000000180402E00-0x0000000180403340
	private void FinishReveal(GachaRollItemDTO[] items); // 0x0000000180402150-0x0000000180402370
	private static string BuildSummary(GachaRollItemDTO[] items); // 0x0000000180401350-0x00000001804017E0
	public void Close(); // 0x0000000180401BB0-0x0000000180401C40
	private void CancelFx(); // 0x00000001804017E0-0x0000000180401BB0
	private void Update(); // 0x0000000180403410-0x00000001804034A0
	private void OnDisable(); // 0x0000000180402960-0x00000001804029B0
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x0000000180402040-0x0000000180402150
	[CompilerGenerated]
	private void _EnsureWired_b__16_0(); // 0x0000000180403340-0x0000000180403370
	[CompilerGenerated]
	private void _EnsureWired_b__16_1(); // 0x0000000180403370-0x0000000180403410
}

