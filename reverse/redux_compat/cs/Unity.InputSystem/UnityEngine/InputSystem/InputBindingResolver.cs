/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	internal struct InputBindingResolver : IDisposable // TypeDefIndex: 6113
	{
		// Fields
		public int totalProcessorCount; // 0x00
		public int totalCompositeCount; // 0x04
		public int totalInteractionCount; // 0x08
		public InputActionMap[] maps; // 0x10
		public InputControl[] controls; // 0x18
		public InputActionState.UnmanagedMemory memory; // 0x20
		public IInputInteraction[] interactions; // 0xA0
		public InputProcessor[] processors; // 0xA8
		public InputBindingComposite[] composites; // 0xB0
		public InputBinding? bindingMask; // 0xB8
		private bool m_IsControlOnlyResolve; // 0x118
		private List<NameAndParameters> m_Parameters; // 0x120
	
		// Properties
		public int totalMapCount { get; } // 0x0000000180377930-0x0000000180377940 
		public int totalActionCount { get; } // 0x00000001803B5DE0-0x00000001803B5DF0 
		public int totalBindingCount { get; } // 0x000000018033D0F0-0x000000018033D100 
		public int totalControlCount { get; } // 0x000000018047EDE0-0x000000018047EDF0 
	
		// Methods
		public void Dispose(); // 0x0000000181D06FF0-0x0000000181D07000
		public void StartWithPreviousResolve(InputActionState state, bool isFullResolve); // 0x0000000181D07300-0x0000000181D074C0
		public void AddActionMap(InputActionMap actionMap); // 0x0000000181D04D10-0x0000000181D06810
		private int InstantiateWithParameters<TType>(TypeTable registrations, string namesAndParameters, ref ref TType[] array, ref int count, InputActionMap actionMap, ref InputBinding binding);
		private static InputBindingComposite InstantiateBindingComposite(ref InputBinding binding, InputActionMap actionMap); // 0x0000000181D07000-0x0000000181D07300
		private static void ApplyParameters(ReadOnlyArray<NamedValue> parameters, object instance, InputActionMap actionMap, ref InputBinding binding, string objectRegistrationName, string namesAndParameters); // 0x0000000181D06810-0x0000000181D06DA0
		private static int AssignCompositePartIndex(object composite, string name, ref int currentCompositePartCount); // 0x0000000181D06DA0-0x0000000181D06FF0
	}
}
