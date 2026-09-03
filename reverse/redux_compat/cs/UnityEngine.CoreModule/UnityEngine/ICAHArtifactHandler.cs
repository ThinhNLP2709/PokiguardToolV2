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
	internal interface ICAHArtifactHandler // TypeDefIndex: 7859
	{
		// Methods
		bool Exists(Hash128 hash);
		bool Open(Hash128 hash, out IManagedVFSFileHandler handler, out int handle);
	}
}
