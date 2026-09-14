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
public sealed class ThanhTuuMarquee : MonoBehaviour // TypeDefIndex: 1270
{
	// Fields
	public const float PAD_LEFT = 12f; // Metadata: 0x005EF686
	public const float FONT = 22f; // Metadata: 0x005EF68A
	public static readonly Color TEXT_COLOR; // 0x00
	private RectTransform _root; // 0x20
	private RectTransform _txtRt; // 0x28
	private UnityEngine.UI.Text _txt; // 0x30
	private string[] _feed; // 0x38
	private int _index; // 0x40
	private bool _running; // 0x44
	private Coroutine _loop; // 0x48

	// Properties
	public bool HasFeed { get; } // 0x0000000180716E50-0x0000000180716E70 
	public UnityEngine.UI.Text Label { get; } // 0x00000001802B4AE0-0x00000001802B4AF0 

	// Nested types
	[CompilerGenerated]
	private sealed class _Run_d__19 : IEnumerator<object> // TypeDefIndex: 1271
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ThanhTuuMarquee __4__this; // 0x20
		private bool _first_5__2; // 0x28
		private float _w_5__3; // 0x2C
		private float _x_5__4; // 0x30
		private float _speed_5__5; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Run_d__19(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180718550-0x0000000180718A10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180718A10-0x0000000180718A50
	}

	// Constructors
	public ThanhTuuMarquee(); // 0x00000001807183C0-0x0000000180718490
	static ThanhTuuMarquee(); // 0x0000000180718490-0x0000000180718550

	// Methods
	public static ThanhTuuMarquee Build(RectTransform node); // 0x0000000180716E70-0x00000001807176F0
	public void SetFeed(string[] feed); // 0x00000001807176F0-0x00000001807178B0
	public void SetRunning(bool on); // 0x00000001807178B0-0x00000001807178C0
	private void Refresh(); // 0x00000001807178C0-0x0000000180717C00
	private void ShowStatic(); // 0x0000000180717C00-0x0000000180717DE0
	[IteratorStateMachine(typeof(_Run_d__19))]
	private IEnumerator Run(); // 0x0000000180717DE0-0x0000000180717E80
	private void StopLoop(); // 0x0000000180717E80-0x0000000180717F00
	private void OnDisable(); // 0x0000000180717F00-0x0000000180717F60
	private float Measure(); // 0x0000000180717F60-0x0000000180718130
	private static string[] Clean(string[] feed); // 0x0000000180718130-0x00000001807182A0
	private static bool Same(string[] a, string[] b); // 0x00000001807182A0-0x00000001807183C0
}

