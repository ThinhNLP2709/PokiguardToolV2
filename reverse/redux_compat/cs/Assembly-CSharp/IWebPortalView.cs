/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public interface IWebPortalView // TypeDefIndex: 900
{
	// Properties
	bool IsAlive { get; }

	// Methods
	bool Create(Action<string> onMessage, Action onLoaded, Action<string> onError, Action<string> onHttpError = null);
	void Load(string url);
	void SetScreenMargins(int left, int top, int right, int bottom);
	void SetVisible(bool visible);
	void Pause();
	void Resume();
	void Tick();
	void Destroy();
}

