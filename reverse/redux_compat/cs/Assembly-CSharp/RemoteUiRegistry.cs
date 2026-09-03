/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class RemoteUiRegistry // TypeDefIndex: 834
{
	// Fields
	private static readonly List<RemoteStyleBinding> _bindings; // 0x00
	private static bool _subscribed; // 0x08

	// Constructors
	static RemoteUiRegistry(); // 0x000000018042E750-0x000000018042E7E0

	// Methods
	public static void Register(RemoteStyleBinding b); // 0x000000018042E510-0x000000018042E6D0
	public static void Unregister(RemoteStyleBinding b); // 0x000000018042E6D0-0x000000018042E750
	public static void ApplyAll(); // 0x000000018042E290-0x000000018042E510
}

