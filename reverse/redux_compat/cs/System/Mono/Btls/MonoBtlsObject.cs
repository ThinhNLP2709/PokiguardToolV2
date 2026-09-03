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

namespace Mono.Btls
{
	internal abstract class MonoBtlsObject : IDisposable // TypeDefIndex: 8595
	{
		// Fields
		private MonoBtlsHandle handle; // 0x10
		private Exception lastError; // 0x18
	
		// Properties
		internal MonoBtlsHandle Handle { get; } // 0x0000000181819BD0-0x0000000181819BF0 
		public bool IsValid { get; } // 0x0000000181819BF0-0x0000000181819C30 
	
		// Nested types
		protected internal abstract class MonoBtlsHandle : SafeHandle // TypeDefIndex: 8596
		{
			// Properties
			public override bool IsInvalid { get; } // 0x00000001813DEED0-0x00000001813DEEE0 
	
			// Constructors
			internal MonoBtlsHandle(IntPtr handle, bool ownsHandle); // 0x0000000181818CD0-0x0000000181818CE0
		}
	
		// Constructors
		internal MonoBtlsObject(MonoBtlsHandle handle); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		protected void CheckThrow(); // 0x00000001818198C0-0x0000000181819960
		protected Exception SetException(Exception ex); // 0x0000000181819BA0-0x0000000181819BD0
		protected void CheckError(bool ok, [CallerMemberName] string callerName = null); // 0x0000000181819530-0x00000001818196B0
		protected void CheckError(int ret, [CallerMemberName] string callerName = null); // 0x00000001818196B0-0x00000001818196C0
		protected internal void CheckLastError([CallerMemberName] string callerName = null); // 0x00000001818196C0-0x00000001818198C0
		private static extern void mono_btls_free(IntPtr data); // 0x0000000181819C30-0x0000000181819CB0
		protected void FreeDataPtr(IntPtr data); // 0x0000000181819B20-0x0000000181819BA0
		protected virtual void Close(); // 0x00000001802E76C0-0x00000001802E76D0
		protected void Dispose(bool disposing); // 0x0000000181819960-0x0000000181819A50
		public void Dispose(); // 0x0000000181819A50-0x0000000181819AB0
		~MonoBtlsObject(); // 0x0000000181819AB0-0x0000000181819B20
	}
}
