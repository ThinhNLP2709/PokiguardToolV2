/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	public class NetworkCredential : ICredentials // TypeDefIndex: 9048
	{
		// Fields
		private string m_domain; // 0x10
		private string m_userName; // 0x18
		private SecureString m_password; // 0x20
	
		// Properties
		public string UserName { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181BF3770-0x0000000181BF37A0
		public string Password { get; set; } // 0x0000000181BF3590-0x0000000181BF35A0 0x0000000181BF3740-0x0000000181BF3770
		public string Domain { get; set; } // 0x0000000180377550-0x0000000180377560 0x0000000181BF3710-0x0000000181BF3740
	
		// Constructors
		public NetworkCredential(string userName, string password); // 0x0000000181BF3650-0x0000000181BF3710
		public NetworkCredential(string userName, string password, string domain); // 0x0000000181BF35A0-0x0000000181BF3650
	
		// Methods
		internal string InternalGetUserName(); // 0x00000001802F8EC0-0x00000001802F8ED0
		internal string InternalGetPassword(); // 0x0000000181BF3590-0x0000000181BF35A0
		internal string InternalGetDomain(); // 0x0000000180377550-0x0000000180377560
		public NetworkCredential GetCredential(Uri uri, string authType); // 0x0000000180370C60-0x0000000180370C70
	}
}
