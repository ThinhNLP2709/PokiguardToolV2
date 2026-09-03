/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 43: UnityEngine.InputForUIModule.dll - Assembly: UnityEngine.InputForUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15251-15301

namespace UnityEngine.InputForUI
{
	[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
	internal struct Event : IEventProperties // TypeDefIndex: 15257
	{
		// Fields
		public static readonly Type[] TypesWithState; // 0x00
		private Type _type; // 0x00
		private object _managedEvent; // 0x08
		private KeyEvent _keyEvent; // 0x10
		private PointerEvent _pointerEvent; // 0x10
		private TextInputEvent _textInputEvent; // 0x10
		private CommandEvent _commandEvent; // 0x10
		private NavigationEvent _navigationEvent; // 0x10
	
		// Properties
		public Type type { get; } // 0x0000000180732D10-0x0000000180732D20 
		private IEventProperties asObject { get; } // 0x00000001822A5680-0x00000001822A56E0 
		public EventSource eventSource { get; } // 0x00000001822A5860-0x00000001822A58C0 
		public EventModifiers eventModifiers { get; } // 0x00000001822A5800-0x00000001822A5860 
		public KeyEvent asKeyEvent { get; } // 0x00000001822A5570-0x00000001822A5600 
		public PointerEvent asPointerEvent { get; } // 0x00000001822A56E0-0x00000001822A5790 
		public TextInputEvent asTextInputEvent { get; } // 0x00000001822A5790-0x00000001822A5800 
		public IMECompositionEvent asIMECompositionEvent { get; } // 0x00000001822A54C0-0x00000001822A5570 
		public CommandEvent asCommandEvent { get; } // 0x00000001822A5450-0x00000001822A54C0 
		public NavigationEvent asNavigationEvent { get; } // 0x00000001822A5600-0x00000001822A5680 
	
		// Nested types
		public enum Type // TypeDefIndex: 15258
		{
			Invalid = 0,
			KeyEvent = 1,
			PointerEvent = 2,
			TextInputEvent = 3,
			IMECompositionEvent = 4,
			CommandEvent = 5,
			NavigationEvent = 6
		}
	
		private interface IMapFn<TOutputType> // TypeDefIndex: 15259
		{
			// Methods
			TOutputType Map<TEventType>(ref ref TEventType ev)
				where TEventType : IEventProperties;
		}
	
		private struct MapAsObject : IMapFn<IEventProperties> // TypeDefIndex: 15260
		{
			// Methods
			public IEventProperties Map<TEventType>(ref ref TEventType ev)
				where TEventType : IEventProperties;
		}
	
		private struct MapAsEventSource : IMapFn<EventSource> // TypeDefIndex: 15261
		{
			// Methods
			public EventSource Map<TEventType>(ref ref TEventType ev)
				where TEventType : IEventProperties;
		}
	
		private struct MapAsEventModifiers : IMapFn<EventModifiers> // TypeDefIndex: 15262
		{
			// Methods
			public EventModifiers Map<TEventType>(ref ref TEventType ev)
				where TEventType : IEventProperties;
		}
	
		// Constructors
		static Event(); // 0x00000001822A53C0-0x00000001822A5450
	
		// Methods
		internal static int CompareType(Event a, Event b); // 0x00000001822A4DC0-0x00000001822A4F00
		private void Ensure(Type t); // 0x00000001822A4F00-0x00000001822A4F80
		public override string ToString(); // 0x00000001822A51B0-0x00000001822A53C0
		public static Event From(KeyEvent keyEvent); // 0x00000001822A50E0-0x00000001822A5130
		public static Event From(PointerEvent pointerEvent); // 0x00000001822A5080-0x00000001822A50E0
		public static Event From(TextInputEvent textInputEvent); // 0x00000001822A5170-0x00000001822A51B0
		public static Event From(IMECompositionEvent imeCompositionEvent); // 0x00000001822A4F80-0x00000001822A5030
		public static Event From(CommandEvent commandEvent); // 0x00000001822A5130-0x00000001822A5170
		public static Event From(NavigationEvent navigationEvent); // 0x00000001822A5030-0x00000001822A5080
		private TOutputType Map<TOutputType, TMapType>(TMapType fn)
			where TMapType : IMapFn<TOutputType>;
		private TOutputType Map<TOutputType, TMapType>()
			where TMapType : IMapFn<TOutputType>, new();
	}
}
