/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[DebuggerDisplay("BufferResource ({desc.name})")]
	internal class BufferResource : RenderGraphResource<BufferDesc, GraphicsBuffer> // TypeDefIndex: 5945
	{
		// Constructors
		public BufferResource(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
		// Methods
		public override string GetName(); // 0x0000000181ED7FA0-0x0000000181ED7FF0
		public override int GetDescHashCode(); // 0x0000000181ED7F60-0x0000000181ED7FA0
		public override void CreateGraphicsResource(); // 0x0000000181ED7EA0-0x0000000181ED7F60
		public override void UpdateGraphicsResource(); // 0x0000000181ED8020-0x0000000181ED8070
		public override void ReleaseGraphicsResource(); // 0x0000000181ED7FF0-0x0000000181ED8020
	}
}
