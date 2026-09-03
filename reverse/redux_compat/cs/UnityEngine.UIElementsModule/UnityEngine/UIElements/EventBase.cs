/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public abstract class EventBase : IDisposable // TypeDefIndex: 3969
	{
		// Fields
		private static long s_LastTypeId; // 0x00
		[CompilerGenerated]
		private readonly int _eventCategories_k__BackingField; // 0x10
		private static ulong s_NextEventId; // 0x08
		[CompilerGenerated]
		private long _timestamp_k__BackingField; // 0x18
		[CompilerGenerated]
		private ulong _eventId_k__BackingField; // 0x20
		[CompilerGenerated]
		private ulong _triggerEventId_k__BackingField; // 0x28
		[CompilerGenerated]
		private EventPropagation _propagation_k__BackingField; // 0x30
		[CompilerGenerated]
		private LifeCycleStatus _lifeCycleStatus_k__BackingField; // 0x34
		[CompilerGenerated]
		private VisualElement _elementTarget_k__BackingField; // 0x38
		[CompilerGenerated]
		private PropagationPhase _propagationPhase_k__BackingField; // 0x40
		private IEventHandler m_CurrentTarget; // 0x48
		private Event m_ImguiEvent; // 0x50
		[CompilerGenerated]
		private Vector2 _originalMousePosition_k__BackingField; // 0x58
	
		// Properties
		public virtual long eventTypeId { get; } // 0x0000000181547E50-0x0000000181547E60 
		internal int eventCategories { [CompilerGenerated] get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public long timestamp { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001804C2E30-0x00000001804C2E40
		internal ulong eventId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181727440-0x0000000181727450
		private ulong triggerEventId { [CompilerGenerated] set; } // 0x0000000181C854D0-0x0000000181C854E0
		internal EventPropagation propagation { [VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })] [CompilerGenerated] get; [CompilerGenerated] [VisibleToOtherModules(new string[2] {"UnityEditor.GraphToolkitModule", "UnityEditor.UIToolkitAuthoringModule" })] set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		private LifeCycleStatus lifeCycleStatus { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780
		public bool bubbles { get; protected set; } // 0x000000018239D610-0x000000018239D620 0x000000018166F6A0-0x000000018166F6C0
		public bool tricklesDown { get; protected set; } // 0x000000018166F660-0x000000018166F670 0x000000018166F680-0x000000018166F6A0
		public bool ignoreDisabledElements { get; protected internal set; } // 0x000000018239D630-0x000000018239D640 0x000000018239D8D0-0x000000018239D8F0
		internal bool bubblesOrTricklesDown { get; } // 0x000000018239D600-0x000000018239D610 
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal VisualElement elementTarget { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		public IEventHandler target { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018239DAA0-0x000000018239DB30
		public bool isPropagationStopped { get; private set; } // 0x0000000181DC8910-0x0000000181DC8920 0x000000018239DA00-0x000000018239DA20
		public bool isImmediatePropagationStopped { get; private set; } // 0x000000018239D660-0x000000018239D670 0x000000018239D9E0-0x000000018239DA00
		internal PropagationPhase propagationPhase { [CompilerGenerated] set; } // 0x000000018033ED10-0x000000018033ED20
		public virtual IEventHandler currentTarget { get; internal set; } // 0x00000001803272B0-0x00000001803272C0 0x000000018239D6D0-0x000000018239D890
		public bool dispatch { get; internal set; } // 0x000000018239D620-0x000000018239D630 0x000000018239D890-0x000000018239D8B0
		private bool dispatched { get; set; } // 0x0000000181B7A550-0x0000000181B7A560 0x000000018239D8B0-0x000000018239D8D0
		internal bool processed { get; private set; } // 0x000000018239D6B0-0x000000018239D6C0 0x000000018239DA60-0x000000018239DA80
		internal bool processedByFocusController { get; set; } // 0x000000018239D6A0-0x000000018239D6B0 0x000000018239DA40-0x000000018239DA60
		internal bool propagateToIMGUI { get; set; } // 0x000000018239D6C0-0x000000018239D6D0 0x000000018239DA80-0x000000018239DAA0
		private bool imguiEventIsValid { get; set; } // 0x000000018239D640-0x000000018239D650 0x000000018239D8F0-0x000000018239D910
		public Event imguiEvent { get; protected set; } // 0x000000018239D650-0x000000018239D660 0x000000018239D910-0x000000018239D9E0
		public Vector2 originalMousePosition { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018239D670-0x000000018239D690 0x000000018044C5A0-0x000000018044C5B0
		protected bool pooled { get; set; } // 0x000000018239D690-0x000000018239D6A0 0x000000018239DA20-0x000000018239DA40
	
		// Nested types
		internal class TypeData // TypeDefIndex: 3970
		{
			// Fields
			public readonly long eventTypeId; // 0x10
			public readonly EventCategory eventCategory; // 0x18
			public readonly int eventCategories; // 0x1C
	
			// Constructors
			public TypeData(long eventTypeId, EventCategory eventCategory); // 0x00000001823B0E00-0x00000001823B0E50
		}
	
		[Flags]
		[VisibleToOtherModules(new string[2] {"UnityEditor.GraphToolkitModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal enum EventPropagation // TypeDefIndex: 3971
		{
			None = 0,
			Bubbles = 1,
			TricklesDown = 2,
			BubblesOrTricklesDown = 3,
			IgnoreDisabledElements = 4
		}
	
		[Flags]
		private enum LifeCycleStatus // TypeDefIndex: 3972
		{
			None = 0,
			PropagationStopped = 1,
			ImmediatePropagationStopped = 2,
			Dispatching = 4,
			Pooled = 8,
			IMGUIEventIsValid = 16,
			PropagateToIMGUI = 32,
			Dispatched = 64,
			Processed = 128,
			ProcessedByFocusController = 256
		}
	
		// Constructors
		internal EventBase(EventCategory category); // 0x000000018239D5B0-0x000000018239D600
	
		// Methods
		protected static long RegisterEventType(); // 0x000000018239D540-0x000000018239D590
		internal void SetTriggerEventId(ulong id); // 0x0000000181C854D0-0x0000000181C854E0
		[Obsolete("Override PreDispatch(IPanel panel) instead.")]
		protected virtual void PreDispatch(); // 0x00000001802E76C0-0x00000001802E76D0
		protected internal virtual void PreDispatch(IPanel panel); // 0x0000000181884190-0x00000001818841B0
		[Obsolete("Override PostDispatch(IPanel panel) instead.")]
		protected virtual void PostDispatch(); // 0x00000001802E76C0-0x00000001802E76D0
		protected internal virtual void PostDispatch(IPanel panel); // 0x000000018239D510-0x000000018239D540
		internal virtual void Dispatch([NotNull] BaseVisualElementPanel panel); // 0x000000018239D3A0-0x000000018239D3B0
		public void StopPropagation(); // 0x000000018239D5A0-0x000000018239D5B0
		public void StopImmediatePropagation(); // 0x000000018239D590-0x000000018239D5A0
		internal void MarkReceivedByDispatcher(); // 0x000000018239D490-0x000000018239D510
		protected virtual void Init(); // 0x000000018239D3B0-0x000000018239D3C0
		private void LocalInit(); // 0x000000018239D3C0-0x000000018239D490
		internal abstract void Acquire();
		public abstract void Dispose();
		internal void AssignTimeStamp(long time); // 0x00000001804C2E30-0x00000001804C2E40
		internal abstract void InvokeCallback(Delegate userCallback);
		internal abstract void InvokeCallback<TArg>(Delegate userCallback, [IsReadOnly] in ref TArg arg);
	}
}
