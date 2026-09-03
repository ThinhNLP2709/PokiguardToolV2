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

namespace System.Net
{
	[Flags]
	internal enum FtpMethodFlags // TypeDefIndex: 9019
	{
		None = 0,
		IsDownload = 1,
		IsUpload = 2,
		TakesParameter = 4,
		MayTakeParameter = 8,
		DoesNotTakeParameter = 16,
		ParameterIsDirectory = 32,
		ShouldParseForResponseUri = 64,
		HasHttpCommand = 128,
		MustChangeWorkingDirectoryToPath = 256
	}
}
