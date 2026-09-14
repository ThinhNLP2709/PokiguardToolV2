/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class PetSlotLoadingFx // TypeDefIndex: 1440
{
	// Fields
	private static RuntimeAnimatorController _controller; // 0x00
	private static bool _controllerMissingLogged; // 0x08

	// Methods
	public static void Show(SpriteRenderer petRenderer); // 0x00000001807D2DD0-0x00000001807D2FF0
	public static void Hide(SpriteRenderer petRenderer); // 0x00000001807D2FF0-0x00000001807D3210
	private static GameObject Resolve(SpriteRenderer petRenderer, bool create); // 0x00000001807D3210-0x00000001807D3A80
	private static RuntimeAnimatorController LoadController(); // 0x00000001807D3A80-0x00000001807D3D50
}

