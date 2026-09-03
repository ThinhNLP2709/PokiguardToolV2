/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	internal static class ManagedStreamHelpers // TypeDefIndex: 7759
	{
		// Methods
		internal static void ValidateLoadFromStream(Stream stream); // 0x00000001821EC2E0-0x00000001821EC450
		[RequiredByNativeCode]
		internal static void ManagedStreamRead(Span<byte> buffer, Stream stream, IntPtr returnValueAddress); // 0x00000001821EC120-0x00000001821EC200
		[RequiredByNativeCode]
		internal static void ManagedStreamSeek(long offset, uint origin, Stream stream, IntPtr returnValueAddress); // 0x00000001821EC200-0x00000001821EC2E0
		[RequiredByNativeCode]
		internal static void ManagedStreamLength(Stream stream, IntPtr returnValueAddress); // 0x00000001821EC060-0x00000001821EC120
	}
}
