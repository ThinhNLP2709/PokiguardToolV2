/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class RemoteUiRegistry // TypeDefIndex: 1410
{
	// Fields
	private static readonly List<RemoteStyleBinding> _bindings; // 0x00
	private static bool _subscribed; // 0x08

	// Constructors
	static RemoteUiRegistry(); // 0x0000000180797CD0-0x0000000180797E10

	// Methods
	public static void Register(RemoteStyleBinding b); // 0x0000000180797660-0x00000001807978F0
	public static void Unregister(RemoteStyleBinding b); // 0x00000001807978F0-0x00000001807979C0
	public static void ApplyAll(); // 0x00000001807979C0-0x0000000180797CD0
}

