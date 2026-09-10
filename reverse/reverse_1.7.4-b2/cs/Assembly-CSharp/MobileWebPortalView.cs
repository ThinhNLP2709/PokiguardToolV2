/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class MobileWebPortalView : IWebPortalView // TypeDefIndex: 1095
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
	public bool IsAlive { get; } // 0x0000000180543160-0x00000001805431B0 

	// Constructors
	public MobileWebPortalView(Transform parent); // 0x00000001803EE810-0x00000001803EE850

	// Methods
	public bool Create(Action<string> onMessage, Action onLoaded, Action<string> onError, Action<string> onHttpError = null); // 0x0000000180542840-0x0000000180542D50
	public void Load(string url); // 0x0000000180542DF0-0x0000000180542E80
	public void SetScreenMargins(int left, int top, int right, int bottom); // 0x0000000180542FA0-0x00000001805430D0
	public void SetVisible(bool visible); // 0x00000001805430D0-0x0000000180543160
	public void Pause(); // 0x0000000180542E80-0x0000000180542F00
	public void Resume(); // 0x0000000180542F20-0x0000000180542FA0
	public void Tick(); // 0x00000001802EB6C0-0x00000001802EB6D0
	public void Destroy(); // 0x0000000180542D50-0x0000000180542DF0
	private void RaiseMessage(string msg); // 0x00000001803D9420-0x00000001803D9440
	private void RaiseLoaded(string url); // 0x0000000180542F00-0x0000000180542F20
	private void RaiseError(string msg); // 0x00000001803D9460-0x00000001803D9480
	private void RaiseHttpError(string msg); // 0x00000001803D9480-0x00000001803D94A0
}

