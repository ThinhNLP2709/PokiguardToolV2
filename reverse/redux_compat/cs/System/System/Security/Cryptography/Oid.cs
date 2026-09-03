/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography
{
	public sealed class Oid // TypeDefIndex: 8755
	{
		// Fields
		private string _value; // 0x10
		private string _friendlyName; // 0x18
		private OidGroup _group; // 0x20
	
		// Properties
		public string Value { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public string FriendlyName { get; } // 0x0000000181B776C0-0x0000000181B77750 
	
		// Constructors
		public Oid(); // 0x00000001802E5CB0-0x00000001802E5CC0
		public Oid(string oid); // 0x0000000181B77630-0x0000000181B776C0
		public Oid(string value, string friendlyName); // 0x0000000180CB0730-0x0000000180CB0780
		public Oid(Oid oid); // 0x0000000181B77590-0x0000000181B77630
		private Oid(string value, string friendlyName, OidGroup group); // 0x00000001818033E0-0x0000000181803440
	
		// Methods
		public static Oid FromOidValue(string oidValue, OidGroup group); // 0x0000000181B77420-0x0000000181B77590
	}
}
