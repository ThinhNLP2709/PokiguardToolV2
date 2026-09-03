/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.Scripting;
using UnityEngine.Serialization;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	[Serializable]
	[RequiredByNativeCode]
	public sealed class PhysicsCoreSettings2D : ScriptableObject // TypeDefIndex: 14661
	{
		// Fields
		[SerializeField]
		internal bool m_UsePhysicsLayers; // 0x18
		[SerializeField]
		internal PhysicsLayers.LayerNames m_PhysicsLayerNames; // 0x20
		[SerializeField]
		internal PhysicsWorldDefinition m_PhysicsWorldDefinition; // 0x28
		[SerializeField]
		internal PhysicsBodyDefinition m_PhysicsBodyDefinition; // 0x428
		[SerializeField]
		internal PhysicsShapeDefinition m_PhysicsShapeDefinition; // 0x470
		[SerializeField]
		internal PhysicsChainDefinition m_PhysicsChainDefinition; // 0x4C0
		[SerializeField]
		internal PhysicsDistanceJointDefinition m_PhysicsDistanceJointDefinition; // 0x500
		[SerializeField]
		internal PhysicsFixedJointDefinition m_PhysicsFixedJointDefinition; // 0x57C
		[SerializeField]
		internal PhysicsHingeJointDefinition m_PhysicsHingeJointDefinition; // 0x5D8
		[SerializeField]
		internal PhysicsRelativeJointDefinition m_PhysicsRelativeJointDefinition; // 0x648
		[SerializeField]
		internal PhysicsSliderJointDefinition m_PhysicsSliderJointDefinition; // 0x6C0
		[SerializeField]
		internal PhysicsWheelJointDefinition m_PhysicsWheelJointDefinition; // 0x730
		[SerializeField]
		internal PhysicsWorld.TransformChangeMode m_TransformChangeMode; // 0x79C
		[SerializeField]
		internal PhysicsShape.ContactFilterMode m_ContactFilterMode; // 0x7A0
		[SerializeField]
		internal PhysicsShape.ContactFilterGroupMode m_ContactFilterGroupMode; // 0x7A4
		[FormerlySerializedAs("m_MaximumWorlds")]
		[Range(1f, 1024f)]
		[SerializeField]
		internal int m_InitialWorldCapacity; // 0x7A8
		[Range(1f, 64f)]
		[SerializeField]
		internal int m_ConcurrentSimulations; // 0x7AC
		[Range(1E-05f, 10000f)]
		[SerializeField]
		internal float m_LengthUnitsPerMeter; // 0x7B0
		[SerializeField]
		internal PhysicsWorld.RenderingMode m_RenderingMode; // 0x7B4
		[SerializeField]
		internal bool m_DisableSimulation; // 0x7B8
		[SerializeField]
		internal bool m_AlwaysDrawWorlds; // 0x7B9
	
		// Properties
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ExcludeFromDocs]
		[Obsolete("PhysicsCoreSettings2D.maximumWorlds is deprecated, please use PhysicsCoreSettings2D.initialWorldCapacity instead. (UnityUpgradable) -> initialWorldCapacity", false)]
		public int maximumWorlds { get; set; } // 0x00000001822C6C00-0x00000001822C6C10 0x00000001822C7BD0-0x00000001822C7C00
		public PhysicsLayers.LayerNames physicsLayerNames { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public bool usePhysicsLayers { get; set; } // 0x0000000180F9E350-0x0000000180F9E360 0x00000001804C2E10-0x00000001804C2E20
		public PhysicsWorldDefinition physicsWorldDefinition { get; set; } // 0x00000001822C7AF0-0x00000001822C7B60 0x00000001822C7EF0-0x00000001822C7F60
		public PhysicsBodyDefinition physicsBodyDefinition { get; set; } // 0x00000001822C7820-0x00000001822C7860 0x00000001822C7C20-0x00000001822C7C60
		public PhysicsShapeDefinition physicsShapeDefinition { get; set; } // 0x00000001822C7A00-0x00000001822C7A40 0x00000001822C7E00-0x00000001822C7E40
		public PhysicsChainDefinition physicsChainDefinition { get; set; } // 0x00000001822C7860-0x00000001822C7890 0x00000001822C7C60-0x00000001822C7C90
		public PhysicsDistanceJointDefinition physicsDistanceJointDefinition { get; set; } // 0x00000001822C7890-0x00000001822C7900 0x00000001822C7C90-0x00000001822C7D00
		public PhysicsFixedJointDefinition physicsFixedJointDefinition { get; set; } // 0x00000001822C7900-0x00000001822C7950 0x00000001822C7D00-0x00000001822C7D50
		public PhysicsHingeJointDefinition physicsHingeJointDefinition { get; set; } // 0x00000001822C7950-0x00000001822C79A0 0x00000001822C7D50-0x00000001822C7DA0
		public PhysicsRelativeJointDefinition physicsRelativeJointDefinition { get; set; } // 0x00000001822C79A0-0x00000001822C7A00 0x00000001822C7DA0-0x00000001822C7E00
		public PhysicsSliderJointDefinition physicsSliderJointDefinition { get; set; } // 0x00000001822C7A40-0x00000001822C7A90 0x00000001822C7E40-0x00000001822C7E90
		public PhysicsWheelJointDefinition physicsWheelJointDefinition { get; set; } // 0x00000001822C7A90-0x00000001822C7AF0 0x00000001822C7E90-0x00000001822C7EF0
		public PhysicsWorld.TransformChangeMode transformChangeMode { get; set; } // 0x00000001822C7060-0x00000001822C7070 0x00000001822C7F70-0x00000001822C7F80
		public PhysicsShape.ContactFilterMode contactFilterMode { get; set; } // 0x00000001822C6BE0-0x00000001822C6BF0 0x00000001822C7BB0-0x00000001822C7BC0
		public PhysicsShape.ContactFilterGroupMode contactFilterGroupMode { get; set; } // 0x00000001822C6BD0-0x00000001822C6BE0 0x00000001822C7BA0-0x00000001822C7BB0
		public int initialWorldCapacity { get; set; } // 0x00000001822C6C00-0x00000001822C6C10 0x00000001822C7BD0-0x00000001822C7C00
		[Range(1f, 64f)]
		public int concurrentSimulations { get; set; } // 0x00000001822C6BC0-0x00000001822C6BD0 0x00000001822C7B70-0x00000001822C7BA0
		public float lengthUnitsPerMeter { get; set; } // 0x00000001822C6C10-0x00000001822C6C20 0x00000001822C7C00-0x00000001822C7C20
		public PhysicsWorld.RenderingMode renderingMode { get; set; } // 0x00000001822C7050-0x00000001822C7060 0x00000001822C7F60-0x00000001822C7F70
		public bool disableSimulation { get; set; } // 0x00000001822C6BF0-0x00000001822C6C00 0x00000001822C7BC0-0x00000001822C7BD0
		public bool alwaysDrawWorlds { get; set; } // 0x00000001822C6BB0-0x00000001822C6BC0 0x00000001822C7B60-0x00000001822C7B70
	
		// Constructors
		public PhysicsCoreSettings2D(); // 0x00000001822C7800-0x00000001822C7820
	
		// Methods
		private void Reset(); // 0x00000001822C7070-0x00000001822C7800
		[RequiredByNativeCode]
		private void GetPhysicsLayerNames(out PhysicsLayers.LayerNames layerNames); // 0x00000001822C6DC0-0x00000001822C6DE0
		[RequiredByNativeCode]
		private void GetPhysicsWorldDefinition(out PhysicsWorldDefinition definition); // 0x00000001822C6F70-0x00000001822C7050
		[RequiredByNativeCode]
		private void GetPhysicsBodyDefinition(out PhysicsBodyDefinition definition); // 0x00000001822C6C20-0x00000001822C6C60
		[RequiredByNativeCode]
		private void GetPhysicsShapeDefinition(out PhysicsShapeDefinition definition); // 0x00000001822C6E60-0x00000001822C6EA0
		[RequiredByNativeCode]
		private void GetPhysicsChainDefinition(out PhysicsChainDefinition definition); // 0x00000001822C6C60-0x00000001822C6C90
		[RequiredByNativeCode]
		private void GetPhysicsDistanceJointDefinition(out PhysicsDistanceJointDefinition definition); // 0x00000001822C6C90-0x00000001822C6D10
		[RequiredByNativeCode]
		private void GetPhysicsFixedJointDefinition(out PhysicsFixedJointDefinition definition); // 0x00000001822C6D10-0x00000001822C6D60
		[RequiredByNativeCode]
		private void GetPhysicsHingeJointDefinition(out PhysicsHingeJointDefinition definition); // 0x00000001822C6D60-0x00000001822C6DC0
		[RequiredByNativeCode]
		private void GetPhysicsRelativeJointDefinition(out PhysicsRelativeJointDefinition definition); // 0x00000001822C6DE0-0x00000001822C6E60
		[RequiredByNativeCode]
		private void GetPhysicsSliderJointDefinition(out PhysicsSliderJointDefinition definition); // 0x00000001822C6EA0-0x00000001822C6F00
		[RequiredByNativeCode]
		private void GetPhysicsWheelJointDefinition(out PhysicsWheelJointDefinition definition); // 0x00000001822C6F00-0x00000001822C6F70
		[RequiredByNativeCode]
		private PhysicsWorld.TransformChangeMode GetTransformChangeMode(); // 0x00000001822C7060-0x00000001822C7070
		[RequiredByNativeCode]
		private PhysicsShape.ContactFilterMode GetContactFilterMode(); // 0x00000001822C6BE0-0x00000001822C6BF0
		[RequiredByNativeCode]
		private PhysicsShape.ContactFilterGroupMode GetContactFilterGroupMode(); // 0x00000001822C6BD0-0x00000001822C6BE0
		[RequiredByNativeCode]
		private int GetInitialWorldCapacity(); // 0x00000001822C6C00-0x00000001822C6C10
		[RequiredByNativeCode]
		private int GetConcurrentSimulations(); // 0x00000001822C6BC0-0x00000001822C6BD0
		[RequiredByNativeCode]
		private float GetLengthUnitsPerMeter(); // 0x00000001822C6C10-0x00000001822C6C20
		[RequiredByNativeCode]
		private PhysicsWorld.RenderingMode GetRenderingMode(); // 0x00000001822C7050-0x00000001822C7060
		[RequiredByNativeCode]
		private bool GetDisableSimulation(); // 0x00000001822C6BF0-0x00000001822C6C00
		[RequiredByNativeCode]
		private bool GetAlwaysDrawWorlds(); // 0x00000001822C6BB0-0x00000001822C6BC0
		[RequiredByNativeCode]
		private bool GetUsePhysicsLayers(); // 0x0000000180F9E350-0x0000000180F9E360
	}
}
