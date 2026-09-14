/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class LoginCredentialStore // TypeDefIndex: 1044
{
	// Properties
	public static string Username { get; set; } // 0x000000018064B290-0x000000018064B300 0x000000018064B300-0x000000018064B420
	public static bool RememberMe { get; set; } // 0x000000018064B420-0x000000018064B470 0x000000018064B470-0x000000018064B570
	public static bool HasRememberToken { get; } // 0x000000018064B570-0x000000018064B5E0 

	// Methods
	public static string LoadToken(); // 0x000000018064B5E0-0x000000018064B730
	public static void SaveToken(string user, string token); // 0x000000018064B730-0x000000018064B900
	public static void ClearToken(); // 0x000000018064B900-0x000000018064BA00
	public static void OnPasswordChangedElsewhere(); // 0x000000018064BA00-0x000000018064BA20
	public static bool TryTakeLegacyPassword(out string user, out string pass); // 0x000000018064BA20-0x000000018064BB30
	public static void ClearLegacyPassword(); // 0x000000018064BB30-0x000000018064BB40
	private static byte[] DeriveKey(); // 0x000000018064BB40-0x000000018064BDD0
	private static string Protect(string plain); // 0x000000018064BDD0-0x000000018064C3E0
	private static string Unprotect(string blob); // 0x000000018064C3E0-0x000000018064C8F0
}

