/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class LeanTest // TypeDefIndex: 292
{
	// Fields
	public static int expected; // 0x00
	private static int tests; // 0x04
	private static int passes; // 0x08
	public static float timeout; // 0x0C
	public static bool timeoutStarted; // 0x10
	public static bool testsFinished; // 0x11

	// Constructors
	public LeanTest(); // 0x00000001802E5CB0-0x00000001802E5CC0
	static LeanTest(); // 0x00000001806D20C0-0x00000001806D2150

	// Methods
	public static void debug(string name, bool didPass, string failExplaination = null); // 0x00000001806D2150-0x00000001806D21C0
	public static void expect(bool didPass, string definition, string failExplaination = null); // 0x00000001806D21C0-0x00000001806D27F0
	public static string padRight(int len); // 0x00000001806D2CB0-0x00000001806D2D10
	public static float printOutLength(string str); // 0x00000001806D2D10-0x00000001806D2E50
	public static string formatBC(string str, string color); // 0x00000001806D27F0-0x00000001806D2890
	public static string formatB(string str); // 0x00000001806D2890-0x00000001806D28E0
	public static string formatC(string str, string color); // 0x00000001806D28E0-0x00000001806D2A00
	public static void overview(); // 0x00000001806D2A00-0x00000001806D2CB0
}

