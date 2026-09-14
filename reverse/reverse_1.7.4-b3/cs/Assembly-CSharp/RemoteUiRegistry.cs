/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class RemoteUiRegistry // TypeDefIndex: 1408
{
	// Fields
	private static readonly List<RemoteStyleBinding> _bindings; // 0x00
	private static bool _subscribed; // 0x08

	// Constructors
	static RemoteUiRegistry(); // 0x0000000180795C60-0x0000000180795DA0

	// Methods
	public static void Register(RemoteStyleBinding b); // 0x00000001807955F0-0x0000000180795880
	public static void Unregister(RemoteStyleBinding b); // 0x0000000180795880-0x0000000180795950
	public static void ApplyAll(); // 0x0000000180795950-0x0000000180795C60
}

