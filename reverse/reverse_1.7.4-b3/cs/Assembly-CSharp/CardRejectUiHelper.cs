/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class CardRejectUiHelper // TypeDefIndex: 2247
{
	// Fields
	private static float _lastToastAt; // 0x00

	// Constructors
	static CardRejectUiHelper(); // 0x0000000180ACB250-0x0000000180ACB290

	// Methods
	public static void HandleReject(int cardId, string reasonCode); // 0x0000000180ACA7F0-0x0000000180ACAA40
	private static bool RevertCard(int cardId); // 0x0000000180ACAA40-0x0000000180ACACE0
	public static string ReasonToVi(string code); // 0x0000000180ACACE0-0x0000000180ACB250
}

