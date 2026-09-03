/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[IsByRefLike]
	[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
	internal struct WriteLockScope // TypeDefIndex: 7868
	{
		// Fields
		private readonly ReaderWriterLockSlim m_Lock; // 0x00
	
		// Constructors
		public WriteLockScope(ReaderWriterLockSlim rwLock); // 0x0000000182229470-0x0000000182229500
	
		// Methods
		public void Dispose(); // 0x0000000182229450-0x0000000182229470
	}
}
