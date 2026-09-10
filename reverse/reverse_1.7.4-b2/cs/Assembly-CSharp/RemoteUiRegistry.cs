/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class RemoteUiRegistry // TypeDefIndex: 1030
{
	// Fields
	private static readonly List<RemoteStyleBinding> _bindings; // 0x00
	private static bool _subscribed; // 0x08

	// Constructors
	static RemoteUiRegistry(); // 0x0000000180509510-0x00000001805095A0

	// Methods
	public static void Register(RemoteStyleBinding b); // 0x00000001805092D0-0x0000000180509490
	public static void Unregister(RemoteStyleBinding b); // 0x0000000180509490-0x0000000180509510
	public static void ApplyAll(); // 0x0000000180509050-0x00000001805092D0
}

