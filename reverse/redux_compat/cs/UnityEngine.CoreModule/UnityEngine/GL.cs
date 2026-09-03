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
	[NativeHeader("Runtime/Camera/CameraUtil.h")]
	[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
	[NativeHeader("Runtime/GfxDevice/GfxDevice.h")]
	[NativeHeader("Runtime/Camera/Camera.h")]
	[StaticAccessor("GetGfxDevice()", StaticAccessorType.Dot)]
	public sealed class GL // TypeDefIndex: 7549
	{
		// Properties
		public static bool wireframe { get; } // 0x000000018219E540-0x000000018219E570 
		[NativeProperty("UserBackfaceMode")]
		public static bool invertCulling { get; set; } // 0x000000018219E510-0x000000018219E540 0x000000018219E570-0x000000018219E5B0
		public static Matrix4x4 modelview { set; } // 0x000000018219E5B0-0x000000018219E610
	
		// Methods
		[NativeName("ImmediateVertex")]
		public static void Vertex3(float x, float y, float z); // 0x000000018219E3F0-0x000000018219E450
		public static void Vertex(Vector3 v); // 0x000000018219E450-0x000000018219E490
		[NativeName("ImmediateTexCoordAll")]
		public static void TexCoord3(float x, float y, float z); // 0x000000018219E390-0x000000018219E3F0
		public static void TexCoord2(float x, float y); // 0x000000018219E340-0x000000018219E390
		[NativeName("ImmediateTexCoord")]
		public static void MultiTexCoord3(int unit, float x, float y, float z); // 0x000000018219E1F0-0x000000018219E260
		public static void MultiTexCoord2(int unit, float x, float y); // 0x000000018219E190-0x000000018219E1F0
		[NativeName("ImmediateColor")]
		private static void ImmediateColor(float r, float g, float b, float a); // 0x000000018219E060-0x000000018219E0E0
		public static void Color(Color c); // 0x000000018219DD80-0x000000018219DDD0
		public static void Flush(); // 0x000000018219DE00-0x000000018219DE30
		private static void SetViewMatrix(Matrix4x4 m); // 0x000000018219E300-0x000000018219E340
		[FreeFunction("GLPushMatrixScript")]
		public static void PushMatrix(); // 0x000000018219E290-0x000000018219E2C0
		[FreeFunction("GLPopMatrixScript")]
		public static void PopMatrix(); // 0x000000018219E260-0x000000018219E290
		[FreeFunction("GLLoadPixelMatrixScript")]
		public static void LoadPixelMatrix(); // 0x000000018219E0E0-0x000000018219E110
		[FreeFunction("GLLoadProjectionMatrixScript")]
		public static void LoadProjectionMatrix(Matrix4x4 mat); // 0x000000018219E150-0x000000018219E190
		[FreeFunction("GLGetGPUProjectionMatrix")]
		public static Matrix4x4 GetGPUProjectionMatrix(Matrix4x4 proj, bool renderIntoTexture); // 0x000000018219DFF0-0x000000018219E060
		[FreeFunction]
		private static void GLLoadPixelMatrixScript(float left, float right, float bottom, float top); // 0x000000018219DF10-0x000000018219DF90
		public static void LoadPixelMatrix(float left, float right, float bottom, float top); // 0x000000018219DF10-0x000000018219DF90
		[FreeFunction("GLBegin", ThrowsException = true)]
		public static void Begin(int mode); // 0x000000018219DC70-0x000000018219DCB0
		[FreeFunction("GLEnd")]
		public static void End(); // 0x000000018219DDD0-0x000000018219DE00
		[FreeFunction]
		private static void GLClear(bool clearDepth, bool clearColor, Color backgroundColor, float depth); // 0x000000018219DEA0-0x000000018219DF10
		public static void Clear(bool clearDepth, bool clearColor, Color backgroundColor, [DefaultValue("1.0f")] float depth); // 0x000000018219DCB0-0x000000018219DD20
		public static void Clear(bool clearDepth, bool clearColor, Color backgroundColor); // 0x000000018219DD20-0x000000018219DD80
		[FreeFunction("SetGLViewport")]
		public static void Viewport(Rect pixelRect); // 0x000000018219E4D0-0x000000018219E510
		private static void SetViewMatrix_Injected(in Matrix4x4 m); // 0x000000018219E2C0-0x000000018219E300
		private static void LoadProjectionMatrix_Injected(in Matrix4x4 mat); // 0x000000018219E110-0x000000018219E150
		private static void GetGPUProjectionMatrix_Injected(in Matrix4x4 proj, bool renderIntoTexture, ); // 0x000000018219DF90-0x000000018219DFF0
		private static void GLClear_Injected(bool clearDepth, bool clearColor, in Color backgroundColor, float depth); // 0x000000018219DE30-0x000000018219DEA0
		private static void Viewport_Injected(in Rect pixelRect); // 0x000000018219E490-0x000000018219E4D0
	}
}
