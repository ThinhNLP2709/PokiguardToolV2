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

namespace System.Security.Principal
{
	[ComVisible(true)]
	public class WindowsImpersonationContext : IDisposable // TypeDefIndex: 2862
	{
		// Fields
		private IntPtr _token; // 0x10
		private bool undo; // 0x18
	
		// Constructors
		internal WindowsImpersonationContext(IntPtr token); // 0x00000001814CBA20-0x00000001814CBAB0
	
		// Methods
		[ComVisible(false)]
		public void Dispose(); // 0x00000001814CB880-0x00000001814CB940
		public void Undo(); // 0x00000001814CB970-0x00000001814CBA20
		private static bool CloseToken(IntPtr token); // 0x00000001814CB870-0x00000001814CB880
		private static IntPtr DuplicateToken(IntPtr token); // 0x00000001814CB940-0x00000001814CB950
		private static bool SetCurrentToken(IntPtr token); // 0x00000001814CB960-0x00000001814CB970
		private static bool RevertToSelf(); // 0x00000001814CB950-0x00000001814CB960
	}
}
