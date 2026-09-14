/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class LoginCredentialStore // TypeDefIndex: 1042
{
	// Properties
	public static string Username { get; set; } // 0x00000001806498A0-0x0000000180649910 0x0000000180649910-0x0000000180649A30
	public static bool RememberMe { get; set; } // 0x0000000180649A30-0x0000000180649A80 0x0000000180649A80-0x0000000180649B80
	public static bool HasRememberToken { get; } // 0x0000000180649B80-0x0000000180649BF0 

	// Methods
	public static string LoadToken(); // 0x0000000180649BF0-0x0000000180649D40
	public static void SaveToken(string user, string token); // 0x0000000180649D40-0x0000000180649F10
	public static void ClearToken(); // 0x0000000180649F10-0x000000018064A010
	public static void OnPasswordChangedElsewhere(); // 0x000000018064A010-0x000000018064A030
	public static bool TryTakeLegacyPassword(out string user, out string pass); // 0x000000018064A030-0x000000018064A140
	public static void ClearLegacyPassword(); // 0x000000018064A140-0x000000018064A150
	private static byte[] DeriveKey(); // 0x000000018064A150-0x000000018064A3E0
	private static string Protect(string plain); // 0x000000018064A3E0-0x000000018064A9F0
	private static string Unprotect(string blob); // 0x000000018064A9F0-0x000000018064AF00
}

