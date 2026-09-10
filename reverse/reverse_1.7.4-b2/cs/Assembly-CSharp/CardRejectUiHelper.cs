/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class CardRejectUiHelper // TypeDefIndex: 1881
{
	// Fields
	private const float TOAST_THROTTLE_SEC = 1.2f; // Metadata: 0x0068DA10
	private static float _lastToastAt; // 0x00

	// Constructors
	static CardRejectUiHelper(); // 0x00000001806D9FE0-0x00000001806DA020

	// Methods
	public static void HandleReject(int cardId, string reasonCode); // 0x00000001806D9980-0x00000001806D9AF0
	private static bool RevertCard(int cardId); // 0x00000001806D9E50-0x00000001806D9FE0
	public static string ReasonToVi(string code); // 0x00000001806D9AF0-0x00000001806D9E50
}

