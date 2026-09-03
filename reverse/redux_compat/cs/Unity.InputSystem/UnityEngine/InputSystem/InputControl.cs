/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[DebuggerDisplay("{DebuggerDisplay(),nq}")]
	public abstract class InputControl // TypeDefIndex: 6132
	{
		// Fields
		protected internal InputStateBlock m_StateBlock; // 0x10
		internal InternedString m_Name; // 0x20
		internal string m_Path; // 0x30
		internal string m_DisplayName; // 0x38
		internal string m_DisplayNameFromLayout; // 0x40
		internal string m_ShortDisplayName; // 0x48
		internal string m_ShortDisplayNameFromLayout; // 0x50
		internal InternedString m_Layout; // 0x58
		internal InternedString m_Variants; // 0x68
		internal InputDevice m_Device; // 0x78
		internal InputControl m_Parent; // 0x80
		internal int m_UsageCount; // 0x88
		internal int m_UsageStartIndex; // 0x8C
		internal int m_AliasCount; // 0x90
		internal int m_AliasStartIndex; // 0x94
		internal int m_ChildCount; // 0x98
		internal int m_ChildStartIndex; // 0x9C
		internal ControlFlags m_ControlFlags; // 0xA0
		internal bool m_CachedValueIsStale; // 0xA4
		internal bool m_UnprocessedCachedValueIsStale; // 0xA5
		internal PrimitiveValue m_DefaultState; // 0xA8
		internal PrimitiveValue m_MinValue; // 0xB8
		internal PrimitiveValue m_MaxValue; // 0xC8
		internal FourCC m_OptimizedControlDataType; // 0xD8
	
		// Properties
		public string name { get; } // 0x0000000181D0E1E0-0x0000000181D0E200 
		public string displayName { get; protected set; } // 0x0000000181D0E0F0-0x0000000181D0E160 0x000000018033E850-0x000000018033E860
		public string shortDisplayName { get; protected set; } // 0x0000000181D0E380-0x0000000181D0E3E0 0x00000001803780C0-0x00000001803780D0
		public string path { get; } // 0x0000000181D0E250-0x0000000181D0E360 
		public string layout { get; } // 0x0000000181D0E1C0-0x0000000181D0E1E0 
		public string variants { get; } // 0x0000000181D0E4B0-0x0000000181D0E4D0 
		public InputDevice device { get; } // 0x000000018033D4E0-0x000000018033D4F0 
		public InputControl parent { get; } // 0x000000018033D4A0-0x000000018033D4B0 
		public ReadOnlyArray<InputControl> children { get; } // 0x0000000181D0E040-0x0000000181D0E090 
		public ReadOnlyArray<InternedString> usages { get; } // 0x0000000181D0E450-0x0000000181D0E4A0 
		public ReadOnlyArray<InternedString> aliases { get; } // 0x0000000181D0DFF0-0x0000000181D0E040 
		public InputStateBlock stateBlock { get; } // 0x00000001802E65B0-0x00000001802E65C0 
		public bool noisy { get; internal set; } // 0x0000000181D0E240-0x0000000181D0E250 0x0000000181D0E550-0x0000000181D0E660
		public bool synthetic { get; internal set; } // 0x0000000181D0E440-0x0000000181D0E450 0x0000000181D0E660-0x0000000181D0E680
		public InputControl this[string path] { get => default; } // 0x0000000181D0DF40-0x0000000181D0DFF0 
		public abstract Type valueType { get; }
		public abstract int valueSizeInBytes { get; }
		public float magnitude { get; } // 0x0000000181D0D3B0-0x0000000181D0D3F0 
		protected internal unsafe void* currentStatePtr { get; } // 0x0000000181D0E090-0x0000000181D0E0B0 
		protected internal unsafe void* previousFrameStatePtr { get; } // 0x0000000181D0E360-0x0000000181D0E380 
		protected internal unsafe void* defaultStatePtr { get; } // 0x0000000181D0E0B0-0x0000000181D0E0F0 
		protected internal unsafe void* noiseMaskPtr { get; } // 0x0000000181D0E200-0x0000000181D0E240 
		protected internal uint stateOffsetRelativeToDeviceRoot { get; } // 0x0000000181D0E3E0-0x0000000181D0E440 
		public FourCC optimizedControlDataType { get; } // 0x0000000181846100-0x0000000181846110 
		internal bool isSetupFinished { get; set; } // 0x0000000181D0E1B0-0x0000000181D0E1C0 0x0000000181D0E530-0x0000000181D0E550
		internal bool isButton { get; set; } // 0x0000000181D0E190-0x0000000181D0E1A0 0x0000000181D0E4F0-0x0000000181D0E510
		internal bool isConfigUpToDate { get; set; } // 0x0000000181D0E1A0-0x0000000181D0E1B0 0x0000000181D0E510-0x0000000181D0E530
		internal bool dontReset { get; set; } // 0x0000000181D0E160-0x0000000181D0E170 0x0000000181D0E4D0-0x0000000181D0E4F0
		internal bool usesStateFromOtherControl { get; set; } // 0x0000000181D0E4A0-0x0000000181D0E4B0 0x0000000181D0E680-0x0000000181D0E6A0
		internal bool hasDefaultState { get; } // 0x0000000181D0E170-0x0000000181D0E190 
	
		// Nested types
		[Flags]
		internal enum ControlFlags // TypeDefIndex: 6133
		{
			ConfigUpToDate = 1,
			IsNoisy = 2,
			IsSynthetic = 4,
			IsButton = 8,
			DontReset = 16,
			SetupFinished = 32,
			UsesStateFromOtherControl = 64
		}
	
		// Constructors
		protected InputControl(); // 0x0000000181D0DEE0-0x0000000181D0DF40
	
		// Methods
		public override string ToString(); // 0x0000000181D0DCE0-0x0000000181D0DD50
		private string DebuggerDisplay(); // 0x0000000181D0CEC0-0x0000000181D0CFE0
		public float EvaluateMagnitude(); // 0x0000000181D0D3B0-0x0000000181D0D3F0
		public virtual unsafe float EvaluateMagnitude(void* statePtr); // 0x0000000181D048F0-0x0000000181D04900
		public abstract unsafe object ReadValueFromBufferAsObject(void* buffer, int bufferSize);
		public abstract unsafe object ReadValueFromStateAsObject(void* statePtr);
		public abstract unsafe void ReadValueFromStateIntoBuffer(void* statePtr, void* bufferPtr, int bufferSize);
		public virtual unsafe void WriteValueFromBufferIntoState(void* bufferPtr, int bufferSize, void* statePtr); // 0x0000000181D0DE00-0x0000000181D0DE70
		public virtual unsafe void WriteValueFromObjectIntoState(object value, void* statePtr); // 0x0000000181D0DE70-0x0000000181D0DEE0
		public abstract unsafe bool CompareValue(void* firstStatePtr, void* secondStatePtr);
		public InputControl TryGetChildControl(string path); // 0x0000000181D0DD50-0x0000000181D0DE00
		public TControl TryGetChildControl<TControl>(string path)
			where TControl : InputControl;
		public InputControl GetChildControl(string path); // 0x0000000181D0D3F0-0x0000000181D0D590
		public TControl GetChildControl<TControl>(string path)
			where TControl : InputControl;
		protected virtual void FinishSetup(); // 0x00000001802E76C0-0x00000001802E76D0
		protected void RefreshConfigurationIfNeeded(); // 0x0000000181D0DA00-0x0000000181D0DA40
		protected virtual void RefreshConfiguration(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual FourCC CalculateOptimizedControlDataType(); // 0x00000001802E7860-0x00000001802E7870
		public void ApplyParameterChanges(); // 0x0000000181D0CBF0-0x0000000181D0CCB0
		private void SetOptimizedControlDataType(); // 0x0000000181D0DC50-0x0000000181D0DCE0
		internal void SetOptimizedControlDataTypeRecursively(); // 0x0000000181D0DA40-0x0000000181D0DC50
		[Conditional("UNITY_EDITOR")]
		internal void EnsureOptimizationTypeHasNotChanged(); // 0x0000000181D0CFE0-0x0000000181D0D3B0
		internal void CallFinishSetupRecursive(); // 0x0000000181D0CDC0-0x0000000181D0CEC0
		internal string MakeChildPath(string path); // 0x0000000181D0D7B0-0x0000000181D0D850
		internal void BakeOffsetIntoStateBlockRecursive(uint offset); // 0x0000000181D0CCB0-0x0000000181D0CDC0
		internal int GetDeviceIndex(); // 0x0000000181D0D590-0x0000000181D0D700
		internal bool IsValueConsideredPressed(float value); // 0x0000000181D0D700-0x0000000181D0D7B0
		internal virtual void AddProcessor(object first); // 0x00000001802E76C0-0x00000001802E76D0
		internal void MarkAsStale(); // 0x0000000181D0D9F0-0x0000000181D0DA00
		internal void MarkAsStaleRecursively(); // 0x0000000181D0D850-0x0000000181D0D9F0
	}
}
