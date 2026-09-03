/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Jobs;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal class CpuDeformationSystem : BaseDeformationSystem // TypeDefIndex: 14336
	{
		// Fields
		private const string k_GpuSkinningShaderKeyword = "SKINNED_SPRITE"; // Metadata: 0x006A964D
		private JobHandle m_CopyJobHandle; // 0x130
	
		// Properties
		public override DeformationMethods deformationMethod { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		public CpuDeformationSystem(); // 0x0000000181C1AD20-0x0000000181C1AD30
	
		// Methods
		internal override void Cleanup(); // 0x0000000181C1A4D0-0x0000000181C1A500
		internal override void UpdateMaterial(SpriteSkin spriteSkin); // 0x0000000181C1A500-0x0000000181C1A580
		internal override void Update(); // 0x0000000181C1A580-0x0000000181C1AD20
	}
}
