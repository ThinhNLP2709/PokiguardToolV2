/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting
{
	[Nullable(0)]
	[NullableContext(1)]
	internal static class StackTrace // TypeDefIndex: 14829
	{
		// Fields
		private const string k_HideInCallstackAttributeTypeName = "UnityEngine.HideInCallstackAttribute"; // Metadata: 0x006A985C
		private const string k_InteropNamespace = "Unity.Private.Scripting.Interop"; // Metadata: 0x006A9881
		private const string k_InvokeWrapperPrefix = "runtime_invoke_wrapper"; // Metadata: 0x006A98A1
		private static string s_BasePath; // 0x00
		[CompilerGenerated]
		private static bool _UseMonoFormat_k__BackingField; // 0x08
	
		// Properties
		internal static string BasePath { get; set; } // 0x000000018206BAE0-0x000000018206BB30 0x000000018206BB80-0x000000018206BC80
		internal static bool UseMonoFormat { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018206BB30-0x000000018206BB80 0x000000018206BC80-0x000000018206BCE0
	
		// Constructors
		static StackTrace(); // 0x000000018206BA70-0x000000018206BAE0
	
		// Methods
		internal static void GetMessageAndStackTrace([Nullable(2)] Exception exception, out string message, out string stackTrace); // 0x000000018206AB70-0x000000018206AEF0
		private static string NormalizeManagedExceptionTrace([Nullable(2)] string rawTrace); // 0x000000018206B300-0x000000018206B670
		[NullableContext(0)]
		private static bool ExtractNextLine(ReadOnlySpan<char> trace, out ReadOnlySpan<char> line, out ReadOnlySpan<char> remaining); // 0x000000018206A450-0x000000018206A5D0
		internal static string Format(System.Diagnostics.StackTrace stackTrace); // 0x000000018206A5D0-0x000000018206AB70
		private static bool ShouldStripLineNumbers(MethodBase method); // 0x000000018206B670-0x000000018206BA70
		private static bool HasHideInCallstackAttribute(MethodBase method); // 0x000000018206AEF0-0x000000018206B300
	}
}
