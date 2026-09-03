/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[AddComponentMenu("Rendering/Probe Adjustment Volume")]
	[ExecuteAlways]
	public class ProbeAdjustmentVolume : MonoBehaviour, ISerializationCallbackReceiver // TypeDefIndex: 5540
	{
		// Fields
		[Tooltip("Select the shape used for this Probe Adjustment Volume.")]
		public Shape shape; // 0x20
		[Min(0f)]
		[Tooltip("Modify the size of this Probe Adjustment Volume. This is unaffected by the GameObject\'s Transform\'s Scale property.")]
		public Vector3 size; // 0x24
		[Min(0f)]
		[Tooltip("Modify the radius of this Probe Adjustment Volume. This is unaffected by the GameObject\'s Transform\'s Scale property.")]
		public float radius; // 0x30
		public Mode mode; // 0x34
		[Range(0.0001f, 2f)]
		[Tooltip("A multiplier applied to the intensity of probes covered by this Probe Adjustment Volume.")]
		public float intensityScale; // 0x38
		[Range(0f, 0.95f)]
		public float overriddenDilationThreshold; // 0x3C
		public Vector3 virtualOffsetRotation; // 0x40
		[Min(0f)]
		public float virtualOffsetDistance; // 0x4C
		[Range(0f, 1f)]
		[Tooltip("Determines how far Unity pushes a probe out of geometry after a ray hit.")]
		public float geometryBias; // 0x50
		[Range(0f, 0.95f)]
		public float virtualOffsetThreshold; // 0x54
		[Range(-0.05f, 0f)]
		[Tooltip("Distance from the probe position used to determine the origin of the sampling ray.")]
		public float rayOriginBias; // 0x58
		[Tooltip("The direction for sampling the ambient probe in worldspace when using the Sky Visibility feature.")]
		public Vector3 skyDirection; // 0x5C
		internal Vector3 skyShadingDirectionRotation; // 0x68
		[Logarithmic(1, 1024)]
		[Tooltip("Number of samples for direct lighting computations.")]
		public int directSampleCount; // 0x74
		[Logarithmic(1, 8192)]
		[Tooltip("Number of samples for indirect lighting computations. This includes environment samples.")]
		public int indirectSampleCount; // 0x78
		[Min(0f)]
		[Tooltip("Multiplier for the number of samples specified above.")]
		public int sampleCountMultiplier; // 0x7C
		[Min(0f)]
		[Tooltip("Maximum number of bounces for indirect lighting.")]
		public int maxBounces; // 0x80
		[Logarithmic(1, 8192)]
		public int skyOcclusionSampleCount; // 0x84
		[Range(0f, 5f)]
		public int skyOcclusionMaxBounces; // 0x88
		public RenderingLayerMaskOperation renderingLayerMaskOperation; // 0x8C
		public byte renderingLayerMask; // 0x90
		[SerializeField]
		private Version version; // 0x94
		[Obsolete("This field is only kept for migration purpose. Use mode instead. #from(2023.1)")]
		public bool invalidateProbes; // 0x98
		[Obsolete("This field is only kept for migration purpose. Use mode instead. #from(2023.1)")]
		public bool overrideDilationThreshold; // 0x99
	
		// Nested types
		public enum Shape // TypeDefIndex: 5541
		{
			Box = 0,
			Sphere = 1
		}
	
		public enum Mode // TypeDefIndex: 5542
		{
			InvalidateProbes = 0,
			OverrideValidityThreshold = 1,
			ApplyVirtualOffset = 2,
			OverrideVirtualOffsetSettings = 3,
			OverrideSkyDirection = 4,
			OverrideSampleCount = 5,
			OverrideRenderingLayerMask = 6,
			IntensityScale = 99
		}
	
		public enum RenderingLayerMaskOperation // TypeDefIndex: 5543
		{
			Override = 0,
			Add = 1,
			Remove = 2
		}
	
		private enum Version // TypeDefIndex: 5544
		{
			Initial = 0,
			Mode = 1,
			Count = 2
		}
	
		// Constructors
		public ProbeAdjustmentVolume(); // 0x0000000181E540F0-0x0000000181E541F0
	
		// Methods
		void ISerializationCallbackReceiver.OnBeforeSerialize(); // 0x0000000181E540D0-0x0000000181E540F0
		void ISerializationCallbackReceiver.OnAfterDeserialize(); // 0x0000000181E54080-0x0000000181E540D0
	}
}
