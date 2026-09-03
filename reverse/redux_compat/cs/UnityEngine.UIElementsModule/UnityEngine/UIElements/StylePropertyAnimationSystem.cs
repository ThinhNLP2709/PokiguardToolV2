/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Pool;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal class StylePropertyAnimationSystem : IStylePropertyAnimationSystem // TypeDefIndex: 4727
	{
		// Fields
		private double m_CurrentTime; // 0x10
		private ValuesFloat m_Floats; // 0x18
		private ValuesInt m_Ints; // 0x20
		private ValuesLength m_Lengths; // 0x28
		private ValuesColor m_Colors; // 0x30
		private ValuesEnum m_Enums; // 0x38
		private ValuesEntityId m_EntityIds; // 0x40
		private ValuesCursor m_Cursors; // 0x48
		private ValuesTextShadow m_TextShadows; // 0x50
		private ValuesScale m_Scale; // 0x58
		private ValuesRotate m_Rotate; // 0x60
		private ValuesRatio m_Ratio; // 0x68
		private ValuesTranslate m_Translate; // 0x70
		private ValuesTransformOrigin m_TransformOrigin; // 0x78
		private ValuesBackgroundPosition m_BackgroundPosition; // 0x80
		private ValuesBackgroundRepeat m_BackgroundRepeat; // 0x88
		private ValuesBackgroundSize m_BackgroundSize; // 0x90
		private ValuesListFilterFunction m_FilterFunctions; // 0x98
		private ValuesMaterialDefinition m_MaterialDefinition; // 0xA0
		private readonly List<Values> m_AllValues; // 0xA8
		private readonly Panel m_Panel; // 0xB0
		private Dictionary<VisualElement, ClipPlayer> m_ElementClipAnimations; // 0xB8
		private readonly Dictionary<StylePropertyId, Values> m_PropertyToValues; // 0xC0
	
		// Nested types
		[Flags]
		private enum TransitionState // TypeDefIndex: 4728
		{
			None = 0,
			Running = 1,
			Started = 2,
			Ended = 4,
			Canceled = 8
		}
	
		private struct AnimationDataSet<TTimingData, TStyleData> // TypeDefIndex: 4729
		{
			// Fields
			public VisualElement[] elements;
			public StylePropertyId[] properties;
			public TTimingData[] timing;
			public TStyleData[] style;
			public int count;
			private Dictionary<ElementPropertyPair, int> indices;
	
			// Properties
			private int capacity { get; set; }
	
			// Methods
			private void LocalInit();
			public static AnimationDataSet<TTimingData, TStyleData> Create();
			public bool IndexOf(VisualElement ve, StylePropertyId prop, out int index);
			public void Add(VisualElement owner, StylePropertyId prop, TTimingData timingData, TStyleData styleData);
			public void Remove(int cancelledIndex);
			public void Replace(int index, TTimingData timingData, TStyleData styleData);
			public void RemoveAll(VisualElement ve);
			public void RemoveAll();
			public void GetActivePropertiesForElement(VisualElement ve, List<StylePropertyId> outProperties);
		}
	
		private struct ElementPropertyPair // TypeDefIndex: 4730
		{
			// Fields
			public static readonly IEqualityComparer<ElementPropertyPair> Comparer; // 0x00
			public readonly VisualElement element; // 0x00
			public readonly StylePropertyId property; // 0x08
	
			// Nested types
			private class EqualityComparer : IEqualityComparer<ElementPropertyPair> // TypeDefIndex: 4731
			{
				// Constructors
				public EqualityComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				public bool Equals(ElementPropertyPair x, ElementPropertyPair y); // 0x000000018255DD20-0x000000018255DD40
				public int GetHashCode(ElementPropertyPair obj); // 0x000000018255DD40-0x000000018255DD80
			}
	
			// Constructors
			public ElementPropertyPair(VisualElement element, StylePropertyId property); // 0x0000000180DEFF80-0x0000000180DEFFB0
			static ElementPropertyPair(); // 0x000000018255DCA0-0x000000018255DD20
		}
	
		private abstract class Values // TypeDefIndex: 4732
		{
			// Constructors
			protected Values(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public abstract void CancelAllAnimations();
			public abstract void CancelAllAnimations(VisualElement ve);
			public abstract void CancelAnimation(VisualElement ve, StylePropertyId id);
			public abstract void UpdateAnimation(VisualElement ve, StylePropertyId id);
			public abstract void GetAllAnimations(VisualElement ve, List<StylePropertyId> outPropertyIds);
			public abstract void Update(double currentTime);
			protected abstract void UpdateValues();
			protected abstract void UpdateComputedStyle();
			protected abstract void UpdateComputedStyle(int i);
		}
	
		private abstract class Values<T> : Values // TypeDefIndex: 4733
		{
			// Fields
			private double m_CurrentTime;
			private TransitionEventsFrameState m_CurrentFrameEventsState;
			private TransitionEventsFrameState m_NextFrameEventsState;
			public AnimationDataSet<TimingData, StyleData> running;
			public AnimationDataSet<EmptyData, T> completed;
	
			// Properties
			public bool isEmpty { get; }
			public abstract Func<T, T, bool> SameFunc { get; }
	
			// Nested types
			private class TransitionEventsFrameState // TypeDefIndex: 4734
			{
				// Fields
				private static readonly ObjectPool<Queue<EventBase>> k_EventQueuePool;
				public readonly Dictionary<ElementPropertyPair, TransitionState> elementPropertyStateDelta;
				public readonly Dictionary<ElementPropertyPair, Queue<EventBase>> elementPropertyQueuedEvents;
				public IPanel panel;
				private int m_ChangesCount;
	
				// Nested types
				[Serializable]
				[CompilerGenerated]
				private sealed class __c // TypeDefIndex: 4735
				{
					// Fields
					public static readonly __c<T> __9;
	
					// Constructors
					static __c();
					public __c();
	
					// Methods
					internal Queue<EventBase> _.cctor_b__11_0();
				}
	
				// Constructors
				public TransitionEventsFrameState();
				static TransitionEventsFrameState();
	
				// Methods
				public static Queue<EventBase> GetPooledQueue();
				public void RegisterChange();
				public void UnregisterChange();
				public bool StateChanged();
				public void Clear();
			}
	
			public struct TimingData // TypeDefIndex: 4736
			{
				// Fields
				public double startTime;
				public float duration;
				public Func<float, float> easingCurve;
				public float easedProgress;
				public float reversingShorteningFactor;
				public bool isStarted;
				public float delay;
			}
	
			public struct StyleData // TypeDefIndex: 4737
			{
				// Fields
				public T startValue;
				public T endValue;
				public T reversingAdjustedStartValue;
				public T currentValue;
			}
	
			public struct EmptyData // TypeDefIndex: 4738
			{
				// Fields
				public static EmptyData<T> Default;
			}
	
			// Constructors
			protected Values();
	
			// Methods
			protected virtual bool ConvertUnits(VisualElement owner, StylePropertyId prop, ref ref T a, ref ref T b);
			protected virtual T Copy(T value);
			private void SwapFrameStates();
			private void QueueEvent(EventBase evt, ElementPropertyPair epp);
			private void ClearEventQueue(ElementPropertyPair epp);
			private void QueueTransitionRunEvent(VisualElement ve, int runningIndex);
			private void QueueTransitionStartEvent(VisualElement ve, int runningIndex);
			private void QueueTransitionEndEvent(VisualElement ve, int runningIndex);
			private void QueueTransitionCancelEvent(VisualElement ve, int runningIndex, double panelElapsed);
			private void SendTransitionCancelEvent(VisualElement ve, int runningIndex, double panelElapsed);
			public sealed override void CancelAllAnimations();
			public sealed override void CancelAllAnimations(VisualElement ve);
			public sealed override void CancelAnimation(VisualElement ve, StylePropertyId id);
			public sealed override void UpdateAnimation(VisualElement ve, StylePropertyId id);
			public sealed override void GetAllAnimations(VisualElement ve, List<StylePropertyId> outPropertyIds);
			private float ComputeReversingShorteningFactor(int oldIndex);
			private float ComputeReversingDuration(float newTransitionDuration, float newReversingShorteningFactor);
			private float ComputeReversingDelay(float delay, float newReversingShorteningFactor);
			public bool StartTransition(VisualElement owner, StylePropertyId prop, T startValue, T endValue, float duration, float delay, Func<float, float> easingCurve, double currentTime);
			private void ForceComputedStyleEndValue(int runningIndex);
			public sealed override void Update(double currentTime);
			private void ProcessEventQueue();
			private void UpdateProgress(double currentTime);
		}
	
		private class ValuesFloat : Values<float> // TypeDefIndex: 4739
		{
			// Fields
			[CompilerGenerated]
			private readonly Func<float, float, bool> _SameFunc_k__BackingField; // 0x88
	
			// Properties
			public override Func<float, float, bool> SameFunc { [CompilerGenerated] get; } // 0x000000018038B8A0-0x000000018038B8B0 
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 4740
			{
				// Fields
				public static Func<float, float, bool> _0___IsSame; // 0x00
			}
	
			// Constructors
			public ValuesFloat(); // 0x0000000182572B40-0x0000000182572C30
	
			// Methods
			private static bool IsSame(float a, float b); // 0x00000001821EC560-0x00000001821EC5A0
			private static void Lerp(float a, float b, ref float result, float t); // 0x00000001825728F0-0x0000000182572910
			protected sealed override void UpdateValues(); // 0x0000000182572AB0-0x0000000182572B40
			protected sealed override void UpdateComputedStyle(); // 0x0000000182572910-0x0000000182572A10
			protected sealed override void UpdateComputedStyle(int i); // 0x0000000182572A10-0x0000000182572AB0
		}
	
		private class ValuesInt : Values<int> // TypeDefIndex: 4741
		{
			// Fields
			[CompilerGenerated]
			private readonly Func<int, int, bool> _SameFunc_k__BackingField; // 0x88
	
			// Properties
			public override Func<int, int, bool> SameFunc { [CompilerGenerated] get; } // 0x000000018038B8A0-0x000000018038B8B0 
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 4742
			{
				// Fields
				public static Func<int, int, bool> _0___IsSame; // 0x00
			}
	
			// Constructors
			public ValuesInt(); // 0x0000000182572F30-0x0000000182573020
	
			// Methods
			private static bool IsSame(int a, int b); // 0x0000000180A2DD00-0x0000000180A2DD10
			private static int Lerp(int a, int b, float t); // 0x0000000182572C30-0x0000000182572D50
			protected sealed override void UpdateValues(); // 0x0000000182572D50-0x0000000182572F30
			protected sealed override void UpdateComputedStyle(); // 0x00000001825727B0-0x00000001825728B0
			protected sealed override void UpdateComputedStyle(int i); // 0x0000000182572710-0x00000001825727B0
		}
	
		private class ValuesLength : Values<Length> // TypeDefIndex: 4743
		{
			// Fields
			[CompilerGenerated]
			private readonly Func<Length, Length, bool> _SameFunc_k__BackingField; // 0x88
	
			// Properties
			public override Func<Length, Length, bool> SameFunc { [CompilerGenerated] get; } // 0x000000018038B8A0-0x000000018038B8B0 
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 4744
			{
				// Fields
				public static Func<Length, Length, bool> _0___IsSame; // 0x00
			}
	
			// Constructors
			public ValuesLength(); // 0x00000001825733C0-0x00000001825734B0
	
			// Methods
			private static bool IsSame(Length a, Length b); // 0x0000000182573060-0x00000001825730D0
			protected sealed override bool ConvertUnits(VisualElement owner, StylePropertyId prop, ref Length a, ref Length b); // 0x0000000182573020-0x0000000182573060
			internal static Length Lerp(Length a, Length b, float t); // 0x00000001825730D0-0x0000000182573120
			protected sealed override void UpdateValues(); // 0x00000001825732C0-0x00000001825733C0
			protected sealed override void UpdateComputedStyle(); // 0x0000000182573120-0x0000000182573220
			protected sealed override void UpdateComputedStyle(int i); // 0x0000000182573220-0x00000001825732C0
		}
	
		private class ValuesColor : Values<Color> // TypeDefIndex: 4745
		{
			// Fields
			[CompilerGenerated]
			private readonly Func<Color, Color, bool> _SameFunc_k__BackingField; // 0x88
	
			// Properties
			public override Func<Color, Color, bool> SameFunc { [CompilerGenerated] get; } // 0x000000018038B8A0-0x000000018038B8B0 
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 4746
			{
				// Fields
				public static Func<Color, Color, bool> _0___IsSame; // 0x00
			}
	
			// Constructors
			public ValuesColor(); // 0x00000001825720F0-0x00000001825721E0
	
			// Methods
			private static bool IsSame(Color c, Color d); // 0x0000000182571C90-0x0000000182571D70
			private static Color Lerp(Color a, Color b, float t); // 0x0000000182571D70-0x0000000182571E10
			protected sealed override void UpdateValues(); // 0x0000000182571FD0-0x00000001825720F0
			protected sealed override void UpdateComputedStyle(); // 0x0000000182571EC0-0x0000000182571FD0
			protected sealed override void UpdateComputedStyle(int i); // 0x0000000182571E10-0x0000000182571EC0
		}
	
		private abstract class ValuesDiscrete<T> : Values<T> // TypeDefIndex: 4747
		{
			// Fields
			[CompilerGenerated]
			private readonly Func<T, T, bool> _SameFunc_k__BackingField;
	
			// Properties
			public override Func<T, T, bool> SameFunc { [CompilerGenerated] get; }
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 4748
			{
				// Fields
				public static Func<T, T, bool> _0___IsSame;
			}
	
			// Constructors
			protected ValuesDiscrete();
	
			// Methods
			private static bool IsSame(T a, T b);
			private static T Lerp(T a, T b, float t);
			protected sealed override void UpdateValues();
		}
	
		private class ValuesEnum : ValuesDiscrete<int> // TypeDefIndex: 4749
		{
			// Constructors
			public ValuesEnum(); // 0x00000001825728B0-0x00000001825728F0
	
			// Methods
			protected sealed override void UpdateComputedStyle(); // 0x00000001825727B0-0x00000001825728B0
			protected sealed override void UpdateComputedStyle(int i); // 0x0000000182572710-0x00000001825727B0
		}
	
		private class ValuesEntityId : ValuesDiscrete<EntityId> // TypeDefIndex: 4750
		{
			// Constructors
			public ValuesEntityId(); // 0x00000001825726D0-0x0000000182572710
	
			// Methods
			protected sealed override void UpdateComputedStyle(); // 0x00000001825725D0-0x00000001825726D0
			protected sealed override void UpdateComputedStyle(int i); // 0x0000000182572530-0x00000001825725D0
		}
	
		private class ValuesCursor : ValuesDiscrete<Cursor> // TypeDefIndex: 4751
		{
			// Fields
			[CompilerGenerated]
			private readonly Func<Cursor, Cursor, bool> _SameFunc_k__BackingField; // 0x90
	
			// Properties
			public override Func<Cursor, Cursor, bool> SameFunc { [CompilerGenerated] get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 4752
			{
				// Fields
				public static Func<Cursor, Cursor, bool> _0___IsSame; // 0x00
			}
	
			// Constructors
			public ValuesCursor(); // 0x0000000182572440-0x0000000182572530
	
			// Methods
			private static new bool IsSame(Cursor a, Cursor b); // 0x00000001825721E0-0x0000000182572250
			protected sealed override void UpdateComputedStyle(); // 0x0000000182572250-0x0000000182572380
			protected sealed override void UpdateComputedStyle(int i); // 0x0000000182572380-0x0000000182572440
		}
	
		private class ValuesTextShadow : Values<TextShadow> // TypeDefIndex: 4753
		{
			// Fields
			[CompilerGenerated]
			private readonly Func<TextShadow, TextShadow, bool> _SameFunc_k__BackingField; // 0x88
	
			// Properties
			public override Func<TextShadow, TextShadow, bool> SameFunc { [CompilerGenerated] get; } // 0x000000018038B8A0-0x000000018038B8B0 
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 4754
			{
				// Fields
				public static Func<TextShadow, TextShadow, bool> _0___IsSame; // 0x00
			}
	
			// Constructors
			public ValuesTextShadow(); // 0x00000001825769A0-0x0000000182576A90
	
			// Methods
			private static bool IsSame(TextShadow a, TextShadow b); // 0x0000000182576570-0x00000001825765C0
			private static TextShadow Lerp(TextShadow a, TextShadow b, float t); // 0x00000001825765C0-0x0000000182576650
			protected sealed override void UpdateValues(); // 0x0000000182576860-0x00000001825769A0
			protected sealed override void UpdateComputedStyle(); // 0x0000000182576720-0x0000000182576860
			protected sealed override void UpdateComputedStyle(int i); // 0x0000000182576650-0x0000000182576720
		}
	
		private class ValuesScale : Values<Scale> // TypeDefIndex: 4755
		{
			// Fields
			[CompilerGenerated]
			private readonly Func<Scale, Scale, bool> _SameFunc_k__BackingField; // 0x88
	
			// Properties
			public override Func<Scale, Scale, bool> SameFunc { [CompilerGenerated] get; } // 0x000000018038B8A0-0x000000018038B8B0 
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 4756
			{
				// Fields
				public static Func<Scale, Scale, bool> _0___IsSame; // 0x00
			}
	
			// Constructors
			public ValuesScale(); // 0x0000000182576480-0x0000000182576570
	
			// Methods
			private static bool IsSame(Scale a, Scale b); // 0x00000001825760F0-0x0000000182576150
			protected sealed override void UpdateComputedStyle(); // 0x0000000182576270-0x0000000182576380
			protected sealed override void UpdateComputedStyle(int i); // 0x00000001825761C0-0x0000000182576270
			private static Scale Lerp(Scale a, Scale b, float t); // 0x0000000182576150-0x00000001825761C0
			protected sealed override void UpdateValues(); // 0x0000000182576380-0x0000000182576480
		}
	
		private class ValuesRotate : Values<Rotate> // TypeDefIndex: 4757
		{
			// Fields
			[CompilerGenerated]
			private readonly Func<Rotate, Rotate, bool> _SameFunc_k__BackingField; // 0x88
	
			// Properties
			public override Func<Rotate, Rotate, bool> SameFunc { [CompilerGenerated] get; } // 0x000000018038B8A0-0x000000018038B8B0 
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 4758
			{
				// Fields
				public static Func<Rotate, Rotate, bool> _0___IsSame; // 0x00
			}
	
			// Constructors
			public ValuesRotate(); // 0x0000000182576000-0x00000001825760F0
	
			// Methods
			private static bool IsSame(Rotate a, Rotate b); // 0x0000000182575B20-0x0000000182575B70
			protected sealed override void UpdateComputedStyle(); // 0x0000000182575D00-0x0000000182575E30
			protected sealed override void UpdateComputedStyle(int i); // 0x0000000182575C40-0x0000000182575D00
			private static Rotate Lerp(Rotate a, Rotate b, float t); // 0x0000000182575B70-0x0000000182575C40
			protected sealed override void UpdateValues(); // 0x0000000182575E30-0x0000000182576000
		}
	
		private class ValuesRatio : Values<Ratio> // TypeDefIndex: 4759
		{
			// Fields
			[CompilerGenerated]
			private readonly Func<Ratio, Ratio, bool> _SameFunc_k__BackingField; // 0x88
	
			// Properties
			public override Func<Ratio, Ratio, bool> SameFunc { [CompilerGenerated] get; } // 0x000000018038B8A0-0x000000018038B8B0 
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 4760
			{
				// Fields
				public static Func<Ratio, Ratio, bool> _0___IsSame; // 0x00
			}
	
			// Constructors
			public ValuesRatio(); // 0x0000000182575A30-0x0000000182575B20
	
			// Methods
			private static bool IsSame(Ratio a, Ratio b); // 0x000000018255EB70-0x000000018255EBB0
			protected sealed override bool ConvertUnits(VisualElement owner, StylePropertyId prop, ref Ratio a, ref Ratio b); // 0x0000000182575720-0x0000000182575870
			protected sealed override void UpdateComputedStyle(); // 0x0000000182575890-0x0000000182575990
			protected sealed override void UpdateComputedStyle(int i); // 0x0000000182575990-0x0000000182575A30
			private static Ratio Lerp(Ratio a, Ratio b, float t); // 0x0000000182575870-0x0000000182575890
			protected sealed override void UpdateValues(); // 0x0000000182572AB0-0x0000000182572B40
		}
	
		private class ValuesTranslate : Values<Translate> // TypeDefIndex: 4761
		{
			// Fields
			[CompilerGenerated]
			private readonly Func<Translate, Translate, bool> _SameFunc_k__BackingField; // 0x88
	
			// Properties
			public override Func<Translate, Translate, bool> SameFunc { [CompilerGenerated] get; } // 0x000000018038B8A0-0x000000018038B8B0 
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 4762
			{
				// Fields
				public static Func<Translate, Translate, bool> _0___IsSame; // 0x00
			}
	
			// Constructors
			public ValuesTranslate(); // 0x0000000182577740-0x0000000182577830
	
			// Methods
			private static bool IsSame(Translate a, Translate b); // 0x0000000182577170-0x0000000182577250
			protected sealed override bool ConvertUnits(VisualElement owner, StylePropertyId prop, ref Translate a, ref Translate b); // 0x0000000182577140-0x0000000182577170
			protected sealed override void UpdateComputedStyle(); // 0x0000000182577410-0x0000000182577540
			protected sealed override void UpdateComputedStyle(int i); // 0x0000000182577350-0x0000000182577410
			private static Translate Lerp(Translate a, Translate b, float t); // 0x0000000182577250-0x0000000182577350
			protected sealed override void UpdateValues(); // 0x0000000182577540-0x0000000182577740
		}
	
		private class ValuesTransformOrigin : Values<TransformOrigin> // TypeDefIndex: 4763
		{
			// Fields
			[CompilerGenerated]
			private readonly Func<TransformOrigin, TransformOrigin, bool> _SameFunc_k__BackingField; // 0x88
	
			// Properties
			public override Func<TransformOrigin, TransformOrigin, bool> SameFunc { [CompilerGenerated] get; } // 0x000000018038B8A0-0x000000018038B8B0 
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 4764
			{
				// Fields
				public static Func<TransformOrigin, TransformOrigin, bool> _0___IsSame; // 0x00
			}
	
			// Constructors
			public ValuesTransformOrigin(); // 0x0000000182577050-0x0000000182577140
	
			// Methods
			private static bool IsSame(TransformOrigin a, TransformOrigin b); // 0x0000000182576AC0-0x0000000182576B50
			protected sealed override bool ConvertUnits(VisualElement owner, StylePropertyId prop, ref TransformOrigin a, ref TransformOrigin b); // 0x0000000182576A90-0x0000000182576AC0
			protected sealed override void UpdateComputedStyle(); // 0x0000000182576D00-0x0000000182576E30
			protected sealed override void UpdateComputedStyle(int i); // 0x0000000182576C40-0x0000000182576D00
			private static TransformOrigin Lerp(TransformOrigin a, TransformOrigin b, float t); // 0x0000000182576B50-0x0000000182576C40
			protected sealed override void UpdateValues(); // 0x0000000182576E30-0x0000000182577050
		}
	
		private class ValuesBackgroundPosition : ValuesDiscrete<BackgroundPosition> // TypeDefIndex: 4765
		{
			// Constructors
			public ValuesBackgroundPosition(); // 0x0000000182571480-0x00000001825714C0
	
			// Methods
			protected sealed override void UpdateComputedStyle(); // 0x00000001825712A0-0x00000001825713C0
			protected sealed override void UpdateComputedStyle(int i); // 0x00000001825713C0-0x0000000182571480
		}
	
		private class ValuesBackgroundRepeat : ValuesDiscrete<BackgroundRepeat> // TypeDefIndex: 4766
		{
			// Constructors
			public ValuesBackgroundRepeat(); // 0x0000000182571660-0x00000001825716A0
	
			// Methods
			protected sealed override void UpdateComputedStyle(); // 0x0000000182571560-0x0000000182571660
			protected sealed override void UpdateComputedStyle(int i); // 0x00000001825714C0-0x0000000182571560
		}
	
		private class ValuesBackgroundSize : Values<BackgroundSize> // TypeDefIndex: 4767
		{
			// Fields
			[CompilerGenerated]
			private readonly Func<BackgroundSize, BackgroundSize, bool> _SameFunc_k__BackingField; // 0x88
	
			// Properties
			public override Func<BackgroundSize, BackgroundSize, bool> SameFunc { [CompilerGenerated] get; } // 0x000000018038B8A0-0x000000018038B8B0 
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 4768
			{
				// Fields
				public static Func<BackgroundSize, BackgroundSize, bool> _0___IsSame; // 0x00
			}
	
			// Constructors
			public ValuesBackgroundSize(); // 0x0000000182571BA0-0x0000000182571C90
	
			// Methods
			private static bool IsSame(BackgroundSize a, BackgroundSize b); // 0x00000001825716D0-0x0000000182571710
			protected sealed override bool ConvertUnits(VisualElement owner, StylePropertyId prop, ref BackgroundSize a, ref BackgroundSize b); // 0x00000001825716A0-0x00000001825716D0
			protected sealed override void UpdateComputedStyle(); // 0x00000001825718A0-0x00000001825719D0
			protected sealed override void UpdateComputedStyle(int i); // 0x00000001825717E0-0x00000001825718A0
			private static BackgroundSize Lerp(BackgroundSize a, BackgroundSize b, float t); // 0x0000000182571710-0x00000001825717E0
			protected sealed override void UpdateValues(); // 0x00000001825719D0-0x0000000182571BA0
		}
	
		private class ValuesListFilterFunction : Values<List<FilterFunction>> // TypeDefIndex: 4769
		{
			// Fields
			[CompilerGenerated]
			private readonly Func<List<FilterFunction>, List<FilterFunction>, bool> _SameFunc_k__BackingField; // 0x88
	
			// Properties
			public override Func<List<FilterFunction>, List<FilterFunction>, bool> SameFunc { [CompilerGenerated] get; } // 0x000000018038B8A0-0x000000018038B8B0 
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 4770
			{
				// Fields
				public static Func<List<FilterFunction>, List<FilterFunction>, bool> _0___IsSame; // 0x00
			}
	
			// Constructors
			public ValuesListFilterFunction(); // 0x0000000182574450-0x0000000182574540
	
			// Methods
			protected override List<FilterFunction> Copy(List<FilterFunction> value); // 0x00000001825736D0-0x0000000182573740
			private static bool IsSame(List<FilterFunction> a, List<FilterFunction> b); // 0x0000000182573960-0x0000000182573B10
			protected sealed override bool ConvertUnits(VisualElement owner, StylePropertyId prop, ref List<FilterFunction> a, ref List<FilterFunction> b); // 0x0000000182573540-0x00000001825736D0
			private static bool AreFilterDefinitionsCompatible(FilterFunctionDefinition filterDef1, FilterFunctionDefinition filterDef2); // 0x00000001825734B0-0x0000000182573540
			protected sealed override void UpdateComputedStyle(); // 0x0000000182574280-0x0000000182574380
			protected sealed override void UpdateComputedStyle(int i); // 0x00000001825741E0-0x0000000182574280
			private static FilterParameter LerpFilterParameters(FilterParameter a, FilterParameter b, float t); // 0x0000000182573B10-0x0000000182573C70
			private static void Lerp(List<FilterFunction> a, List<FilterFunction> b, ref List<FilterFunction> result, float t); // 0x0000000182573C70-0x00000001825741E0
			private static FilterFunction GetFunctionOrDefault(ref List<FilterFunction> srcList, ref List<FilterFunction> refList, int index); // 0x0000000182573740-0x0000000182573960
			protected sealed override void UpdateValues(); // 0x0000000182574380-0x0000000182574450
		}
	
		private class ValuesMaterialDefinition : Values<MaterialDefinition> // TypeDefIndex: 4771
		{
			// Fields
			[CompilerGenerated]
			private readonly Func<MaterialDefinition, MaterialDefinition, bool> _SameFunc_k__BackingField; // 0x88
	
			// Properties
			public override Func<MaterialDefinition, MaterialDefinition, bool> SameFunc { [CompilerGenerated] get; } // 0x000000018038B8A0-0x000000018038B8B0 
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 4772
			{
				// Fields
				public static Func<MaterialDefinition, MaterialDefinition, bool> _0___IsSame; // 0x00
			}
	
			// Constructors
			public ValuesMaterialDefinition(); // 0x0000000182575630-0x0000000182575720
	
			// Methods
			protected override MaterialDefinition Copy(MaterialDefinition value); // 0x0000000182574740-0x0000000182574770
			private static bool IsSame(MaterialDefinition a, MaterialDefinition b); // 0x00000001825748B0-0x0000000182574AD0
			protected sealed override bool ConvertUnits(VisualElement owner, StylePropertyId prop, ref MaterialDefinition a, ref MaterialDefinition b); // 0x0000000182574540-0x0000000182574740
			protected sealed override void UpdateComputedStyle(); // 0x0000000182575380-0x0000000182575490
			protected sealed override void UpdateComputedStyle(int i); // 0x0000000182575490-0x0000000182575540
			private static MaterialPropertyValue LerpPropertyValues(MaterialPropertyValue a, MaterialPropertyValue b, float t); // 0x0000000182574AD0-0x0000000182574CA0
			private static MaterialPropertyValue GetValueOrDefault(List<MaterialPropertyValue> srcList, List<MaterialPropertyValue> refList, int index); // 0x0000000182574770-0x00000001825748B0
			private static void Lerp(MaterialDefinition a, MaterialDefinition b, ref MaterialDefinition result, float t); // 0x0000000182574CA0-0x0000000182575380
			protected sealed override void UpdateValues(); // 0x0000000182575540-0x0000000182575630
		}
	
		private struct ClipPlayer // TypeDefIndex: 4773
		{
			// Fields
			public UIAnimationClip clip; // 0x00
			public UIAnimationBinder binder; // 0x08
			public double startTime; // 0x10
			public float clipLength; // 0x18
			public bool isLooping; // 0x1C
			public bool isPaused; // 0x1D
			public float pausedElapsed; // 0x20
	
			// Methods
			public void Sample(double now); // 0x000000018255DB90-0x000000018255DC60
		}
	
		// Constructors
		public StylePropertyAnimationSystem(BaseVisualElementPanel p); // 0x00000001825676D0-0x0000000182567860
	
		// Methods
		private T GetOrCreate<T>(ref ref T values)
			where T : new();
		private bool StartTransition<T>(VisualElement owner, StylePropertyId prop, T startValue, T endValue, int durationMs, int delayMs, Func<float, float> easingCurve, Values<T> values);
		public bool StartTransition(VisualElement owner, StylePropertyId prop, float startValue, float endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x0000000182566AC0-0x0000000182566B90
		public bool StartTransition(VisualElement owner, StylePropertyId prop, int startValue, int endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x00000001825666F0-0x00000001825667B0
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Length startValue, Length endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x0000000182566440-0x0000000182566510
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Color startValue, Color endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x0000000182566510-0x00000001825665F0
		public bool StartTransitionEnum(VisualElement owner, StylePropertyId prop, int startValue, int endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x0000000182565F10-0x0000000182565FD0
		public bool StartTransition(VisualElement owner, StylePropertyId prop, EntityId startValue, EntityId endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x0000000182565FD0-0x00000001825660A0
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Cursor startValue, Cursor endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x0000000182566170-0x0000000182566270
		public bool StartTransition(VisualElement owner, StylePropertyId prop, TextShadow startValue, TextShadow endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x00000001825669B0-0x0000000182566AC0
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Scale startValue, Scale endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x0000000182566B90-0x0000000182566C70
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Rotate startValue, Rotate endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x00000001825668B0-0x00000001825669B0
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Translate startValue, Translate endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x0000000182566C70-0x0000000182566D70
		public bool StartTransition(VisualElement owner, StylePropertyId prop, Ratio startValue, Ratio endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x0000000182566E40-0x0000000182566F10
		public bool StartTransition(VisualElement owner, StylePropertyId prop, TransformOrigin startValue, TransformOrigin endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x00000001825665F0-0x00000001825666F0
		public bool StartTransition(VisualElement owner, StylePropertyId prop, BackgroundPosition startValue, BackgroundPosition endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x0000000182566270-0x0000000182566360
		public bool StartTransition(VisualElement owner, StylePropertyId prop, BackgroundRepeat startValue, BackgroundRepeat endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x0000000182566D70-0x0000000182566E40
		public bool StartTransition(VisualElement owner, StylePropertyId prop, BackgroundSize startValue, BackgroundSize endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x00000001825667B0-0x00000001825668B0
		public bool StartTransition(VisualElement owner, StylePropertyId prop, List<FilterFunction> startValue, List<FilterFunction> endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x00000001825660A0-0x0000000182566170
		public bool StartTransition(VisualElement owner, StylePropertyId prop, MaterialDefinition startValue, MaterialDefinition endValue, int durationMs, int delayMs, [NotNull] Func<float, float> easingCurve); // 0x0000000182566360-0x0000000182566440
		public void CancelAllAnimations(); // 0x0000000182565A20-0x0000000182565B00
		public void CancelAllAnimations(VisualElement owner); // 0x0000000182565B00-0x0000000182565CB0
		public void CancelAnimation(VisualElement owner, StylePropertyId id); // 0x0000000182565CB0-0x0000000182565D50
		public void UpdateAnimation(VisualElement owner, StylePropertyId id); // 0x0000000182566F10-0x0000000182566FB0
		public void GetAllAnimations(VisualElement owner, List<StylePropertyId> propertyIds); // 0x0000000182565E10-0x0000000182565F10
		private void UpdateTracking<T>(Values<T> values);
		private double CurrentTimeSeconds(); // 0x0000000181107A70-0x0000000181107A80
		public void UpdateElementClipAnimation(VisualElement owner, UIAnimationClip clip, AnimationPlayState playState, double currentTime); // 0x0000000182566FB0-0x0000000182567400
		public void CancelElementClipAnimation(VisualElement owner); // 0x0000000182565D50-0x0000000182565E10
		public void Update(double updateTime); // 0x0000000182567400-0x00000001825676D0
	}
}
