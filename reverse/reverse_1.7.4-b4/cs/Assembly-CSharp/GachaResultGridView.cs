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
public class GachaResultGridView : MonoBehaviour // TypeDefIndex: 748
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
	private struct Cell // TypeDefIndex: 749
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
	private sealed class __c__DisplayClass20_0 // TypeDefIndex: 750
	{
		// Fields
		public GameObject card; // 0x10

		// Constructors
		public __c__DisplayClass20_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FlipCell_b__0(); // 0x00000001804D4190-0x00000001804D42D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass20_1 // TypeDefIndex: 751
	{
		// Fields
		public Image frame; // 0x10
		public Color baseColor; // 0x18

		// Constructors
		public __c__DisplayClass20_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FlipCell_b__1(float t); // 0x00000001804D42D0-0x00000001804D4480
		internal void _FlipCell_b__2(); // 0x00000001804D4480-0x00000001804D4590
	}

	[CompilerGenerated]
	private sealed class _RevealCo_d__19 : IEnumerator<object> // TypeDefIndex: 752
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GachaResultGridView __4__this; // 0x20
		public GachaRollItemDTO[] items; // 0x28
		private int _i_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RevealCo_d__19(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001804D4590-0x00000001804D4A80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804D4A80-0x00000001804D4AC0
	}

	// Constructors
	public GachaResultGridView(); // 0x00000001804D3E10-0x00000001804D4040

	// Methods
	private void Awake(); // 0x00000001804CE700-0x00000001804CE710
	private void EnsureWired(); // 0x00000001804CE710-0x00000001804CF140
	public void Show(GachaRollItemDTO[] items, int bulkRollCount, string costText = "" /* Metadata: 0x005EFA25 */, string titleWord = "TRI\u1EC6U H\u1ED2I" /* Metadata: 0x005EFA26 */); // 0x00000001804CF140-0x00000001804CF950
	private void BuildCells(GachaRollItemDTO[] items); // 0x00000001804CF950-0x00000001804D0DB0
	[IteratorStateMachine(typeof(_RevealCo_d__19))]
	private IEnumerator RevealCo(GachaRollItemDTO[] items); // 0x00000001804D0DB0-0x00000001804D0EC0
	private void FlipCell(int index, GachaRollItemDTO item); // 0x00000001804D0EC0-0x00000001804D17E0
	private void ApplyLegendaryDecor(Cell c, GachaRollItemDTO item); // 0x00000001804D17E0-0x00000001804D1CD0
	private void SkipReveal(); // 0x00000001804D1CD0-0x00000001804D2570
	private void FinishReveal(GachaRollItemDTO[] items); // 0x00000001804D2570-0x00000001804D29D0
	private static string BuildSummary(GachaRollItemDTO[] items); // 0x00000001804D29D0-0x00000001804D3140
	public void Close(); // 0x00000001804D3140-0x00000001804D3250
	private void CancelFx(); // 0x00000001804D3250-0x00000001804D3A00
	private void Update(); // 0x00000001804D3A00-0x00000001804D3B30
	private void OnDisable(); // 0x00000001804D3B30-0x00000001804D3BB0
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001804D3BB0-0x00000001804D3E10
	[CompilerGenerated]
	private void _EnsureWired_b__16_0(); // 0x00000001804D4040-0x00000001804D4070
	[CompilerGenerated]
	private void _EnsureWired_b__16_1(); // 0x00000001804D4070-0x00000001804D4190
}

