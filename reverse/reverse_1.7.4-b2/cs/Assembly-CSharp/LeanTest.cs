/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class LeanTest // TypeDefIndex: 318
{
	// Fields
	public static int expected; // 0x00
	private static int tests; // 0x04
	private static int passes; // 0x08
	public static float timeout; // 0x0C
	public static bool timeoutStarted; // 0x10
	public static bool testsFinished; // 0x11

	// Constructors
	public LeanTest(); // 0x00000001802E9CB0-0x00000001802E9CC0
	static LeanTest(); // 0x000000018031EF40-0x000000018031EFD0

	// Methods
	public static void debug(string name, bool didPass, string failExplaination = null); // 0x000000018031EFD0-0x000000018031F040
	public static void expect(bool didPass, string definition, string failExplaination = null); // 0x000000018031F040-0x000000018031F670
	public static string padRight(int len); // 0x000000018031FB30-0x000000018031FB90
	public static float printOutLength(string str); // 0x000000018031FB90-0x000000018031FCD0
	public static string formatBC(string str, string color); // 0x000000018031F670-0x000000018031F710
	public static string formatB(string str); // 0x000000018031F710-0x000000018031F760
	public static string formatC(string str, string color); // 0x000000018031F760-0x000000018031F880
	public static void overview(); // 0x000000018031F880-0x000000018031FB30
}

