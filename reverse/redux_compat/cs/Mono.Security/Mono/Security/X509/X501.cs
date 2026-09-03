/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Mono.Security;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.X509
{
	public sealed class X501 // TypeDefIndex: 13819
	{
		// Fields
		private static byte[] countryName; // 0x00
		private static byte[] organizationName; // 0x08
		private static byte[] organizationalUnitName; // 0x10
		private static byte[] commonName; // 0x18
		private static byte[] localityName; // 0x20
		private static byte[] stateOrProvinceName; // 0x28
		private static byte[] streetAddress; // 0x30
		private static byte[] serialNumber; // 0x38
		private static byte[] domainComponent; // 0x40
		private static byte[] userid; // 0x48
		private static byte[] email; // 0x50
		private static byte[] dnQualifier; // 0x58
		private static byte[] title; // 0x60
		private static byte[] surname; // 0x68
		private static byte[] givenName; // 0x70
		private static byte[] initial; // 0x78
	
		// Constructors
		static X501(); // 0x00000001814114B0-0x0000000181411AD0
	
		// Methods
		public static string ToString(ASN1 seq); // 0x0000000181411350-0x00000001814114B0
		public static string ToString(ASN1 seq, bool reversed, string separator, bool quotes); // 0x0000000181411150-0x0000000181411350
		private static void AppendEntry(StringBuilder sb, ASN1 entry, bool quotes); // 0x000000018140EE10-0x000000018140F7C0
		private static X520.AttributeTypeAndValue GetAttributeFromOid(string attributeType); // 0x000000018140FC30-0x00000001814106B0
		private static bool IsOid(string oid); // 0x0000000181410730-0x0000000181410820
		private static X520.AttributeTypeAndValue ReadAttribute(string value, ref int pos); // 0x0000000181410820-0x00000001814109B0
		private static bool IsHex(char c); // 0x00000001814106B0-0x0000000181410730
		private static string ReadHex(string value, ref int pos); // 0x0000000181410B60-0x0000000181410D50
		private static int ReadEscaped(StringBuilder sb, string value, int pos); // 0x00000001814109B0-0x0000000181410B60
		private static int ReadQuoted(StringBuilder sb, string value, int pos); // 0x0000000181410D50-0x0000000181410EA0
		private static string ReadValue(string value, ref int pos); // 0x0000000181410EA0-0x0000000181411150
		public static ASN1 FromString(string rdn); // 0x000000018140F7C0-0x000000018140FC30
	}
}
