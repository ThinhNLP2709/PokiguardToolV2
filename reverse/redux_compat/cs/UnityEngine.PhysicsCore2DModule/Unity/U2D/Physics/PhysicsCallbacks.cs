/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	[IsReadOnly]
	[MovedFrom(true, "UnityEngine.LowLevelPhysics2D", "UnityEngine.Physics2DModule", null)]
	public struct PhysicsCallbacks // TypeDefIndex: 14677
	{
		// Nested types
		public interface IBodyUpdateCallback // TypeDefIndex: 14678
		{
			// Methods
			void OnBodyUpdate2D(PhysicsEvents.BodyUpdateEvent bodyUpdateEvent);
		}
	
		public interface IContactFilterCallback // TypeDefIndex: 14679
		{
			// Methods
			bool OnContactFilter2D(PhysicsEvents.ContactFilterEvent contactFilterEvent);
		}
	
		public interface IPreSolveCallback // TypeDefIndex: 14680
		{
			// Methods
			bool OnPreSolve2D(PhysicsEvents.PreSolveEvent preSolveEvent);
		}
	
		public interface ITriggerCallback // TypeDefIndex: 14681
		{
			// Methods
			void OnTriggerBegin2D(PhysicsEvents.TriggerBeginEvent beginEvent);
			void OnTriggerEnd2D(PhysicsEvents.TriggerEndEvent endEvent);
		}
	
		public interface IContactCallback // TypeDefIndex: 14682
		{
			// Methods
			void OnContactBegin2D(PhysicsEvents.ContactBeginEvent beginEvent);
			void OnContactEnd2D(PhysicsEvents.ContactEndEvent endEvent);
		}
	
		public interface IJointThresholdCallback // TypeDefIndex: 14683
		{
			// Methods
			void OnJointThreshold2D(PhysicsEvents.JointThresholdEvent thresholdEvent);
		}
	
		public interface ITransformWriteCallback // TypeDefIndex: 14684
		{
			// Methods
			void OnTransformWrite(PhysicsEvents.TransformWriteEvent transformWriteEvent);
			void OnTransformTweenWrite(PhysicsEvents.TransformTweenWriteEvent transformTweenWriteEvent);
		}
	
		public interface ITransformChangedCallback // TypeDefIndex: 14685
		{
			// Methods
			void OnTransformChanged(PhysicsEvents.TransformChangeEvent transformChangeEvent);
		}
	
		[IsReadOnly]
		public struct BodyUpdateCallbackTargets : IDisposable // TypeDefIndex: 14686
		{
			// Fields
			private readonly Scripting2D.PhysicsBuffer m_BodyUpdateCallbackTargets; // 0x00
	
			// Properties
			public ReadOnlySpan<BodyUpdateTarget> bodyUpdateCallbackTargets { get; } // 0x00000001822C3B20-0x00000001822C3B50 
	
			// Nested types
			[IsReadOnly]
			public struct BodyUpdateTarget // TypeDefIndex: 14687
			{
				// Fields
				private readonly PhysicsEvents.BodyUpdateEvent m_BodyUpdateEvent; // 0x00
	
				// Properties
				public PhysicsEvents.BodyUpdateEvent bodyUpdateEvent { get; } // 0x00000001822C3CD0-0x00000001822C3CF0 
				public IBodyUpdateCallback bodyTarget { get; } // 0x00000001822C3C20-0x00000001822C3CD0 
			}
	
			// Methods
			public void Dispose(); // 0x00000001822C3B00-0x00000001822C3B20
		}
	
		[IsReadOnly]
		public struct TriggerCallbackTargets : IDisposable // TypeDefIndex: 14688
		{
			// Fields
			private readonly Scripting2D.PhysicsBuffer m_BeginCallbackTargets; // 0x00
			private readonly Scripting2D.PhysicsBuffer m_EndCallbackTargets; // 0x10
	
			// Properties
			public ReadOnlySpan<TriggerBeginTarget> BeginCallbackTargets { get; } // 0x00000001822C3B20-0x00000001822C3B50 
			public ReadOnlySpan<TriggerEndTarget> EndCallbackTargets { get; } // 0x00000001822C4A40-0x00000001822C4A70 
	
			// Nested types
			[IsReadOnly]
			public struct TriggerBeginTarget // TypeDefIndex: 14689
			{
				// Fields
				private readonly PhysicsEvents.TriggerBeginEvent m_BeginEvent; // 0x00
	
				// Properties
				public PhysicsEvents.TriggerBeginEvent beginEvent { get; } // 0x0000000181D8ABA0-0x0000000181D8ABB0 
				public ITriggerCallback triggerShapeTarget { get; } // 0x00000001822D31D0-0x00000001822D3280 
				public ITriggerCallback visitorShapeTarget { get; } // 0x00000001822D3280-0x00000001822D3330 
			}
	
			[IsReadOnly]
			public struct TriggerEndTarget // TypeDefIndex: 14690
			{
				// Fields
				private readonly PhysicsEvents.TriggerEndEvent m_EndEvent; // 0x00
	
				// Properties
				public PhysicsEvents.TriggerEndEvent endEvent { get; } // 0x0000000181D8ABA0-0x0000000181D8ABB0 
				public ITriggerCallback triggerShapeTarget { get; } // 0x00000001822D33E0-0x00000001822D3490 
				public ITriggerCallback visitorShapeTarget { get; } // 0x00000001822D3490-0x00000001822D3540 
			}
	
			// Methods
			public void Dispose(); // 0x00000001822C49F0-0x00000001822C4A40
		}
	
		[IsReadOnly]
		public struct ContactCallbackTargets : IDisposable // TypeDefIndex: 14691
		{
			// Fields
			private readonly Scripting2D.PhysicsBuffer m_BeginCallbackTargets; // 0x00
			private readonly Scripting2D.PhysicsBuffer m_EndCallbackTargets; // 0x10
	
			// Properties
			public ReadOnlySpan<ContactBeginTarget> BeginCallbackTargets { get; } // 0x00000001822C3B20-0x00000001822C3B50 
			public ReadOnlySpan<ContactEndTarget> EndCallbackTargets { get; } // 0x00000001822C4A40-0x00000001822C4A70 
	
			// Nested types
			[IsReadOnly]
			public struct ContactBeginTarget // TypeDefIndex: 14692
			{
				// Fields
				private readonly PhysicsEvents.ContactBeginEvent m_BeginEvent; // 0x00
	
				// Properties
				public PhysicsEvents.ContactBeginEvent beginEvent { get; } // 0x0000000181325CE0-0x0000000181325D00 
				public IContactCallback shapeTargetA { get; } // 0x00000001822C4890-0x00000001822C4940 
				public IContactCallback shapeTargetB { get; } // 0x00000001822C4940-0x00000001822C49F0 
			}
	
			[IsReadOnly]
			public struct ContactEndTarget // TypeDefIndex: 14693
			{
				// Fields
				private readonly PhysicsEvents.ContactEndEvent m_EndEvent; // 0x00
	
				// Properties
				public PhysicsEvents.ContactEndEvent endEvent { get; } // 0x0000000181325CE0-0x0000000181325D00 
				public IContactCallback shapeTargetA { get; } // 0x00000001822C4C90-0x00000001822C4D40 
				public IContactCallback shapeTargetB { get; } // 0x00000001822C4D40-0x00000001822C4DF0 
			}
	
			// Methods
			public void Dispose(); // 0x00000001822C49F0-0x00000001822C4A40
		}
	
		[IsReadOnly]
		public struct JointThresholdCallbackTargets : IDisposable // TypeDefIndex: 14694
		{
			// Fields
			private readonly Scripting2D.PhysicsBuffer m_JointThresholdCallbackTargets; // 0x00
	
			// Properties
			public ReadOnlySpan<JointThresholdTarget> jointThresholdCallbackTargets { get; } // 0x00000001822C3B20-0x00000001822C3B50 
	
			// Nested types
			[IsReadOnly]
			public struct JointThresholdTarget // TypeDefIndex: 14695
			{
				// Fields
				private readonly PhysicsEvents.JointThresholdEvent m_JointThresholdEvent; // 0x00
	
				// Properties
				public PhysicsEvents.JointThresholdEvent jointThresholdEvent { get; } // 0x000000018092E600-0x000000018092E610 
				public IJointThresholdCallback jointTarget { get; } // 0x00000001822C5C40-0x00000001822C5CF0 
			}
	
			// Methods
			public void Dispose(); // 0x00000001822C3B00-0x00000001822C3B20
		}
	}
}
