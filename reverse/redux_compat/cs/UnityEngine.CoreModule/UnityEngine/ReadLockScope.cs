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
	internal struct ReadLockScope // TypeDefIndex: 7867
	{
		// Fields
		private readonly ReaderWriterLockSlim m_Lock; // 0x00
	
		// Constructors
		public ReadLockScope(ReaderWriterLockSlim rwLock); // 0x000000018220A000-0x000000018220A030
	
		// Methods
		public void Dispose(); // 0x0000000182209FE0-0x000000018220A000
	}
}
