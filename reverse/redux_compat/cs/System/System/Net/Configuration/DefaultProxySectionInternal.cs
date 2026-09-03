/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net.Configuration
{
	internal sealed class DefaultProxySectionInternal // TypeDefIndex: 9202
	{
		// Fields
		private IWebProxy webProxy; // 0x10
		private static object classSyncObject; // 0x00
	
		// Properties
		internal static object ClassSyncObject { get; } // 0x0000000181B26B00-0x0000000181B26B90 
		internal IWebProxy WebProxy { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		public DefaultProxySectionInternal(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		private static IWebProxy GetDefaultProxy_UsingOldMonoCode(); // 0x0000000181B26970-0x0000000181B26980
		private static IWebProxy GetSystemWebProxy(); // 0x0000000181B26970-0x0000000181B26980
		internal static DefaultProxySectionInternal GetSection(); // 0x0000000181B26980-0x0000000181B26B00
	}
}
