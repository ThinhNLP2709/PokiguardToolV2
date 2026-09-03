/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class DebugUI // TypeDefIndex: 5449
	{
		// Nested types
		public class Container : Widget, IContainer // TypeDefIndex: 5450
		{
			// Fields
			private const string k_IDToken = "#"; // Metadata: 0x0066155C
			[CompilerGenerated]
			private ObservableList<Widget> _children_k__BackingField; // 0x50
			private const string k_AlternateRowColorClassName = "debug-window-row-alternate"; // Metadata: 0x0066155E
			[CompilerGenerated]
			private bool _alternateRowColors_k__BackingField; // 0x58
	
			// Properties
			internal bool hideDisplayName { get; } // 0x0000000181E391F0-0x0000000181E39250 
			public ObservableList<Widget> children { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
			public bool alternateRowColors { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181424750-0x0000000181424760 0x0000000181424790-0x00000001814247A0
			public override Panel panel { get; internal set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181E39250-0x0000000181E392F0
	
			// Constructors
			public Container(); // 0x0000000181E38F00-0x0000000181E38F90
			public Container(string id); // 0x0000000181E39150-0x0000000181E391F0
			public Container(string displayName, ObservableList<Widget> children); // 0x0000000181E38F90-0x0000000181E39150
	
			// Methods
			internal override void GenerateQueryPath(); // 0x0000000181E38D80-0x0000000181E38E00
			protected virtual void OnItemAdded(ObservableList<Widget> sender, ListChangedEventArgs<Widget> e); // 0x0000000181E38E00-0x0000000181E38E80
			protected virtual void OnItemRemoved(ObservableList<Widget> sender, ListChangedEventArgs<Widget> e); // 0x0000000181E38E80-0x0000000181E38F00
		}
	
		public class Foldout : Container, IValueField // TypeDefIndex: 5451
		{
			// Fields
			private bool m_Opened; // 0x60
			public bool isHeader; // 0x61
			public List<ContextMenuItem> contextMenuItems; // 0x68
			[CompilerGenerated]
			private string _documentationUrl_k__BackingField; // 0x70
			private bool m_Dirty; // 0x78
			private string[] m_ColumnLabels; // 0x80
			private string[] m_ColumnTooltips; // 0x88
			private List<GUIContent> m_RowContents; // 0x90
	
			// Properties
			public bool isReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
			public bool opened { get; set; } // 0x000000018033D4F0-0x000000018033D500 0x0000000181E496A0-0x0000000181E496B0
			public string documentationUrl { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
			public string[] columnLabels { get; set; } // 0x000000018033D4A0-0x000000018033D4B0 0x0000000181E49B60-0x0000000181E49B90
			public string[] columnTooltips { get; set; } // 0x000000018038B8A0-0x000000018038B8B0 0x0000000181E49B90-0x0000000181E49BC0
			internal List<GUIContent> rowContents { get; } // 0x0000000181E498A0-0x0000000181E49B60 
	
			// Nested types
			public struct ContextMenuItem // TypeDefIndex: 5452
			{
				// Fields
				public string displayName; // 0x00
				public Action action; // 0x08
			}
	
			// Constructors
			public Foldout(); // 0x0000000181E49730-0x0000000181E497B0
			public Foldout(string displayName, ObservableList<Widget> children, string[] columnLabels = null, string[] columnTooltips = null); // 0x0000000181E497B0-0x0000000181E498A0
	
			// Methods
			public bool GetValue(); // 0x000000018033D4F0-0x000000018033D500
			object UnityEngine.Rendering.DebugUI.IValueField.GetValue(); // 0x0000000181E49700-0x0000000181E49730
			[Obsolete("This method is no longer used. #from(6000.5)")]
			public void SetValue(object value); // 0x0000000181E496B0-0x0000000181E49700
			[Obsolete("This method is no longer used. #from(6000.5)")]
			public object ValidateValue(object value); // 0x0000000180A68C50-0x0000000180A68C60
			public void SetValue(bool value); // 0x0000000181E496A0-0x0000000181E496B0
		}
	
		public class HBox : Container // TypeDefIndex: 5453
		{
			// Constructors
			public HBox(); // 0x0000000181E4AC90-0x0000000181E4ACE0
		}
	
		public class VBox : Container // TypeDefIndex: 5454
		{
			// Constructors
			public VBox(); // 0x0000000181E4FC70-0x0000000181E4FCC0
		}
	
		public class Table : Container // TypeDefIndex: 5455
		{
			// Fields
			public bool isReadOnly; // 0x60
			public bool displayRowNames; // 0x61
			private bool[] m_Header; // 0x68
	
			// Properties
			[Obsolete("This property is no longer used. #from(6000.5)")]
			public bool[] VisibleColumns { get; } // 0x0000000181E4E200-0x0000000181E4E460 
	
			// Nested types
			public class Row : Container // TypeDefIndex: 5456
			{
				// Fields
				[CompilerGenerated]
				private bool _opened_k__BackingField; // 0x60
	
				// Properties
				[Obsolete("This class no longer inherits from Foldout, but from Container. This field is kept for compatibility but it no longer does anything. #from(6000.5)")]
				public bool opened { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4F0-0x000000018033D500 0x000000018033EA80-0x000000018033EA90
	
				// Constructors
				public Row(); // 0x0000000181E4C610-0x0000000181E4C660
			}
	
			// Constructors
			public Table(); // 0x0000000181E4E1B0-0x0000000181E4E200
	
			// Methods
			[Obsolete("This method is no longer used. #from(6000.5)")]
			public void SetColumnVisibility(int index, bool visible); // 0x0000000181E4E160-0x0000000181E4E1B0
			[Obsolete("This method is no longer used. #from(6000.5)")]
			public bool GetColumnVisibility(int index); // 0x0000000181E4DFF0-0x0000000181E4E040
			protected override void OnItemAdded(ObservableList<Widget> sender, ListChangedEventArgs<Widget> e); // 0x0000000181E4E040-0x0000000181E4E0D0
			protected override void OnItemRemoved(ObservableList<Widget> sender, ListChangedEventArgs<Widget> e); // 0x0000000181E4E0D0-0x0000000181E4E160
		}
	
		public abstract class Field<T> : Widget, IValueField, ISupportsLegacyStateHandling // TypeDefIndex: 5457
		{
			// Fields
			[CompilerGenerated]
			private Func<T> _getter_k__BackingField;
			[CompilerGenerated]
			private Action<T> _setter_k__BackingField;
			public Action<Field<T>, T> onValueChanged;
			internal static Action<string, T, T> onWidgetValueChangedAnalytic;
	
			// Properties
			public Func<T> getter { [CompilerGenerated] get; [CompilerGenerated] set; }
			public Action<T> setter { [CompilerGenerated] get; [CompilerGenerated] set; }
	
			// Constructors
			protected Field();
	
			// Methods
			object UnityEngine.Rendering.DebugUI.IValueField.ValidateValue(object value);
			public virtual T ValidateValue(T value);
			object UnityEngine.Rendering.DebugUI.IValueField.GetValue();
			public T GetValue();
			public void SetValue(object value);
			public virtual void SetValue(T value);
			bool ISupportsLegacyStateHandling.RequiresLegacyStateHandling();
			[CompilerGenerated]
			internal static bool _UnityEngine.Rendering.ISupportsLegacyStateHandling.RequiresLegacyStateHandling_g__FieldsHaveISerializedDebugDisplaySettings_16_0(object obj);
		}
	
		public class BoolField : Field<bool> // TypeDefIndex: 5458
		{
			// Constructors
			public BoolField(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		public class HistoryBoolField : BoolField // TypeDefIndex: 5459
		{
			// Fields
			[CompilerGenerated]
			private List<Widget> _childWidgets_k__BackingField; // 0x68
			[CompilerGenerated]
			private Func<bool>[] _historyGetter_k__BackingField; // 0x70
	
			// Properties
			internal List<Widget> childWidgets { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
			public Func<bool>[] historyGetter { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
			public int historyDepth { get; } // 0x0000000181E4ADA0-0x0000000181E4ADB0 
	
			// Constructors
			public HistoryBoolField(); // 0x0000000181E4AD20-0x0000000181E4ADA0
	
			// Methods
			public bool GetHistoryValue(int historyIndex); // 0x0000000181E4ACE0-0x0000000181E4AD20
		}
	
		public class IntField : Field<int> // TypeDefIndex: 5460
		{
			// Fields
			public Func<int> min; // 0x68
			public Func<int> max; // 0x70
			public int incStep; // 0x78
			[Obsolete("Use incStepMult instead #from(6000.5) (UnityUpgradable) -> incStepMult")]
			public int intStepMult; // 0x7C
			public int incStepMult; // 0x80
	
			// Constructors
			public IntField(); // 0x0000000181E4B040-0x0000000181E4B060
	
			// Methods
			public override int ValidateValue(int value); // 0x0000000181E4AFD0-0x0000000181E4B040
			internal override void OnDecrement(bool fast); // 0x0000000181E4AED0-0x0000000181E4AF50
			internal override void OnIncrement(bool fast); // 0x0000000181E4AF50-0x0000000181E4AFD0
		}
	
		public class UIntField : Field<uint> // TypeDefIndex: 5461
		{
			// Fields
			public Func<uint> min; // 0x68
			public Func<uint> max; // 0x70
			public uint incStep; // 0x78
			[Obsolete("Use incStepMult instead #from(6000.5) (UnityUpgradable) -> incStepMult")]
			public uint intStepMult; // 0x7C
			public uint incStepMult; // 0x80
	
			// Constructors
			public UIntField(); // 0x0000000181E4B040-0x0000000181E4B060
	
			// Methods
			public override uint ValidateValue(uint value); // 0x0000000181E4FBC0-0x0000000181E4FC70
			internal override void OnDecrement(bool fast); // 0x0000000181E4FAC0-0x0000000181E4FB40
			internal override void OnIncrement(bool fast); // 0x0000000181E4FB40-0x0000000181E4FBC0
		}
	
		public class FloatField : Field<float> // TypeDefIndex: 5462
		{
			// Fields
			public Func<float> min; // 0x68
			public Func<float> max; // 0x70
			public float incStep; // 0x78
			public float incStepMult; // 0x7C
			public int decimals; // 0x80
	
			// Constructors
			public FloatField(); // 0x0000000181E49680-0x0000000181E496A0
	
			// Methods
			public override float ValidateValue(float value); // 0x0000000181E49620-0x0000000181E49680
		}
	
		public class RenderingLayerField : Field<RenderingLayerMask>, IContainer // TypeDefIndex: 5463
		{
			// Fields
			private static readonly NameAndTooltip s_RenderingLayerColors; // 0x00
			private string[] m_RenderingLayersNames; // 0x68
			private int m_DefinedRenderingLayersCount; // 0x70
			private ObservableList<Widget> m_RenderingLayersColors; // 0x78
			[CompilerGenerated]
			private Func<int, Vector4> _getRenderingLayerColor_k__BackingField; // 0x80
			[CompilerGenerated]
			private Action<Vector4, int> _setRenderingLayerColor_k__BackingField; // 0x88
	
			// Properties
			private int maxRenderingLayerCount { get; } // 0x0000000181E4C560-0x0000000181E4C5A0 
			public string[] renderingLayersNames { get; } // 0x0000000181E4C5A0-0x0000000181E4C610 
			public ObservableList<Widget> children { get; } // 0x0000000181E4C4F0-0x0000000181E4C560 
			public Func<int, Vector4> getRenderingLayerColor { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4A0-0x000000018033D4B0 0x000000018033EA30-0x000000018033EA40
			public Action<Vector4, int> setRenderingLayerColor { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018038B8A0-0x000000018038B8B0 0x0000000180664140-0x0000000180664160
	
			// Nested types
			[CompilerGenerated]
			private sealed class __c__DisplayClass5_0 // TypeDefIndex: 5464
			{
				// Fields
				public int index; // 0x10
				public RenderingLayerField __4__this; // 0x18
	
				// Constructors
				public __c__DisplayClass5_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal Color _Resize_b__0(); // 0x0000000181E4F2A0-0x0000000181E4F320
				internal void _Resize_b__1(Color value); // 0x0000000181E4F320-0x0000000181E4F3A0
			}
	
			// Constructors
			public RenderingLayerField(); // 0x0000000181E4C410-0x0000000181E4C4F0
			static RenderingLayerField(); // 0x0000000181E4C370-0x0000000181E4C410
	
			// Methods
			private void Resize(); // 0x0000000181E4BEB0-0x0000000181E4C370
			internal override void GenerateQueryPath(); // 0x0000000181E4BD90-0x0000000181E4BEB0
		}
	
		public abstract class EnumField<T> : Field<T> // TypeDefIndex: 5465
		{
			// Fields
			public GUIContent[] enumNames;
			private int[] m_EnumValues;
			private static readonly Regex s_NicifyRegEx;
	
			// Properties
			public int[] enumValues { get; set; }
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 5466
			{
				// Fields
				public static readonly __c<T> __9;
				public static Func<FieldInfo, bool> __9__6_0;
	
				// Constructors
				static __c();
				public __c();
	
				// Methods
				internal bool _AutoFillFromType_b__6_0(FieldInfo fieldInfo);
			}
	
			// Constructors
			protected EnumField();
			static EnumField();
	
			// Methods
			protected void AutoFillFromType(Type enumType, bool removeZeroElement = false /* Metadata: 0x00661579 */);
		}
	
		public class EnumField : EnumField<int> // TypeDefIndex: 5467
		{
			// Fields
			internal int[] quickSeparators; // 0x78
			private int[] m_Indexes; // 0x80
			[CompilerGenerated]
			private Func<int> _getIndex_k__BackingField; // 0x88
			[CompilerGenerated]
			private Action<int> _setIndex_k__BackingField; // 0x90
			private Type m_Type; // 0x98
	
			// Properties
			internal int[] indexes { get; } // 0x0000000181E494B0-0x0000000181E49540 
			public Func<int> getIndex { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018038B8A0-0x000000018038B8B0 0x0000000180664140-0x0000000180664160
			public Action<int> setIndex { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x0000000180664160-0x0000000180664180
			public int currentIndex { get; set; } // 0x0000000181E49480-0x0000000181E494B0 0x0000000181E495F0-0x0000000181E49620
			public Type autoEnum { set; } // 0x0000000181E49540-0x0000000181E495F0
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 5468
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Func<GUIContent, string> __9__18_0; // 0x08
	
				// Constructors
				static __c(); // 0x0000000181E4F870-0x0000000181E4F8E0
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal string _InitQuickSeparators_b__18_0(GUIContent x); // 0x0000000181E4E4C0-0x0000000181E4E540
			}
	
			// Constructors
			public EnumField(); // 0x0000000181E49430-0x0000000181E49480
	
			// Methods
			internal void InitQuickSeparators(); // 0x0000000181E490C0-0x0000000181E49300
			public override void SetValue(int value); // 0x0000000181E49300-0x0000000181E49430
		}
	
		public class ObjectPopupField : Field<UnityEngine.Object> // TypeDefIndex: 5469
		{
			// Fields
			[CompilerGenerated]
			private Func<IEnumerable<UnityEngine.Object>> _getObjects_k__BackingField; // 0x68
	
			// Properties
			public Func<IEnumerable<UnityEngine.Object>> getObjects { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
	
			// Constructors
			public ObjectPopupField(); // 0x0000000180A6DF30-0x0000000180A6DF40
		}
	
		public class CameraSelector : ObjectPopupField // TypeDefIndex: 5470
		{
			// Fields
			private Camera[] m_CamerasArray; // 0x70
			private List<Camera> m_Cameras; // 0x78
	
			// Properties
			private IEnumerable<Camera> cameras { get; } // 0x0000000181E38AD0-0x0000000181E38CC0 
	
			// Constructors
			public CameraSelector(); // 0x0000000181E389E0-0x0000000181E38AD0
	
			// Methods
			[CompilerGenerated]
			private IEnumerable<UnityEngine.Object> _.ctor_b__0_0(); // 0x0000000181E389D0-0x0000000181E389E0
		}
	
		public class HistoryEnumField : EnumField // TypeDefIndex: 5471
		{
			// Fields
			[CompilerGenerated]
			private List<Widget> _childWidgets_k__BackingField; // 0xA0
			[CompilerGenerated]
			private Func<int>[] _historyIndexGetter_k__BackingField; // 0xA8
	
			// Properties
			internal List<Widget> childWidgets { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
			public Func<int>[] historyIndexGetter { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D510-0x000000018033D520 0x000000018033EAB0-0x000000018033EAD0
			public int historyDepth { get; } // 0x0000000181E4AEB0-0x0000000181E4AED0 
	
			// Constructors
			public HistoryEnumField(); // 0x0000000181E4AE00-0x0000000181E4AEB0
	
			// Methods
			public int GetHistoryValue(int historyIndex); // 0x0000000181E4ADB0-0x0000000181E4AE00
		}
	
		public class BitField : EnumField<Enum> // TypeDefIndex: 5472
		{
			// Fields
			private Type m_EnumType; // 0x78
	
			// Properties
			public Type enumType { get; set; } // 0x000000018033D4E0-0x000000018033D4F0 0x0000000181E383E0-0x0000000181E38510
	
			// Constructors
			public BitField(); // 0x0000000181E38390-0x0000000181E383E0
		}
	
		public class ColorField : Field<Color> // TypeDefIndex: 5473
		{
			// Fields
			public bool hdr; // 0x68
			public bool showAlpha; // 0x69
			public bool showPicker; // 0x6A
			public float incStep; // 0x6C
			public float incStepMult; // 0x70
			public int decimals; // 0x74
	
			// Constructors
			public ColorField(); // 0x0000000181E38D50-0x0000000181E38D80
	
			// Methods
			public override Color ValidateValue(Color value); // 0x0000000181E38CC0-0x0000000181E38D50
		}
	
		public abstract class VectorField<T> : Field<T> // TypeDefIndex: 5474
			where T : struct
		{
			// Fields
			public float incStep;
			public float incStepMult;
			public int decimals;
	
			// Constructors
			protected VectorField();
		}
	
		public class Vector2Field : VectorField<Vector2> // TypeDefIndex: 5475
		{
			// Constructors
			public Vector2Field(); // 0x0000000181E4FE00-0x0000000181E4FE10
		}
	
		public class Vector3Field : VectorField<Vector3> // TypeDefIndex: 5476
		{
			// Constructors
			public Vector3Field(); // 0x0000000181E4FE00-0x0000000181E4FE10
		}
	
		public class Vector4Field : VectorField<Vector4> // TypeDefIndex: 5477
		{
			// Constructors
			public Vector4Field(); // 0x0000000181E4FE00-0x0000000181E4FE10
		}
	
		public class ObjectField : Field<UnityEngine.Object> // TypeDefIndex: 5478
		{
			// Fields
			public Type type; // 0x68
	
			// Constructors
			public ObjectField(); // 0x0000000181E4B540-0x0000000181E4B5A0
		}
	
		public class ObjectListField : Field<UnityEngine.Object[]> // TypeDefIndex: 5479
		{
			// Fields
			public Type type; // 0x68
			internal bool trimTrailingNulls; // 0x70
	
			// Constructors
			public ObjectListField(); // 0x0000000181E4B540-0x0000000181E4B5A0
		}
	
		public class MessageBox : Widget // TypeDefIndex: 5480
		{
			// Fields
			public Style style; // 0x50
			public Func<string> messageCallback; // 0x58
	
			// Properties
			public string message { get; } // 0x0000000181E4B520-0x0000000181E4B540 
	
			// Nested types
			public enum Style // TypeDefIndex: 5481
			{
				None = 0,
				Info = 1,
				Warning = 2,
				Error = 3
			}
	
			// Constructors
			public MessageBox(); // 0x0000000181E4B510-0x0000000181E4B520
		}
	
		public class RuntimeDebugShadersMessageBox : MessageBox // TypeDefIndex: 5482
		{
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 5483
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Func<bool> __9__0_0; // 0x08
	
				// Constructors
				static __c(); // 0x0000000181E4F800-0x0000000181E4F870
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _.ctor_b__0_0(); // 0x0000000181E4E810-0x0000000181E4E8A0
			}
	
			// Constructors
			public RuntimeDebugShadersMessageBox(); // 0x0000000181E4C660-0x0000000181E4C780
		}
	
		public class Panel : IContainer, IComparable<Panel> // TypeDefIndex: 5484
		{
			// Fields
			[CompilerGenerated]
			private Flags _flags_k__BackingField; // 0x10
			[CompilerGenerated]
			private string _displayName_k__BackingField; // 0x18
			[CompilerGenerated]
			private int _groupIndex_k__BackingField; // 0x20
			[CompilerGenerated]
			private ObservableList<Widget> _children_k__BackingField; // 0x28
			[CompilerGenerated]
			private Action<Panel> onSetDirty; // 0x30
	
			// Properties
			public Flags flags { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
			public string displayName { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
			public int groupIndex { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
			public string queryPath { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			public bool isEditorOnly { get; } // 0x0000000181E4BAA0-0x0000000181E4BAB0 
			public bool isRuntimeOnly { get; } // 0x0000000181E4BB10-0x0000000181E4BB20 
			public bool isInactiveInEditor { get; } // 0x0000000181E4BAB0-0x0000000181E4BB10 
			[Obsolete("This is no longer used. #from(6000.5)")]
			public bool editorForceUpdate { get; } // 0x00000001802E7840-0x00000001802E7850 
			public ObservableList<Widget> children { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
	
			// Events
			public event Action<Panel> onSetDirty {
				add; // 0x0000000181E4B9E0-0x0000000181E4BAA0
				remove; // 0x0000000181E4BB20-0x0000000181E4BBE0
			}
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 5485
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Comparison<Widget> __9__29_0; // 0x08
				public static Action<Panel> __9__29_1; // 0x10
	
				// Constructors
				static __c(); // 0x0000000181E4F8E0-0x0000000181E4F950
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _.ctor_b__29_0(Widget widget, Widget widget1); // 0x0000000181E4E8A0-0x0000000181E4E8E0
				internal void _.ctor_b__29_1(Panel _p0_); // 0x00000001802E76C0-0x00000001802E76D0
			}
	
			// Constructors
			public Panel(); // 0x0000000181E4B750-0x0000000181E4B9E0
	
			// Methods
			protected virtual void OnItemAdded(ObservableList<Widget> sender, ListChangedEventArgs<Widget> e); // 0x0000000181E4B5A0-0x0000000181E4B610
			protected virtual void OnItemRemoved(ObservableList<Widget> sender, ListChangedEventArgs<Widget> e); // 0x0000000181E4B610-0x0000000181E4B680
			public void SetDirty(); // 0x0000000181E4B680-0x0000000181E4B720
			int System.IComparable<UnityEngine.Rendering.DebugUI.Panel>.CompareTo(Panel other); // 0x0000000181E4B720-0x0000000181E4B750
			internal bool TryFindChild<T>(string childDisplayName, out ref T foundChild)
				where T : Widget;
		}
	
		[Flags]
		public enum Flags // TypeDefIndex: 5486
		{
			None = 0,
			EditorOnly = 2,
			RuntimeOnly = 4,
			EditorForceUpdate = 8,
			FrequentlyUsed = 16
		}
	
		public enum Context // TypeDefIndex: 5487
		{
			Invalid = -1,
			Editor = 0,
			Runtime = 1,
			RuntimePersistent = 2,
			Count = 3
		}
	
		public abstract class Widget // TypeDefIndex: 5488
		{
			// Fields
			[CompilerGenerated]
			private int _order_k__BackingField; // 0x10
			protected Panel m_Panel; // 0x18
			protected IContainer m_Parent; // 0x20
			[CompilerGenerated]
			private Flags _flags_k__BackingField; // 0x28
			[CompilerGenerated]
			private string _displayName_k__BackingField; // 0x30
			[CompilerGenerated]
			private string _tooltip_k__BackingField; // 0x38
			[CompilerGenerated]
			private string _queryPath_k__BackingField; // 0x40
			public Func<bool> isHiddenCallback; // 0x48
	
			// Properties
			public int order { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
			public virtual Panel panel { get; internal set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
			public virtual IContainer parent { get; internal set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
			public Flags flags { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
			public string displayName { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
			public string tooltip { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
			public string queryPath { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
			public bool isEditorOnly { get; } // 0x0000000181E527D0-0x0000000181E527E0 
			public bool isRuntimeOnly { get; } // 0x0000000181E52860-0x0000000181E52870 
			public bool isInactiveInEditor { get; } // 0x0000000181E52800-0x0000000181E52860 
			public bool isHidden { get; } // 0x0000000181E527E0-0x0000000181E52800 
			public NameAndTooltip nameAndTooltip { set; } // 0x0000000181E52870-0x0000000181E52A00
	
			// Nested types
			public struct NameAndTooltip // TypeDefIndex: 5489
			{
				// Fields
				public string name; // 0x00
				public string tooltip; // 0x08
			}
	
			// Constructors
			protected Widget(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal virtual void OnIncrement(bool fast); // 0x00000001802E76C0-0x00000001802E76D0
			internal virtual void OnDecrement(bool fast); // 0x00000001802E76C0-0x00000001802E76D0
			internal virtual void GenerateQueryPath(); // 0x0000000181E52720-0x0000000181E527D0
		}
	
		public interface IContainer // TypeDefIndex: 5490
		{
			// Properties
			ObservableList<Widget> children { get; }
			string displayName { get; set; }
			string queryPath { get; }
		}
	
		[Obsolete("This interface is no longer used. #from(6000.5)")]
		public interface IValueField // TypeDefIndex: 5491
		{
			// Methods
			[Obsolete("This method is no longer used. #from(6000.5)")]
			object GetValue();
			[Obsolete("This method is no longer used. #from(6000.5)")]
			void SetValue(object value);
			[Obsolete("This method is no longer used. #from(6000.5)")]
			object ValidateValue(object value);
		}
	
		public class Button : Widget // TypeDefIndex: 5492
		{
			// Fields
			[CompilerGenerated]
			private Action _action_k__BackingField; // 0x50
	
			// Properties
			public Action action { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
	
			// Constructors
			public Button(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		public class Value : Widget // TypeDefIndex: 5493
		{
			// Fields
			[CompilerGenerated]
			private bool _isHeader_k__BackingField; // 0x50
			[CompilerGenerated]
			private Func<object> _getter_k__BackingField; // 0x58
			public float refreshRate; // 0x60
			public string formatString; // 0x68
	
			// Properties
			public bool isHeader { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377920-0x0000000180377930 0x00000001803780E0-0x00000001803780F0
			public Func<object> getter { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
	
			// Constructors
			public Value(); // 0x0000000181E4FDB0-0x0000000181E4FE00
	
			// Methods
			public virtual object GetValue(); // 0x0000000181E42540-0x0000000181E42570
			public virtual string FormatString(object value); // 0x0000000181E4FD50-0x0000000181E4FDB0
		}
	
		public class ProgressBarValue : Value // TypeDefIndex: 5494
		{
			// Fields
			public float min; // 0x70
			public float max; // 0x74
	
			// Constructors
			public ProgressBarValue(); // 0x0000000181E4BCB0-0x0000000181E4BD10
	
			// Methods
			public override string FormatString(object value); // 0x0000000181E4BBE0-0x0000000181E4BCA0
			[CompilerGenerated]
			internal static float _FormatString_g__Remap01_2_0(float v, float x0, float y0); // 0x0000000181E4BCA0-0x0000000181E4BCB0
		}
	
		public class ValueTuple : Widget // TypeDefIndex: 5495
		{
			// Fields
			internal const int k_LabelWidthEditor = 280; // Metadata: 0x00661588
			internal const int k_LabelWidthRuntime = 340; // Metadata: 0x0066158A
			[CompilerGenerated]
			private bool _isHeader_k__BackingField; // 0x50
			public Value[] values; // 0x58
			public int pinnedElementIndex; // 0x60
	
			// Properties
			public bool isHeader { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377920-0x0000000180377930 0x00000001803780E0-0x00000001803780F0
			public int numElements { get; } // 0x0000000181E4FCE0-0x0000000181E4FD00 
			public float refreshRate { get; } // 0x0000000181E4FD00-0x0000000181E4FD50 
	
			// Constructors
			public ValueTuple(); // 0x0000000181E4FCD0-0x0000000181E4FCE0
	
			// Methods
			internal static int GetLabelWidth(Context ctx); // 0x0000000181E4FCC0-0x0000000181E4FCD0
		}
	
		[Obsolete("Mask field is not longer supported. Please use a BitField or implement your own Widget. #from(6000.2)")]
		public class MaskField : EnumField<uint> // TypeDefIndex: 5496
		{
			// Constructors
			public MaskField(); // 0x0000000181E4B4C0-0x0000000181E4B510
	
			// Methods
			public void Fill(string[] names); // 0x0000000181E4B060-0x0000000181E4B420
			public override void SetValue(uint value); // 0x0000000181E4B420-0x0000000181E4B4C0
		}
	
		// Constructors
		public DebugUI(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
