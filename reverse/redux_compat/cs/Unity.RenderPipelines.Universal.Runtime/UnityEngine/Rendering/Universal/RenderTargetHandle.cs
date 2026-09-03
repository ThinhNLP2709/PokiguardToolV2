/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Obsolete("Deprecated in favor of RTHandle. #from(2022.1) #breakingFrom(2023.1)", true)]
	public struct RenderTargetHandle // TypeDefIndex: 9700
	{
		// Fields
		[CompilerGenerated]
		private int _id_k__BackingField; // 0x00
		[CompilerGenerated]
		private RenderTargetIdentifier _rtid_k__BackingField; // 0x08
		public static readonly RenderTargetHandle CameraTarget; // 0x00
	
		// Properties
		public int id { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		private RenderTargetIdentifier rtid { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181328430-0x0000000181328450 0x0000000181FCCD50-0x0000000181FCCD70
	
		// Constructors
		public RenderTargetHandle(RenderTargetIdentifier renderTargetIdentifier); // 0x0000000181FCC9C0-0x0000000181FCCA30
		public RenderTargetHandle(RTHandle rtHandle); // 0x0000000181FCCA30-0x0000000181FCCC50
		static RenderTargetHandle(); // 0x0000000181FCC960-0x0000000181FCC9C0
	
		// Methods
		internal static RenderTargetHandle GetCameraTarget(ref CameraData cameraData); // 0x0000000181FCC5C0-0x0000000181FCC700
		public void Init(string shaderProperty); // 0x0000000181FCC900-0x0000000181FCC960
		public void Init(RenderTargetIdentifier renderTargetIdentifier); // 0x0000000181FCC890-0x0000000181FCC900
		public RenderTargetIdentifier Identifier(); // 0x0000000181FCC7A0-0x0000000181FCC890
		public bool HasInternalRenderTargetId(); // 0x0000000181FCC750-0x0000000181FCC7A0
		public bool Equals(RenderTargetHandle other); // 0x0000000181FCC3F0-0x0000000181FCC500
		public override bool Equals(object obj); // 0x0000000181FCC500-0x0000000181FCC5C0
		public override int GetHashCode(); // 0x0000000181FCC700-0x0000000181FCC750
		public static bool operator ==(RenderTargetHandle c1, RenderTargetHandle c2); // 0x0000000181FCCC50-0x0000000181FCCCD0
		public static bool operator !=(RenderTargetHandle c1, RenderTargetHandle c2); // 0x0000000181FCCCD0-0x0000000181FCCD50
	}
}
