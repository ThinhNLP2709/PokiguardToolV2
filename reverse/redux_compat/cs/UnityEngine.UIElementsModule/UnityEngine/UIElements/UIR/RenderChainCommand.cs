/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class RenderChainCommand : LinkedPoolItem<RenderChainCommand> // TypeDefIndex: 5047
	{
		// Fields
		public RenderData owner; // 0x18
		public RenderChainCommand prev; // 0x20
		public RenderChainCommand next; // 0x28
		public CommandType type; // 0x30
		public CommandFlags flags; // 0x34
		public Material material; // 0x38
		public MaterialPropertyBlock userProps; // 0x40
		public TextureId texture; // 0x48
		public int stencilRef; // 0x4C
		public float sdfScale; // 0x50
		public float sharpness; // 0x54
		public MeshHandle mesh; // 0x58
		public int indexOffset; // 0x60
		public int indexCount; // 0x64
		public Action callback; // 0x68
		public EntityId panelComponentId; // 0x70
		private static readonly ProfilerMarker s_ImmediateOverheadMarker; // 0x00
	
		// Constructors
		public RenderChainCommand(); // 0x000000018241E4F0-0x000000018241E5E0
		static RenderChainCommand(); // 0x000000018241E480-0x000000018241E4F0
	
		// Methods
		public void Reset(); // 0x000000018241E390-0x000000018241E480
		public void ExecuteNonDrawMesh(DrawParams drawParams, float pixelsPerPoint, ref Exception immediateException); // 0x000000018241CD90-0x000000018241DB70
		public static void PushScissor(DrawParams drawParams, Rect scissor, float pixelsPerPoint); // 0x000000018241DDA0-0x000000018241E0C0
		public static void PopScissor(DrawParams drawParams, float pixelsPerPoint); // 0x000000018241DB70-0x000000018241DDA0
		private static Rect CombineScissorRects(Rect r0, Rect r1); // 0x000000018241CC60-0x000000018241CD90
		internal static RectInt RectPointsToPixelsAndFlipYAxis(Rect rect, Vector2 boundsMin, float pixelsPerPoint); // 0x000000018241E0C0-0x000000018241E270
		internal static RectInt RectPointsToPixels(Rect rect, Vector2 origin, float scaleX, float scaleY, RectInt viewport); // 0x000000018241E270-0x000000018241E390
	}
}
