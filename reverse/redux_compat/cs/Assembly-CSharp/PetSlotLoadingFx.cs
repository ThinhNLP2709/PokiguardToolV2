/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class PetSlotLoadingFx // TypeDefIndex: 860
{
	// Fields
	private const string CHILD_NAME = "PetLoadingFx"; // Metadata: 0x0064CBC9
	private const string CONTROLLER_PATH = "amt/loadCtl"; // Metadata: 0x0064CBD6
	private const float SPINNER_WORLD_SCALE = 2f; // Metadata: 0x0064CBE2
	private static RuntimeAnimatorController _controller; // 0x00
	private static bool _controllerMissingLogged; // 0x08

	// Methods
	public static void Show(SpriteRenderer petRenderer); // 0x000000018043D480-0x000000018043D520
	public static void Hide(SpriteRenderer petRenderer); // 0x000000018043CDF0-0x000000018043CE90
	private static GameObject Resolve(SpriteRenderer petRenderer, bool create); // 0x000000018043CFE0-0x000000018043D480
	private static RuntimeAnimatorController LoadController(); // 0x000000018043CE90-0x000000018043CFE0
}

