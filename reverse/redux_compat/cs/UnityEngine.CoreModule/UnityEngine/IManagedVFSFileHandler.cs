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
	[VisibleToOtherModules(new string[2] {"UnityEngine.ContentLoadModule", "ContentBuildLoadPreview" })]
	internal interface IManagedVFSFileHandler // TypeDefIndex: 7866
	{
		// Methods
		void ReadAsync(int handle, long offset, IntPtr buffer, int count, ManagedReadAsyncCommand command);
		long GetSize(int handle);
		void Close(int handle);
	}
}
