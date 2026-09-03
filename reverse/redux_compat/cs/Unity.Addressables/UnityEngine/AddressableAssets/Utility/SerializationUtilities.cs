/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets.Utility
{
	internal static class SerializationUtilities // TypeDefIndex: 14087
	{
		// Nested types
		internal enum ObjectType // TypeDefIndex: 14088
		{
			AsciiString = 0,
			UnicodeString = 1,
			UInt16 = 2,
			UInt32 = 3,
			Int32 = 4,
			Hash128 = 5,
			Type = 6,
			JsonObject = 7
		}
	
		// Methods
		internal static int ReadInt32FromByteArray(byte[] data, int offset); // 0x0000000181501B00-0x0000000181501B70
		internal static int WriteInt32ToByteArray(byte[] data, int val, int offset); // 0x0000000181C81370-0x0000000181C813E0
		internal static object ReadObjectFromByteArray(byte[] keyData, int dataIndex); // 0x0000000181C80F70-0x0000000181C81370
		internal static int WriteObjectToByteList(object obj, List<byte> buffer); // 0x0000000181C813E0-0x0000000181C81BB0
	}
}
