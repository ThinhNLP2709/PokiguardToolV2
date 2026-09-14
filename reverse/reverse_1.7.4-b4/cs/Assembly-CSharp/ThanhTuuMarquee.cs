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
public sealed class ThanhTuuMarquee : MonoBehaviour // TypeDefIndex: 1272
{
	// Fields
	public const float PAD_LEFT = 12f; // Metadata: 0x005F0A53
	public const float FONT = 22f; // Metadata: 0x005F0A57
	public static readonly Color TEXT_COLOR; // 0x00
	private RectTransform _root; // 0x20
	private RectTransform _txtRt; // 0x28
	private UnityEngine.UI.Text _txt; // 0x30
	private string[] _feed; // 0x38
	private int _index; // 0x40
	private bool _running; // 0x44
	private Coroutine _loop; // 0x48

	// Properties
	public bool HasFeed { get; } // 0x0000000180718C00-0x0000000180718C20 
	public UnityEngine.UI.Text Label { get; } // 0x00000001802B4AE0-0x00000001802B4AF0 

	// Nested types
	[CompilerGenerated]
	private sealed class _Run_d__19 : IEnumerator<object> // TypeDefIndex: 1273
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018071A300-0x000000018071A7C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018071A7C0-0x000000018071A800
	}

	// Constructors
	public ThanhTuuMarquee(); // 0x000000018071A170-0x000000018071A240
	static ThanhTuuMarquee(); // 0x000000018071A240-0x000000018071A300

	// Methods
	public static ThanhTuuMarquee Build(RectTransform node); // 0x0000000180718C20-0x00000001807194A0
	public void SetFeed(string[] feed); // 0x00000001807194A0-0x0000000180719660
	public void SetRunning(bool on); // 0x0000000180719660-0x0000000180719670
	private void Refresh(); // 0x0000000180719670-0x00000001807199B0
	private void ShowStatic(); // 0x00000001807199B0-0x0000000180719B90
	[IteratorStateMachine(typeof(_Run_d__19))]
	private IEnumerator Run(); // 0x0000000180719B90-0x0000000180719C30
	private void StopLoop(); // 0x0000000180719C30-0x0000000180719CB0
	private void OnDisable(); // 0x0000000180719CB0-0x0000000180719D10
	private float Measure(); // 0x0000000180719D10-0x0000000180719EE0
	private static string[] Clean(string[] feed); // 0x0000000180719EE0-0x000000018071A050
	private static bool Same(string[] a, string[] b); // 0x000000018071A050-0x000000018071A170
}

