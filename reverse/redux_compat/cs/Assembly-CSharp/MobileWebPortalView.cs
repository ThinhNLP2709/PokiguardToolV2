/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class MobileWebPortalView : IWebPortalView // TypeDefIndex: 901
{
	// Fields
	private readonly Transform _parent; // 0x10
	private WebViewObject _web; // 0x18
	private GameObject _go; // 0x20
	private Action<string> _onMessage; // 0x28
	private Action _onLoaded; // 0x30
	private Action<string> _onError; // 0x38
	private Action<string> _onHttpError; // 0x40

	// Properties
	public bool IsAlive { get; } // 0x00000001804526A0-0x00000001804526F0 

	// Constructors
	public MobileWebPortalView(Transform parent); // 0x00000001803855F0-0x0000000180385630

	// Methods
	public bool Create(Action<string> onMessage, Action onLoaded, Action<string> onError, Action<string> onHttpError = null); // 0x0000000180451D80-0x0000000180452290
	public void Load(string url); // 0x0000000180452330-0x00000001804523C0
	public void SetScreenMargins(int left, int top, int right, int bottom); // 0x00000001804524E0-0x0000000180452610
	public void SetVisible(bool visible); // 0x0000000180452610-0x00000001804526A0
	public void Pause(); // 0x00000001804523C0-0x0000000180452440
	public void Resume(); // 0x0000000180452460-0x00000001804524E0
	public void Tick(); // 0x00000001802E76C0-0x00000001802E76D0
	public void Destroy(); // 0x0000000180452290-0x0000000180452330
	private void RaiseMessage(string msg); // 0x00000001803721F0-0x0000000180372210
	private void RaiseLoaded(string url); // 0x0000000180452440-0x0000000180452460
	private void RaiseError(string msg); // 0x0000000180372230-0x0000000180372250
	private void RaiseHttpError(string msg); // 0x0000000180372250-0x0000000180372270
}

