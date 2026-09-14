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
public class GachaResultGridView : MonoBehaviour // TypeDefIndex: 747
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
	private struct Cell // TypeDefIndex: 748
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
	private sealed class __c__DisplayClass20_0 // TypeDefIndex: 749
	{
		// Fields
		public GameObject card; // 0x10

		// Constructors
		public __c__DisplayClass20_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FlipCell_b__0(); // 0x00000001804D2B20-0x00000001804D2C60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass20_1 // TypeDefIndex: 750
	{
		// Fields
		public Image frame; // 0x10
		public Color baseColor; // 0x18

		// Constructors
		public __c__DisplayClass20_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FlipCell_b__1(float t); // 0x00000001804D2C60-0x00000001804D2E10
		internal void _FlipCell_b__2(); // 0x00000001804D2E10-0x00000001804D2F20
	}

	[CompilerGenerated]
	private sealed class _RevealCo_d__19 : IEnumerator<object> // TypeDefIndex: 751
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001804D2F20-0x00000001804D3410
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804D3410-0x00000001804D3450
	}

	// Constructors
	public GachaResultGridView(); // 0x00000001804D27A0-0x00000001804D29D0

	// Methods
	private void Awake(); // 0x00000001804CD090-0x00000001804CD0A0
	private void EnsureWired(); // 0x00000001804CD0A0-0x00000001804CDAD0
	public void Show(GachaRollItemDTO[] items, int bulkRollCount, string costText = "" /* Metadata: 0x005EE654 */, string titleWord = "TRI\u1EC6U H\u1ED2I" /* Metadata: 0x005EE655 */); // 0x00000001804CDAD0-0x00000001804CE2E0
	private void BuildCells(GachaRollItemDTO[] items); // 0x00000001804CE2E0-0x00000001804CF740
	[IteratorStateMachine(typeof(_RevealCo_d__19))]
	private IEnumerator RevealCo(GachaRollItemDTO[] items); // 0x00000001804CF740-0x00000001804CF850
	private void FlipCell(int index, GachaRollItemDTO item); // 0x00000001804CF850-0x00000001804D0170
	private void ApplyLegendaryDecor(Cell c, GachaRollItemDTO item); // 0x00000001804D0170-0x00000001804D0660
	private void SkipReveal(); // 0x00000001804D0660-0x00000001804D0F00
	private void FinishReveal(GachaRollItemDTO[] items); // 0x00000001804D0F00-0x00000001804D1360
	private static string BuildSummary(GachaRollItemDTO[] items); // 0x00000001804D1360-0x00000001804D1AD0
	public void Close(); // 0x00000001804D1AD0-0x00000001804D1BE0
	private void CancelFx(); // 0x00000001804D1BE0-0x00000001804D2390
	private void Update(); // 0x00000001804D2390-0x00000001804D24C0
	private void OnDisable(); // 0x00000001804D24C0-0x00000001804D2540
	private static T FindDeep<T>(Transform root, string nodeName)
		where T : Component;
	private static Transform FindDeepTransform(Transform root, string nodeName); // 0x00000001804D2540-0x00000001804D27A0
	[CompilerGenerated]
	private void _EnsureWired_b__16_0(); // 0x00000001804D29D0-0x00000001804D2A00
	[CompilerGenerated]
	private void _EnsureWired_b__16_1(); // 0x00000001804D2A00-0x00000001804D2B20
}

