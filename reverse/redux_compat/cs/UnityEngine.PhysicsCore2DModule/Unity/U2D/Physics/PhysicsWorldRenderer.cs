/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	internal static class PhysicsWorldRenderer // TypeDefIndex: 14704
	{
		// Fields
		private static readonly string s_RenderCommandBufferName; // 0x00
		[NoAutoStaticsCleanup]
		private static bool s_IsInitialized; // 0x08
		[NoAutoStaticsCleanup]
		private static bool s_UsingBIRP; // 0x09
		[NoAutoStaticsCleanup]
		private static CommandBuffer s_RendererCommandBuffer; // 0x10
		[NoAutoStaticsCleanup]
		private static DrawerGroup[] s_DrawerGroups; // 0x18
		[NoAutoStaticsCleanup]
		private static Mesh s_RenderMesh; // 0x20
		private static readonly int s_ElementBufferShaderProperty; // 0x28
		private static readonly int s_TransformPlaneShaderProperty; // 0x2C
		private static readonly int s_TransformPlaneMatrixShaderProperty; // 0x30
		private static readonly int s_ThicknessShaderProperty; // 0x34
		private static readonly int s_FillAlphaShaderProperty; // 0x38
		private static readonly ProfilerMarker s_DrawWorldsMarker; // 0x40
		private static readonly ProfilerMarker s_DrawWorldsExecuteRenderCommandsBIRPMarker; // 0x48
		private static readonly ProfilerMarker s_DrawWorldsExecuteRenderCommandsSRPMarker; // 0x50
		private static readonly ProfilerMarker s_DrawWorldsAddRenderCommandsMarker; // 0x58
		private static readonly ProfilerMarker s_DrawWorldsWorldDrawEventMarker; // 0x60
		private static readonly ProfilerMarker s_DrawWorldsPolygonCommandMarker; // 0x68
		private static readonly ProfilerMarker s_DrawWorldsCircleCommandMarker; // 0x70
		private static readonly ProfilerMarker s_DrawWorldsCapsuleCommandMarker; // 0x78
		private static readonly ProfilerMarker s_DrawWorldsLineCommandMarker; // 0x80
		private static readonly ProfilerMarker s_DrawWorldsPointCommandMarker; // 0x88
	
		// Nested types
		private sealed class DrawerGroup : IDisposable // TypeDefIndex: 14705
		{
			// Fields
			private BaseDrawer[] m_Drawers; // 0x10
	
			// Properties
			public bool isValid { get; } // 0x00000001814B9A50-0x00000001814B9A60 
	
			// Nested types
			private abstract class BaseDrawer : IDisposable // TypeDefIndex: 14706
			{
				// Fields
				private bool m_Disposed; // 0x10
				protected GraphicsBuffer m_GraphicsBuffer; // 0x18
				protected GraphicsBuffer.IndirectDrawIndexedArgs[] m_CommandData; // 0x20
				protected ComputeBuffer m_ElementBuffer; // 0x28
				protected Material m_ShaderMaterial; // 0x30
				protected MaterialPropertyBlock m_ShaderMaterialPropertyBlock; // 0x38
	
				// Constructors
				protected BaseDrawer(); // 0x00000001822C3A50-0x00000001822C3B00
	
				// Methods
				public void Dispose(); // 0x00000001822C3960-0x00000001822C3A50
				public abstract void Draw(CommandBuffer rendererCommandBuffer, ref PhysicsWorld.DrawResults drawResults, float thickness, float fillAlpha, PhysicsWorld.TransformPlane transformPlane, ref Matrix4x4 transformPlaneCustomMatrix);
			}
	
			private sealed class PolygonGeometryDrawer : BaseDrawer // TypeDefIndex: 14707
			{
				// Constructors
				public PolygonGeometryDrawer(); // 0x00000001822D0AE0-0x00000001822D0B90
	
				// Methods
				public override void Draw(CommandBuffer rendererCommandBuffer, ref PhysicsWorld.DrawResults drawResults, float thickness, float fillAlpha, PhysicsWorld.TransformPlane transformPlane, ref Matrix4x4 transformPlaneCustomMatrix); // 0x00000001822D06D0-0x00000001822D0AE0
			}
	
			private sealed class CircleGeometryDrawer : BaseDrawer // TypeDefIndex: 14708
			{
				// Constructors
				public CircleGeometryDrawer(); // 0x00000001822C45C0-0x00000001822C4670
	
				// Methods
				public override void Draw(CommandBuffer rendererCommandBuffer, ref PhysicsWorld.DrawResults drawResults, float thickness, float fillAlpha, PhysicsWorld.TransformPlane transformPlane, ref Matrix4x4 transformPlaneCustomMatrix); // 0x00000001822C41B0-0x00000001822C45C0
			}
	
			private sealed class CapsuleGeometryDrawer : BaseDrawer // TypeDefIndex: 14709
			{
				// Constructors
				public CapsuleGeometryDrawer(); // 0x00000001822C4100-0x00000001822C41B0
	
				// Methods
				public override void Draw(CommandBuffer rendererCommandBuffer, ref PhysicsWorld.DrawResults drawResults, float thickness, float fillAlpha, PhysicsWorld.TransformPlane transformPlane, ref Matrix4x4 transformPlaneCustomMatrix); // 0x00000001822C3CF0-0x00000001822C4100
			}
	
			private sealed class LineDrawer : BaseDrawer // TypeDefIndex: 14710
			{
				// Constructors
				public LineDrawer(); // 0x00000001822C6400-0x00000001822C64B0
	
				// Methods
				public override void Draw(CommandBuffer rendererCommandBuffer, ref PhysicsWorld.DrawResults drawResults, float thickness, float fillAlpha, PhysicsWorld.TransformPlane transformPlane, ref Matrix4x4 transformPlaneCustomMatrix); // 0x00000001822C6020-0x00000001822C6400
			}
	
			private sealed class PointDrawer : BaseDrawer // TypeDefIndex: 14711
			{
				// Constructors
				public PointDrawer(); // 0x00000001822D0620-0x00000001822D06D0
	
				// Methods
				public override void Draw(CommandBuffer rendererCommandBuffer, ref PhysicsWorld.DrawResults drawResults, float thickness, float fillAlpha, PhysicsWorld.TransformPlane transformPlane, ref Matrix4x4 transformPlaneCustomMatrix); // 0x00000001822D0280-0x00000001822D0620
			}
	
			// Constructors
			public DrawerGroup(); // 0x00000001822C56A0-0x00000001822C5BD0
	
			// Methods
			public void Draw(CommandBuffer rendererCommandBuffer, ref PhysicsWorld.DrawResults drawResults, float thickness, float fillAlpha, PhysicsWorld.TransformPlane transformPlane, ref Matrix4x4 transformPlaneCustomMatrix); // 0x00000001822C55B0-0x00000001822C56A0
			public void Dispose(); // 0x00000001822C5430-0x00000001822C55B0
		}
	
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 14712
		{
			// Fields
			public static Camera.CameraCallback _0___RenderWorlds_BIRP; // 0x00
			public static Action<ScriptableRenderContext, List<Camera>> _1___RenderWorlds_SRP; // 0x08
		}
	
		// Constructors
		static PhysicsWorldRenderer(); // 0x00000001822CEDD0-0x00000001822CF210
	
		// Methods
		[RequiredByNativeCode]
		private static void InitializeRendering(); // 0x00000001822CDC10-0x00000001822CDF10
		[RequiredByNativeCode]
		private static void ShutdownRendering(); // 0x00000001822CE9E0-0x00000001822CEDD0
		private static Mesh GetMesh(); // 0x00000001822CD810-0x00000001822CDC10
		private static PhysicsAABB GetCameraViewAABB(Camera camera); // 0x00000001822C3090-0x00000001822C37D0
		private static bool IsCameraTypeValid(Camera camera); // 0x00000001822CDF10-0x00000001822CDF30
		private static PhysicsWorld.DrawTarget GetCameraDrawTarget(Camera camera); // 0x00000001822CD7E0-0x00000001822CD810
		private static void RenderWorlds_BIRP(Camera camera); // 0x00000001822CDF30-0x00000001822CE210
		private static void RenderWorlds_SRP(ScriptableRenderContext context, List<Camera> cameras); // 0x00000001822CE210-0x00000001822CE530
		[RequiredByNativeCode]
		private static void SendDrawResults(bool isRenderingAllowed, bool alwaysDrawWorlds, PhysicsWorld physicsWorld, ref PhysicsWorld.DrawResults drawResults, PhysicsWorld.TransformPlane transformPlane, ref Matrix4x4 transformPlaneCustomMatrix, float thickness, float fillAlpha); // 0x00000001822CE530-0x00000001822CE9E0
	}
}
