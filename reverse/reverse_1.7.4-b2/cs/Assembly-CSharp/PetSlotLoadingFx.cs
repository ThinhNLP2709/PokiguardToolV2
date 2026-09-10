/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class PetSlotLoadingFx // TypeDefIndex: 1061
{
	// Fields
	private const string CHILD_NAME = "PetLoadingFx"; // Metadata: 0x0068C35F
	private const string CONTROLLER_PATH = "amt/loadCtl"; // Metadata: 0x0068C36C
	private const float SPINNER_WORLD_SCALE = 2f; // Metadata: 0x0068C378
	private static RuntimeAnimatorController _controller; // 0x00
	private static bool _controllerMissingLogged; // 0x08

	// Methods
	public static void Show(SpriteRenderer petRenderer); // 0x0000000180511510-0x00000001805115B0
	public static void Hide(SpriteRenderer petRenderer); // 0x0000000180510E80-0x0000000180510F20
	private static GameObject Resolve(SpriteRenderer petRenderer, bool create); // 0x0000000180511070-0x0000000180511510
	private static RuntimeAnimatorController LoadController(); // 0x0000000180510F20-0x0000000180511070
}

