/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class CardRejectUiHelper // TypeDefIndex: 1617
{
	// Fields
	private const float TOAST_THROTTLE_SEC = 1.2f; // Metadata: 0x0064D7E3
	private static float _lastToastAt; // 0x00

	// Constructors
	static CardRejectUiHelper(); // 0x00000001805AEA90-0x00000001805AEAD0

	// Methods
	public static void HandleReject(int cardId, string reasonCode); // 0x00000001805AE430-0x00000001805AE5A0
	private static bool RevertCard(int cardId); // 0x00000001805AE900-0x00000001805AEA90
	public static string ReasonToVi(string code); // 0x00000001805AE5A0-0x00000001805AE900
}

