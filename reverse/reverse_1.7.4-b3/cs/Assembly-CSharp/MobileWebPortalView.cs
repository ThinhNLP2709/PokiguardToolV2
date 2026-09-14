/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class MobileWebPortalView : IWebPortalView // TypeDefIndex: 1506
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
	public bool IsAlive { get; } // 0x000000018082C810-0x000000018082C8F0 

	// Constructors
	public MobileWebPortalView(Transform parent); // 0x00000001802D8A80-0x00000001802D8AE0

	// Methods
	public bool Create(Action<string> onMessage, Action onLoaded, Action<string> onError, Action<string> onHttpError = null); // 0x000000018082C8F0-0x000000018082D1B0
	public void Load(string url); // 0x000000018082D1B0-0x000000018082D2A0
	public void SetScreenMargins(int left, int top, int right, int bottom); // 0x000000018082D2A0-0x000000018082D400
	public void SetVisible(bool visible); // 0x000000018082D400-0x000000018082D530
	public void Pause(); // 0x000000018082D530-0x000000018082D620
	public void Resume(); // 0x000000018082D620-0x000000018082D710
	public void Tick(); // 0x000000018028A320-0x000000018028A330
	public void Destroy(); // 0x000000018082D710-0x000000018082D900
	private void RaiseMessage(string msg); // 0x0000000180423D90-0x0000000180423DB0
	private void RaiseLoaded(string url); // 0x000000018082D900-0x000000018082D920
	private void RaiseError(string msg); // 0x0000000180423DD0-0x0000000180423DF0
	private void RaiseHttpError(string msg); // 0x0000000180423DF0-0x0000000180423E10
}

