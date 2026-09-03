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
using Microsoft.Win32.SafeHandles;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Microsoft.Win32
{
	public sealed class RegistryKey : MarshalByRefObject, IDisposable // TypeDefIndex: 2148
	{
		// Fields
		internal static readonly IntPtr HKEY_CLASSES_ROOT; // 0x00
		internal static readonly IntPtr HKEY_CURRENT_USER; // 0x08
		internal static readonly IntPtr HKEY_LOCAL_MACHINE; // 0x10
		internal static readonly IntPtr HKEY_USERS; // 0x18
		internal static readonly IntPtr HKEY_PERFORMANCE_DATA; // 0x20
		internal static readonly IntPtr HKEY_CURRENT_CONFIG; // 0x28
		internal static readonly IntPtr HKEY_DYN_DATA; // 0x30
		private static readonly string[] s_hkeyNames; // 0x38
		private SafeRegistryHandle _hkey; // 0x18
		private string _keyName; // 0x20
		private bool _remoteKey; // 0x28
		private StateFlags _state; // 0x2C
		private RegistryKeyPermissionCheck _checkMode; // 0x30
		private RegistryView _regView; // 0x34
	
		// Nested types
		[Flags]
		private enum StateFlags // TypeDefIndex: 2149
		{
			Dirty = 1,
			SystemKey = 2,
			WriteAccess = 4,
			PerfData = 8
		}
	
		// Constructors
		private RegistryKey(SafeRegistryHandle hkey, bool writable, bool systemkey, bool remoteKey, bool isPerfData, RegistryView view); // 0x00000001814529B0-0x0000000181452B30
		static RegistryKey(); // 0x00000001814526C0-0x00000001814529B0
	
		// Methods
		private void ClosePerfDataKey(); // 0x0000000181450310-0x0000000181450370
		private static RegistryKey OpenBaseKeyCore(RegistryHive hKeyHive, RegistryView view); // 0x0000000181451BE0-0x0000000181451D40
		private RegistryKey InternalOpenSubKeyCore(string name, bool writable, bool throwOnPermissionFailure); // 0x0000000181451810-0x0000000181451A00
		private int InternalSubKeyCountCore(); // 0x0000000181451A00-0x0000000181451AA0
		private string[] InternalGetSubKeyNamesCore(int subkeys); // 0x0000000181450BB0-0x0000000181450E30
		private object InternalGetValueCore(string name, object defaultValue, bool doNotExpand); // 0x0000000181450E30-0x0000000181451760
		private void Win32Error(int errorCode, string str); // 0x0000000181452520-0x00000001814526C0
		private static int GetRegistryKeyAccess(bool isWritable); // 0x0000000181450850-0x0000000181450870
		public void Dispose(); // 0x0000000181450370-0x00000001814504B0
		public static RegistryKey OpenBaseKey(RegistryHive hKey, RegistryView view); // 0x0000000181451D40-0x0000000181451F30
		public RegistryKey OpenSubKey(string name, bool writable); // 0x0000000181451F30-0x0000000181452010
		private int InternalSubKeyCount(); // 0x0000000181451AA0-0x0000000181451BA0
		public string[] GetSubKeyNames(); // 0x0000000181450870-0x0000000181450A30
		private string[] InternalGetSubKeyNames(); // 0x0000000181450870-0x0000000181450A30
		public object GetValue(string name, object defaultValue, RegistryValueOptions options); // 0x0000000181450A90-0x0000000181450BB0
		private object InternalGetValue(string name, object defaultValue, bool doNotExpand, bool checkSecurity); // 0x0000000181451760-0x0000000181451810
		public override string ToString(); // 0x0000000181452010-0x0000000181452080
		private static string FixupName(string name); // 0x0000000181450510-0x0000000181450720
		private static void FixupPath(StringBuilder path); // 0x0000000181450720-0x0000000181450850
		private void EnsureNotDisposed(); // 0x00000001814504B0-0x0000000181450510
		private RegistryKeyPermissionCheck GetSubKeyPermissionCheck(bool subkeyWritable); // 0x0000000181450A30-0x0000000181450A90
		private static void ValidateKeyName(string name); // 0x0000000181452080-0x00000001814524C0
		private static void ValidateKeyView(RegistryView view); // 0x00000001814524C0-0x0000000181452520
		private bool IsSystemKey(); // 0x0000000181451BC0-0x0000000181451BE0
		private bool IsPerfDataKey(); // 0x0000000181451BA0-0x0000000181451BC0
	}
}
