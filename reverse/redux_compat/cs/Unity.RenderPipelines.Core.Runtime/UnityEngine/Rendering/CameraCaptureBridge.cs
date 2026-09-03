/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public static class CameraCaptureBridge // TypeDefIndex: 5743
	{
		// Fields
		private static readonly Dictionary<Camera, CameraEntry> actionDict; // 0x00
		private static bool _enabled; // 0x08
	
		// Properties
		public static bool enabled { get; set; } // 0x0000000181EAB9D0-0x0000000181EABA20 0x0000000181EABA20-0x0000000181EABA80
	
		// Nested types
		private class CameraEntry // TypeDefIndex: 5744
		{
			// Fields
			internal HashSet<Action<RenderTargetIdentifier, CommandBuffer>> actions; // 0x10
			internal IEnumerator<Action<RenderTargetIdentifier, CommandBuffer>> cachedEnumerator; // 0x18
	
			// Constructors
			public CameraEntry(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		static CameraCaptureBridge(); // 0x0000000181EAB940-0x0000000181EAB9D0
	
		// Methods
		public static IEnumerator<Action<RenderTargetIdentifier, CommandBuffer>> GetCaptureActions(Camera camera); // 0x0000000181EAB6C0-0x0000000181EAB7C0
		internal static IEnumerator<Action<RenderTargetIdentifier, CommandBuffer>> GetCachedCaptureActionsEnumerator(Camera camera); // 0x0000000181EAB5D0-0x0000000181EAB6C0
		public static void AddCaptureAction(Camera camera, Action<RenderTargetIdentifier, CommandBuffer> action); // 0x0000000181EAB3C0-0x0000000181EAB5D0
		public static void RemoveCaptureAction(Camera camera, Action<RenderTargetIdentifier, CommandBuffer> action); // 0x0000000181EAB7C0-0x0000000181EAB940
	}
}
