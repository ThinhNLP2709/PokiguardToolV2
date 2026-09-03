/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Sampling;
using UnityEngine.Rendering.UnifiedRayTracing;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal interface IManyLightSampling : IDisposable // TypeDefIndex: 13580
	{
		// Methods
		void Build(CommandBuffer cmd, World.LightState lightState, Bounds sceneBounds, SamplingResources samplingResources);
		void Bind(CommandBuffer cmd, IRayTracingShader shader);
	}
}
