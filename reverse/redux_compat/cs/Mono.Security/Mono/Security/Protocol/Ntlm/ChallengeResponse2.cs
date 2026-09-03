/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.Protocol.Ntlm
{
	public static class ChallengeResponse2 // TypeDefIndex: 13853
	{
		// Fields
		private static byte[] magic; // 0x00
		private static byte[] nullEncMagic; // 0x08
	
		// Constructors
		static ChallengeResponse2(); // 0x0000000181402890-0x0000000181402970
	
		// Methods
		private static byte[] Compute_LM(string password, byte[] challenge); // 0x0000000181401510-0x00000001814017C0
		private static byte[] Compute_NTLM_Password(string password); // 0x00000001814017C0-0x00000001814018D0
		private static byte[] Compute_NTLM(string password, byte[] challenge); // 0x00000001814018D0-0x0000000181401940
		private static void Compute_NTLMv2_Session(string password, byte[] challenge, out byte[] lm, out byte[] ntlm); // 0x0000000181401940-0x0000000181401B80
		private static byte[] Compute_NTLMv2(Type2Message type2, string username, string password, string domain); // 0x0000000181401B80-0x00000001814020C0
		public static void Compute(Type2Message type2, NtlmAuthLevel level, string username, string password, string domain, out byte[] lm, out byte[] ntlm); // 0x00000001814020C0-0x00000001814022D0
		private static byte[] GetResponse(byte[] challenge, byte[] pwd); // 0x00000001814022D0-0x0000000181402530
		private static byte[] PrepareDESKey(byte[] key56bits, int position); // 0x00000001814026A0-0x0000000181402890
		private static byte[] PasswordToKey(string password, int position); // 0x0000000181402530-0x00000001814026A0
	}
}
