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

namespace System.Runtime.InteropServices.ComTypes
{
	[ComImport]
	[Guid("0000000c-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IStream // TypeDefIndex: 3166
	{
		// Methods
		void Read(out byte[] pv, int cb, IntPtr pcbRead); // 0x000000018150CF40-0x000000018150D010
		void Write(byte[] pv, int cb, IntPtr pcbWritten); // 0x000000018150D280-0x000000018150D2F0
		void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition); // 0x000000018150D040-0x000000018150D0A0
		void SetSize(long libNewSize); // 0x000000018150D0A0-0x000000018150D0E0
		void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten); // 0x000000018150CE20-0x000000018150CEE0
		void Commit(int grfCommitFlags); // 0x000000018150CDE0-0x000000018150CE20
		void Revert(); // 0x000000018150D010-0x000000018150D040
		void LockRegion(long libOffset, long cb, int dwLockType); // 0x000000018150CEE0-0x000000018150CF40
		void UnlockRegion(long libOffset, long cb, int dwLockType); // 0x000000018150D220-0x000000018150D280
		void Stat(out STATSTG pstatstg, int grfStatFlag); // 0x000000018150D0E0-0x000000018150D220
		void Clone(out IStream ppstm); // 0x000000018150CD30-0x000000018150CDE0
	}
}
