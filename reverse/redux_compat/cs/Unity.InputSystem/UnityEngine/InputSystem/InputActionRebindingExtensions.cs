/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public static class InputActionRebindingExtensions // TypeDefIndex: 6071
	{
		// Fields
		private static DeferBindingResolutionWrapper s_DeferBindingResolutionWrapper; // 0x00
	
		// Nested types
		internal struct Parameter // TypeDefIndex: 6072
		{
			// Fields
			public object instance; // 0x00
			public FieldInfo field; // 0x08
			public int bindingIndex; // 0x10
		}
	
		private struct ParameterEnumerable : IEnumerable<Parameter> // TypeDefIndex: 6073
		{
			// Fields
			private InputActionState m_State; // 0x00
			private ParameterOverride m_Parameter; // 0x08
			private int m_MapIndex; // 0x80
	
			// Constructors
			public ParameterEnumerable(InputActionState state, ParameterOverride parameter, int mapIndex = -1 /* Metadata: 0x00698916 */); // 0x0000000181CC39E0-0x0000000181CC3A70
	
			// Methods
			public ParameterEnumerator GetEnumerator(); // 0x0000000181CC3710-0x0000000181CC3840
			IEnumerator<Parameter> System.Collections.Generic.IEnumerable<UnityEngine.InputSystem.InputActionRebindingExtensions.Parameter>.GetEnumerator(); // 0x0000000181CC3840-0x0000000181CC3910
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181CC3910-0x0000000181CC39E0
		}
	
		private struct ParameterEnumerator : IEnumerator<Parameter> // TypeDefIndex: 6074
		{
			// Fields
			private InputActionState m_State; // 0x00
			private int m_MapIndex; // 0x08
			private int m_BindingCurrentIndex; // 0x0C
			private int m_BindingEndIndex; // 0x10
			private int m_InteractionCurrentIndex; // 0x14
			private int m_InteractionEndIndex; // 0x18
			private int m_ProcessorCurrentIndex; // 0x1C
			private int m_ProcessorEndIndex; // 0x20
			private InputBinding m_BindingMask; // 0x28
			private Type m_ObjectType; // 0x80
			private string m_ParameterName; // 0x88
			private bool m_MayBeInteraction; // 0x90
			private bool m_MayBeProcessor; // 0x91
			private bool m_MayBeComposite; // 0x92
			private bool m_CurrentBindingIsComposite; // 0x93
			private object m_CurrentObject; // 0x98
			private FieldInfo m_CurrentParameter; // 0xA0
	
			// Properties
			public Parameter Current { get; } // 0x0000000181CC43E0-0x0000000181CC4440 
			object IEnumerator.Current { get; } // 0x0000000181CC40A0-0x0000000181CC4130 
	
			// Constructors
			public ParameterEnumerator(InputActionState state, ParameterOverride parameter, int mapIndex = -1 /* Metadata: 0x00698917 */); // 0x0000000181CC4130-0x0000000181CC43E0
	
			// Methods
			private bool MoveToNextBinding(); // 0x0000000181CC3D00-0x0000000181CC3EA0
			private bool MoveToNextInteraction(); // 0x0000000181CC3EA0-0x0000000181CC3F10
			private bool MoveToNextProcessor(); // 0x0000000181CC3F10-0x0000000181CC3F80
			private bool FindParameter(object instance); // 0x0000000181CC3A70-0x0000000181CC3B90
			public bool MoveNext(); // 0x0000000181CC3B90-0x0000000181CC3D00
			public void Reset(); // 0x0000000181CC3F80-0x0000000181CC40A0
			public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		internal struct ParameterOverride // TypeDefIndex: 6075
		{
			// Fields
			public string objectRegistrationName; // 0x00
			public string parameter; // 0x08
			public InputBinding bindingMask; // 0x10
			public PrimitiveValue value; // 0x68
	
			// Properties
			public Type objectType { get; } // 0x0000000181CC5090-0x0000000181CC5130 
	
			// Constructors
			public ParameterOverride(string parameterName, InputBinding bindingMask, PrimitiveValue value = default); // 0x0000000181CC4F90-0x0000000181CC5090
			public ParameterOverride(string objectRegistrationName, string parameterName, InputBinding bindingMask, PrimitiveValue value = default); // 0x0000000181CC4F00-0x0000000181CC4F90
	
			// Methods
			public static ParameterOverride? Find(InputActionMap actionMap, ref InputBinding binding, string parameterName, string objectRegistrationName); // 0x0000000181CC47C0-0x0000000181CC4AA0
			private static ParameterOverride? Find(ParameterOverride[] overrides, int overrideCount, ref InputBinding binding, string parameterName, string objectRegistrationName); // 0x0000000181CC4440-0x0000000181CC47C0
			private static ParameterOverride? PickMoreSpecificOne(ParameterOverride? first, ParameterOverride? second); // 0x0000000181CC4AA0-0x0000000181CC4F00
		}
	
		public sealed class RebindingOperation : IDisposable // TypeDefIndex: 6076
		{
			// Fields
			public const float kDefaultMagnitudeThreshold = 0.2f; // Metadata: 0x0069891E
			private InputAction m_ActionToRebind; // 0x10
			private InputBinding? m_BindingMask; // 0x18
			private Type m_ControlType; // 0x78
			private InternedString m_ExpectedLayout; // 0x80
			private int m_IncludePathCount; // 0x90
			private string[] m_IncludePaths; // 0x98
			private int m_ExcludePathCount; // 0xA0
			private string[] m_ExcludePaths; // 0xA8
			private int m_TargetBindingIndex; // 0xB0
			private string m_BindingGroupForNewBinding; // 0xB8
			private string m_CancelBinding; // 0xC0
			private float m_MagnitudeThreshold; // 0xC8
			private float[] m_Scores; // 0xD0
			private float[] m_Magnitudes; // 0xD8
			private double m_LastMatchTime; // 0xE0
			private double m_StartTime; // 0xE8
			private float m_Timeout; // 0xF0
			private float m_WaitSecondsAfterMatch; // 0xF4
			private InputEventHandledPolicy m_SavedInputEventHandledPolicy; // 0xF8
			private InputEventHandledPolicy m_TargetInputEventHandledPolicy; // 0xFC
			private InputControlList<InputControl> m_Candidates; // 0x100
			private Action<RebindingOperation> m_OnComplete; // 0x120
			private Action<RebindingOperation> m_OnCancel; // 0x128
			private Action<RebindingOperation> m_OnPotentialMatch; // 0x130
			private Func<InputControl, string> m_OnGeneratePath; // 0x138
			private Func<InputControl, InputEventPtr, float> m_OnComputeScore; // 0x140
			private Action<RebindingOperation, string> m_OnApplyBinding; // 0x148
			private Action<InputEventPtr, InputDevice> m_OnEventDelegate; // 0x150
			private Action m_OnAfterUpdateDelegate; // 0x158
			private InputControlLayout.Cache m_LayoutCache; // 0x160
			private StringBuilder m_PathBuilder; // 0x168
			private Flags m_Flags; // 0x170
			private Dictionary<InputControl, float> m_StartingActuations; // 0x178
	
			// Properties
			public InputAction action { get; } // 0x0000000180377550-0x0000000180377560 
			public InputBinding? bindingMask { get; } // 0x0000000181102800-0x0000000181102840 
			public InputControlList<InputControl> candidates { get; } // 0x0000000181CC9800-0x0000000181CC9820 
			public ReadOnlyArray<float> scores { get; } // 0x0000000181CC98A0-0x0000000181CC98E0 
			public ReadOnlyArray<float> magnitudes { get; } // 0x0000000181CC9860-0x0000000181CC98A0 
			public InputControl selectedControl { get; } // 0x0000000181CC98E0-0x0000000181CC9930 
			public bool started { get; } // 0x0000000181CC9940-0x0000000181CC9950 
			public bool completed { get; } // 0x0000000181CC9820-0x0000000181CC9830 
			public bool canceled { get; } // 0x0000000181CC97F0-0x0000000181CC9800 
			public double startTime { get; } // 0x0000000181CC9930-0x0000000181CC9940 
			public float timeout { get; } // 0x0000000181CC9950-0x0000000181CC9960 
			public string expectedControlType { get; } // 0x0000000181CC9830-0x0000000181CC9860 
	
			// Nested types
			[Flags]
			private enum Flags // TypeDefIndex: 6077
			{
				Started = 1,
				Completed = 2,
				Canceled = 4,
				OnEventHooked = 8,
				OnAfterUpdateHooked = 16,
				DontIgnoreNoisyControls = 64,
				DontGeneralizePathOfSelectedControl = 128,
				AddNewBinding = 256,
				SuppressMatchingEvents = 512
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass32_0 // TypeDefIndex: 6078
			{
				// Fields
				public string group; // 0x10
	
				// Constructors
				public __c__DisplayClass32_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _WithTargetBinding_b__0(InputControlScheme x); // 0x0000000181CE3080-0x0000000181CE30B0
			}
	
			// Constructors
			public RebindingOperation(); // 0x0000000181CC9750-0x0000000181CC97F0
	
			// Methods
			public RebindingOperation WithAction(InputAction action); // 0x0000000181CC83E0-0x0000000181CC85B0
			public RebindingOperation WithMatchingEventsBeingSuppressed(bool value = true /* Metadata: 0x00698918 */); // 0x0000000181CC8E90-0x0000000181CC8F20
			public RebindingOperation WithCancelingThrough(string binding); // 0x0000000181CC8700-0x0000000181CC8780
			public RebindingOperation WithCancelingThrough(InputControl control); // 0x0000000181CC8780-0x0000000181CC8850
			public RebindingOperation WithExpectedControlType(string layoutName); // 0x0000000181CC8CF0-0x0000000181CC8D90
			public RebindingOperation WithExpectedControlType(Type type); // 0x0000000181CC8B70-0x0000000181CC8CF0
			public RebindingOperation WithExpectedControlType<TControl>()
				where TControl : InputControl;
			public RebindingOperation WithTargetBinding(int bindingIndex); // 0x0000000181CC8F50-0x0000000181CC9660
			public RebindingOperation WithBindingMask(InputBinding? bindingMask); // 0x0000000181CC86B0-0x0000000181CC8700
			public RebindingOperation WithBindingGroup(string group); // 0x0000000181CC85B0-0x0000000181CC86B0
			public RebindingOperation WithoutGeneralizingPathOfSelectedControl(); // 0x0000000181CC96D0-0x0000000181CC96E0
			public RebindingOperation WithRebindAddingNewBinding(string group = null); // 0x0000000181CC8F20-0x0000000181CC8F50
			public RebindingOperation WithMagnitudeHavingToBeGreaterThan(float magnitude); // 0x0000000181CC8D90-0x0000000181CC8E90
			public RebindingOperation WithoutIgnoringNoisyControls(); // 0x0000000181CC96E0-0x0000000181CC9750
			public RebindingOperation WithControlsHavingToMatchPath(string path); // 0x0000000181CC89E0-0x0000000181CC8B70
			public RebindingOperation WithControlsExcluding(string path); // 0x0000000181CC8850-0x0000000181CC89E0
			public RebindingOperation WithTimeout(float timeInSeconds); // 0x0000000181CC9660-0x0000000181CC96D0
			public RebindingOperation OnComplete(Action<RebindingOperation> callback); // 0x0000000181CC7100-0x0000000181CC7130
			public RebindingOperation OnCancel(Action<RebindingOperation> callback); // 0x0000000181CC6BE0-0x0000000181CC6C10
			public RebindingOperation OnPotentialMatch(Action<RebindingOperation> callback); // 0x0000000181CC7990-0x0000000181CC79C0
			public RebindingOperation OnGeneratePath(Func<InputControl, string> callback); // 0x0000000181CC7950-0x0000000181CC7980
			public RebindingOperation OnComputeScore(Func<InputControl, InputEventPtr, float> callback); // 0x0000000181CC7130-0x0000000181CC7160
			public RebindingOperation OnApplyBinding(Action<RebindingOperation, string> callback); // 0x0000000181CC6B70-0x0000000181CC6BA0
			public RebindingOperation OnMatchWaitForAnother(float seconds); // 0x0000000181CC7980-0x0000000181CC7990
			public RebindingOperation WithActionEventNotificationsBeingSuppressed(bool value = true /* Metadata: 0x00698919 */); // 0x0000000181CC8370-0x0000000181CC83E0
			public RebindingOperation Start(); // 0x0000000181CC7E40-0x0000000181CC8210
			public void Cancel(); // 0x0000000181CC6540-0x0000000181CC6590
			public void Complete(); // 0x0000000181CC6590-0x0000000181CC65B0
			public void AddCandidate(InputControl control, float score, float magnitude = -1f /* Metadata: 0x0069891A */); // 0x0000000181CC63B0-0x0000000181CC6540
			public void RemoveCandidate(InputControl control); // 0x0000000181CC79C0-0x0000000181CC7AB0
			public void Dispose(); // 0x0000000181CC65B0-0x0000000181CC6640
			~RebindingOperation(); // 0x0000000181CC6640-0x0000000181CC6730
			public RebindingOperation Reset(); // 0x0000000181CC7BF0-0x0000000181CC7D00
			private void HookOnEvent(); // 0x0000000181CC69D0-0x0000000181CC6AB0
			private void UnhookOnEvent(); // 0x0000000181CC82F0-0x0000000181CC8370
			private void OnEvent(InputEventPtr eventPtr, InputDevice device); // 0x0000000181CC7160-0x0000000181CC7950
			private void SortCandidatesByScore(); // 0x0000000181CC7D00-0x0000000181CC7E40
			private static bool HavePathMatch(InputControl control, string[] paths, int pathCount); // 0x0000000181CC6870-0x0000000181CC6900
			private void HookOnAfterUpdate(); // 0x0000000181CC6900-0x0000000181CC69D0
			private void UnhookOnAfterUpdate(); // 0x0000000181CC8280-0x0000000181CC82F0
			private void OnAfterUpdate(); // 0x0000000181CC6AB0-0x0000000181CC6B70
			private void OnComplete(); // 0x0000000181CC6C10-0x0000000181CC7100
			private void OnCancel(); // 0x0000000181CC6BA0-0x0000000181CC6BE0
			private void ResetAfterMatchCompleted(); // 0x0000000181CC7AB0-0x0000000181CC7BF0
			private void ThrowIfRebindInProgress(); // 0x0000000181CC8210-0x0000000181CC8280
			private string GeneratePathForControl(InputControl control); // 0x0000000181CC6730-0x0000000181CC6870
		}
	
		internal class DeferBindingResolutionWrapper : IDisposable // TypeDefIndex: 6079
		{
			// Constructors
			public DeferBindingResolutionWrapper(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void Acquire(); // 0x0000000181CD2930-0x0000000181CD2990
			public void Dispose(); // 0x0000000181CD2990-0x0000000181CD2A30
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass25_0 // TypeDefIndex: 6080
		{
			// Fields
			public ReadOnlyArray<InputBinding> bindings; // 0x10
			public int firstPartIndex; // 0x20
			public string[] partStrings; // 0x28
			public int partCount; // 0x30
	
			// Constructors
			public __c__DisplayClass25_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal string _GetBindingDisplayString_b__0(string fragment); // 0x0000000181CE2F20-0x0000000181CE3080
		}
	
		// Methods
		private static ParameterOverride ExtractParameterOverride<TObject, TValue>(Expression<Func<TObject, TValue>> expr, InputBinding bindingMask = default, PrimitiveValue value = default);
		private static void ApplyParameterOverride(InputActionState state, int mapIndex, ref ParameterOverride[] parameterOverrides, ref int parameterOverridesCount, ParameterOverride parameterOverride); // 0x0000000181CBA560-0x0000000181CBB080
		internal static DeferBindingResolutionWrapper DeferBindingResolution(); // 0x0000000181CBBC30-0x0000000181CBBD00
	
		// Extension methods
		public static PrimitiveValue? GetParameterValue(this InputAction action, string name, InputBinding bindingMask = default); // 0x0000000181CBD300-0x0000000181CBD570
		private static PrimitiveValue? GetParameterValue(this InputAction action, ParameterOverride parameterOverride); // 0x0000000181CBD570-0x0000000181CBD980
		public static PrimitiveValue? GetParameterValue(this InputAction action, string name, int bindingIndex); // 0x0000000181CBD980-0x0000000181CBDC70
		public static TValue? GetParameterValue<TObject, TValue>(this InputAction action, Expression<Func<TObject, TValue>> expr, InputBinding bindingMask = default)
			where TValue : struct;
		public static void ApplyParameterOverride<TObject, TValue>(this InputAction action, Expression<Func<TObject, TValue>> expr, TValue value, InputBinding bindingMask = default)
			where TValue : struct;
		public static void ApplyParameterOverride<TObject, TValue>(this InputActionMap actionMap, Expression<Func<TObject, TValue>> expr, TValue value, InputBinding bindingMask = default)
			where TValue : struct;
		public static void ApplyParameterOverride<TObject, TValue>(this InputActionAsset asset, Expression<Func<TObject, TValue>> expr, TValue value, InputBinding bindingMask = default)
			where TValue : struct;
		public static void ApplyParameterOverride(this InputActionMap actionMap, string name, PrimitiveValue value, InputBinding bindingMask = default); // 0x0000000181CBB360-0x0000000181CBB610
		public static void ApplyParameterOverride(this InputActionAsset asset, string name, PrimitiveValue value, InputBinding bindingMask = default); // 0x0000000181CBB8F0-0x0000000181CBBC30
		public static void ApplyParameterOverride(this InputAction action, string name, PrimitiveValue value, InputBinding bindingMask = default); // 0x0000000181CBB080-0x0000000181CBB360
		public static void ApplyParameterOverride(this InputAction action, string name, PrimitiveValue value, int bindingIndex); // 0x0000000181CBB610-0x0000000181CBB8F0
		public static int GetBindingIndex(this InputAction action, InputBinding bindingMask); // 0x0000000181CBCDB0-0x0000000181CBCF70
		public static int GetBindingIndex(this InputActionMap actionMap, InputBinding bindingMask); // 0x0000000181CBD190-0x0000000181CBD300
		public static int GetBindingIndex(this InputAction action, string group = null, string path = null); // 0x0000000181CBCF70-0x0000000181CBD190
		public static InputBinding? GetBindingForControl(this InputAction action, InputControl control); // 0x0000000181CBC920-0x0000000181CBCBA0
		public static int GetBindingIndexForControl(this InputAction action, InputControl control); // 0x0000000181CBCBA0-0x0000000181CBCDB0
		public static string GetBindingDisplayString(this InputAction action, InputBinding.DisplayStringOptions options =  /* Metadata: 0x0069890F */, string group = null); // 0x0000000181CBC440-0x0000000181CBC640
		public static string GetBindingDisplayString(this InputAction action, InputBinding bindingMask, InputBinding.DisplayStringOptions options =  /* Metadata: 0x00698910 */); // 0x0000000181CBC640-0x0000000181CBC920
		public static string GetBindingDisplayString(this InputAction action, int bindingIndex, InputBinding.DisplayStringOptions options =  /* Metadata: 0x00698911 */); // 0x0000000181CBBD00-0x0000000181CBBD90
		public static string GetBindingDisplayString(this InputAction action, int bindingIndex, out string deviceLayoutName, out string controlPath, InputBinding.DisplayStringOptions options =  /* Metadata: 0x00698912 */); // 0x0000000181CBBD90-0x0000000181CBC440
		public static void ApplyBindingOverride(this InputAction action, string newPath, string group = null, string path = null); // 0x0000000181CB95E0-0x0000000181CB9700
		public static void ApplyBindingOverride(this InputAction action, InputBinding bindingOverride); // 0x0000000181CB98D0-0x0000000181CB9A80
		public static void ApplyBindingOverride(this InputAction action, int bindingIndex, InputBinding bindingOverride); // 0x0000000181CB9A80-0x0000000181CB9B70
		public static void ApplyBindingOverride(this InputAction action, int bindingIndex, string path); // 0x0000000181CB9700-0x0000000181CB98D0
		public static int ApplyBindingOverride(this InputActionMap actionMap, InputBinding bindingOverride); // 0x0000000181CB9B70-0x0000000181CB9D60
		public static void ApplyBindingOverride(this InputActionMap actionMap, int bindingIndex, InputBinding bindingOverride); // 0x0000000181CB9D60-0x0000000181CB9F50
		public static void RemoveBindingOverride(this InputAction action, int bindingIndex); // 0x0000000181CBEF70-0x0000000181CBF0A0
		public static void RemoveBindingOverride(this InputAction action, InputBinding bindingMask); // 0x0000000181CBEE70-0x0000000181CBEF70
		private static void RemoveBindingOverride(this InputActionMap actionMap, InputBinding bindingMask); // 0x0000000181CBF0A0-0x0000000181CBF1A0
		public static void RemoveAllBindingOverrides(this IInputActionCollection2 actions); // 0x0000000181CBE960-0x0000000181CBEC90
		public static void RemoveAllBindingOverrides(this InputAction action); // 0x0000000181CBEC90-0x0000000181CBEE70
		public static void ApplyBindingOverrides(this InputActionMap actionMap, IEnumerable<InputBinding> overrides); // 0x0000000181CBA2A0-0x0000000181CBA560
		public static void RemoveBindingOverrides(this InputActionMap actionMap, IEnumerable<InputBinding> overrides); // 0x0000000181CBF1A0-0x0000000181CBF510
		public static int ApplyBindingOverridesOnMatchingControls(this InputAction action, InputControl control); // 0x0000000181CBA0A0-0x0000000181CBA2A0
		public static int ApplyBindingOverridesOnMatchingControls(this InputActionMap actionMap, InputControl control); // 0x0000000181CB9F50-0x0000000181CBA0A0
		public static string SaveBindingOverridesAsJson(this IInputActionCollection2 actions); // 0x0000000181CBF510-0x0000000181CBF880
		public static string SaveBindingOverridesAsJson(this InputAction action); // 0x0000000181CBF880-0x0000000181CBFC50
		private static void AddBindingOverrideJsonTo(this IInputActionCollection2 actions, InputBinding binding, List<InputActionMap.BindingOverrideJson> list, InputAction action = null); // 0x0000000181CB9380-0x0000000181CB95E0
		public static void LoadBindingOverridesFromJson(this IInputActionCollection2 actions, string json, bool removeExisting = true /* Metadata: 0x00698913 */); // 0x0000000181CBE150-0x0000000181CBE290
		public static void LoadBindingOverridesFromJson(this InputAction action, string json, bool removeExisting = true /* Metadata: 0x00698914 */); // 0x0000000181CBE290-0x0000000181CBE3D0
		private static void LoadBindingOverridesFromJsonInternal(this IInputActionCollection2 actions, string json); // 0x0000000181CBDC70-0x0000000181CBE150
		public static RebindingOperation PerformInteractiveRebinding(this InputAction action, int bindingIndex = -1 /* Metadata: 0x00698915 */); // 0x0000000181CBE3D0-0x0000000181CBE960
	}
}
