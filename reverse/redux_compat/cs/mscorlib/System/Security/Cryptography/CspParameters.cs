/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public sealed class CspParameters // TypeDefIndex: 2788
	{
		// Fields
		public int ProviderType; // 0x10
		public string ProviderName; // 0x18
		public string KeyContainerName; // 0x20
		public int KeyNumber; // 0x28
		private int m_flags; // 0x2C
	
		// Properties
		public CspProviderFlags Flags { get; set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x000000018148CE70-0x000000018148CF50
	
		// Constructors
		public CspParameters(); // 0x000000018148CD10-0x000000018148CD70
		public CspParameters(int dwTypeIn); // 0x000000018148CCB0-0x000000018148CD10
		public CspParameters(int dwTypeIn, string strProviderNameIn, string strContainerNameIn); // 0x000000018148CDF0-0x000000018148CE70
		internal CspParameters(int providerType, string providerName, string keyContainerName, CspProviderFlags flags); // 0x000000018148CD70-0x000000018148CDF0
	}
}
