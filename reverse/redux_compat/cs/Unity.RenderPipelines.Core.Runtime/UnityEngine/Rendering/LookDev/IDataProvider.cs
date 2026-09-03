/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.LookDev
{
	[Obsolete("IDataProvider is deprecated", false)]
	public interface IDataProvider // TypeDefIndex: 6012
	{
		// Properties
		IEnumerable<string> supportedDebugModes { get; }
	
		// Methods
		void FirstInitScene(StageRuntimeInterface stage);
		void UpdateSky(Camera camera, Sky sky, StageRuntimeInterface stage);
		void UpdateDebugMode(int debugIndex);
		void GetShadowMask(ref RenderTexture output, StageRuntimeInterface stage);
		void OnBeginRendering(StageRuntimeInterface stage);
		void OnEndRendering(StageRuntimeInterface stage);
		void Cleanup(StageRuntimeInterface SRI);
	}
}
