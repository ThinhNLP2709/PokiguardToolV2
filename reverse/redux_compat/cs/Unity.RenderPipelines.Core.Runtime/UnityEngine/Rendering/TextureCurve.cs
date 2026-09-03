/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	public class TextureCurve : IDisposable // TypeDefIndex: 5791
	{
		// Fields
		private const int k_Precision = 128; // Metadata: 0x00661B13
		private const float k_Step = 0.0078125f; // Metadata: 0x00661B15
		[CompilerGenerated]
		[SerializeField]
		private int _length_k__BackingField; // 0x10
		[SerializeField]
		private bool m_Loop; // 0x14
		[SerializeField]
		private float m_ZeroValue; // 0x18
		[SerializeField]
		private float m_Range; // 0x1C
		[SerializeField]
		private AnimationCurve m_Curve; // 0x20
		private AnimationCurve m_LoopingCurve; // 0x28
		private Texture2D m_Texture; // 0x30
		private bool m_IsCurveDirty; // 0x38
		private bool m_IsTextureDirty; // 0x39
	
		// Properties
		public int length { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public Keyframe this[int index] { get => default; } // 0x0000000181ECD2B0-0x0000000181ECD300 
	
		// Constructors
		public TextureCurve(AnimationCurve baseCurve, float zeroValue, bool loop, [IsReadOnly] in Vector2 bounds); // 0x0000000181ECD040-0x0000000181ECD180
		public TextureCurve(Keyframe[] keys, float zeroValue, bool loop, [IsReadOnly] in Vector2 bounds); // 0x0000000181ECD180-0x0000000181ECD2B0
	
		// Methods
		public void Dispose(); // 0x0000000181ECC9D0-0x0000000181ECC9E0
		public void Release(); // 0x0000000181ECCF30-0x0000000181ECCFD0
		public void SetDirty(); // 0x0000000181ECD000-0x0000000181ECD010
		private static GraphicsFormat GetTextureFormat(); // 0x0000000181ECCC30-0x0000000181ECCC90
		public Texture2D GetTexture(); // 0x0000000181ECCC90-0x0000000181ECCEE0
		public float Evaluate(float time); // 0x0000000181ECC9E0-0x0000000181ECCC30
		public int AddKey(float time, float value); // 0x0000000181ECC990-0x0000000181ECC9D0
		public int MoveKey(int index, [IsReadOnly] in Keyframe key); // 0x0000000181ECCEE0-0x0000000181ECCF30
		public void RemoveKey(int index); // 0x0000000181ECCFD0-0x0000000181ECD000
		public void SmoothTangents(int index, float weight); // 0x0000000181ECD010-0x0000000181ECD040
	}
}
