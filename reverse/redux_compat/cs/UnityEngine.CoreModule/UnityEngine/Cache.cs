/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Misc/Cache.h")]
	[StaticAccessor("CacheWrapper", StaticAccessorType.DoubleColon)]
	public struct Cache : IEquatable<UnityEngine.Cache> // TypeDefIndex: 7495
	{
		// Fields
		private int m_Handle; // 0x00
	
		// Properties
		internal int handle { get; } // 0x0000000180732D10-0x0000000180732D20 
		public bool valid { get; } // 0x000000018217B6B0-0x000000018217B6F0 
		public string path { get; } // 0x000000018217B6A0-0x000000018217B6B0 
		public long maximumAvailableStorageSpace { set; } // 0x000000018217B730-0x000000018217B770
		public int expirationDelay { set; } // 0x000000018217B6F0-0x000000018217B730
	
		// Methods
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
		public override bool Equals(object other); // 0x000000018217B620-0x000000018217B6A0
		public bool Equals(Cache other); // 0x00000001815FCAB0-0x00000001815FCAC0
		internal static bool Cache_IsValid(int handle); // 0x000000018217B560-0x000000018217B5A0
		[NativeMethod(ThrowsException = true)]
		internal static string Cache_GetPath(int handle); // 0x000000018217B4A0-0x000000018217B560
		[NativeMethod(ThrowsException = true)]
		internal static void Cache_SetMaximumDiskSpaceAvailable(int handle, long value); // 0x000000018217B5E0-0x000000018217B620
		[NativeMethod(ThrowsException = true)]
		internal static void Cache_SetExpirationDelay(int handle, int value); // 0x000000018217B5A0-0x000000018217B5E0
		private static void Cache_GetPath_Injected(int handle, ); // 0x000000018217B460-0x000000018217B4A0
	}
}
