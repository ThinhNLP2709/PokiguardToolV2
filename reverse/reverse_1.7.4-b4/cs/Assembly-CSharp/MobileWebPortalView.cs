/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class MobileWebPortalView : IWebPortalView // TypeDefIndex: 1508
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
	public bool IsAlive { get; } // 0x000000018082E920-0x000000018082EA00 

	// Constructors
	public MobileWebPortalView(Transform parent); // 0x00000001802D8AB0-0x00000001802D8B10

	// Methods
	public bool Create(Action<string> onMessage, Action onLoaded, Action<string> onError, Action<string> onHttpError = null); // 0x000000018082EA00-0x000000018082F2C0
	public void Load(string url); // 0x000000018082F2C0-0x000000018082F3B0
	public void SetScreenMargins(int left, int top, int right, int bottom); // 0x000000018082F3B0-0x000000018082F510
	public void SetVisible(bool visible); // 0x000000018082F510-0x000000018082F640
	public void Pause(); // 0x000000018082F640-0x000000018082F730
	public void Resume(); // 0x000000018082F730-0x000000018082F820
	public void Tick(); // 0x000000018028A320-0x000000018028A330
	public void Destroy(); // 0x000000018082F820-0x000000018082FA10
	private void RaiseMessage(string msg); // 0x0000000180424AF0-0x0000000180424B10
	private void RaiseLoaded(string url); // 0x000000018082FA10-0x000000018082FA30
	private void RaiseError(string msg); // 0x0000000180424B30-0x0000000180424B50
	private void RaiseHttpError(string msg); // 0x0000000180424B50-0x0000000180424B70
}

