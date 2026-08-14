namespace UnityEngine.Rendering;

public class DebugUI
{
	internal class BitField : EnumField<Enum>
	{
		private Type m_EnumType; //Field offset: 0x70

		public Type enumType
		{
			 get { } //Length: 5
			 set { } //Length: 88
		}

		public BitField() { }

		public Type get_enumType() { }

		public void set_enumType(Type value) { }

	}

	internal class BoolField : Field<Boolean>
	{

		public BoolField() { }

	}

	internal class Button : Widget
	{
		[CompilerGenerated]
		private Action <action>k__BackingField; //Field offset: 0x48

		public Action action
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public Button() { }

		[CompilerGenerated]
		public Action get_action() { }

		[CompilerGenerated]
		public void set_action(Action value) { }

	}

	internal class ColorField : Field<Color>
	{
		public bool hdr; //Field offset: 0x60
		public bool showAlpha; //Field offset: 0x61
		public bool showPicker; //Field offset: 0x62
		public float incStep; //Field offset: 0x64
		public float incStepMult; //Field offset: 0x68
		public int decimals; //Field offset: 0x6C

		public ColorField() { }

		public virtual Color ValidateValue(Color value) { }

	}

	internal class Container : Widget, IContainer
	{
		private const string k_IDToken = "#"; //Field offset: 0x0
		[CompilerGenerated]
		private ObservableList<Widget> <children>k__BackingField; //Field offset: 0x48

		public private override ObservableList<Widget> children
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			private set { } //Length: 13
		}

		internal bool hideDisplayName
		{
			internal get { } //Length: 94
		}

		public internal virtual Panel panel
		{
			 get { } //Length: 5
			internal set { } //Length: 214
		}

		public Container() { }

		public Container(string id) { }

		public Container(string displayName, ObservableList<Widget> children) { }

		internal virtual void GenerateQueryPath() { }

		[CompilerGenerated]
		public override ObservableList<Widget> get_children() { }

		internal bool get_hideDisplayName() { }

		public virtual Panel get_panel() { }

		public virtual int GetHashCode() { }

		protected override void OnItemAdded(ObservableList<Widget> sender, ListChangedEventArgs<Widget> e) { }

		protected override void OnItemRemoved(ObservableList<Widget> sender, ListChangedEventArgs<Widget> e) { }

		[CompilerGenerated]
		private void set_children(ObservableList<Widget> value) { }

		internal virtual void set_panel(Panel value) { }

	}

	internal class EnumField : EnumField<Int32>
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static Func<GUIContent, String> <>9__17_0; //Field offset: 0x8

			private static <>c() { }

			public <>c() { }

			internal string <InitQuickSeparators>b__17_0(GUIContent x) { }

		}

		internal Int32[] quickSeparators; //Field offset: 0x70
		private Int32[] m_Indexes; //Field offset: 0x78
		[CompilerGenerated]
		private Func<Int32> <getIndex>k__BackingField; //Field offset: 0x80
		[CompilerGenerated]
		private Action<Int32> <setIndex>k__BackingField; //Field offset: 0x88

		public Type autoEnum
		{
			 set { } //Length: 82
		}

		public int currentIndex
		{
			 get { } //Length: 40
			 set { } //Length: 40
		}

		public Func<Int32> getIndex
		{
			[CompilerGenerated]
			 get { } //Length: 8
			[CompilerGenerated]
			 set { } //Length: 16
		}

		internal Int32[] indexes
		{
			internal get { } //Length: 125
		}

		public Action<Int32> setIndex
		{
			[CompilerGenerated]
			 get { } //Length: 8
			[CompilerGenerated]
			 set { } //Length: 19
		}

		public EnumField() { }

		public int get_currentIndex() { }

		[CompilerGenerated]
		public Func<Int32> get_getIndex() { }

		internal Int32[] get_indexes() { }

		[CompilerGenerated]
		public Action<Int32> get_setIndex() { }

		internal void InitQuickSeparators() { }

		public void set_autoEnum(Type value) { }

		public void set_currentIndex(int value) { }

		[CompilerGenerated]
		public void set_getIndex(Func<Int32> value) { }

		[CompilerGenerated]
		public void set_setIndex(Action<Int32> value) { }

		public virtual void SetValue(int value) { }

	}

	internal abstract class EnumField : Field<T>
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c<T> <>9; //Field offset: 0x0
			public static Func<FieldInfo, Boolean> <>9__6_0; //Field offset: 0x0

			private static <>c() { }

			public <>c() { }

			internal bool <AutoFillFromType>b__6_0(FieldInfo fieldInfo) { }

		}

		private static Regex s_NicifyRegEx; //Field offset: 0x0
		private Int32[] m_EnumValues; //Field offset: 0x0
		public GUIContent[] enumNames; //Field offset: 0x0

		public Int32[] enumValues
		{
			 get { } //Length: 5
			 set { } //Length: 363
		}

		private static EnumField`1() { }

		protected EnumField`1() { }

		protected void AutoFillFromType(Type enumType) { }

		public Int32[] get_enumValues() { }

		public void set_enumValues(Int32[] value) { }

	}

	internal abstract class Field : Widget, IValueField
	{
		[CompilerGenerated]
		private Func<T> <getter>k__BackingField; //Field offset: 0x0
		[CompilerGenerated]
		private Action<T> <setter>k__BackingField; //Field offset: 0x0
		public Action<Field`1<T>, T> onValueChanged; //Field offset: 0x0

		public Func<T> getter
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public Action<T> setter
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		protected Field`1() { }

		[CompilerGenerated]
		public Func<T> get_getter() { }

		[CompilerGenerated]
		public Action<T> get_setter() { }

		public T GetValue() { }

		[CompilerGenerated]
		public void set_getter(Func<T> value) { }

		[CompilerGenerated]
		public void set_setter(Action<T> value) { }

		public override void SetValue(object value) { }

		public override void SetValue(T value) { }

		private override object UnityEngine.Rendering.DebugUI.IValueField.GetValue() { }

		private override object UnityEngine.Rendering.DebugUI.IValueField.ValidateValue(object value) { }

		public override T ValidateValue(T value) { }

	}

	[Flags]
	internal enum Flags
	{
		None = 0,
		EditorOnly = 2,
		RuntimeOnly = 4,
		EditorForceUpdate = 8,
		FrequentlyUsed = 16,
	}

	internal class FloatField : Field<Single>
	{
		public Func<Single> min; //Field offset: 0x60
		public Func<Single> max; //Field offset: 0x68
		public float incStep; //Field offset: 0x70
		public float incStepMult; //Field offset: 0x74
		public int decimals; //Field offset: 0x78

		public FloatField() { }

		public virtual float ValidateValue(float value) { }

	}

	internal class Foldout : Container, IValueField
	{
		internal struct ContextMenuItem
		{
			public string displayName; //Field offset: 0x0
			public Action action; //Field offset: 0x8

		}

		public bool opened; //Field offset: 0x50
		public bool isHeader; //Field offset: 0x51
		public List<ContextMenuItem> contextMenuItems; //Field offset: 0x58
		private bool m_Dirty; //Field offset: 0x60
		private String[] m_ColumnLabels; //Field offset: 0x68
		private String[] m_ColumnTooltips; //Field offset: 0x70
		private List<GUIContent> m_RowContents; //Field offset: 0x78

		public String[] columnLabels
		{
			 get { } //Length: 5
			 set { } //Length: 32
		}

		public String[] columnTooltips
		{
			 get { } //Length: 5
			 set { } //Length: 32
		}

		public bool isReadOnly
		{
			 get { } //Length: 3
		}

		internal List<GUIContent> rowContents
		{
			internal get { } //Length: 667
		}

		public Foldout() { }

		public Foldout(string displayName, ObservableList<Widget> children, String[] columnLabels = null, String[] columnTooltips = null) { }

		public String[] get_columnLabels() { }

		public String[] get_columnTooltips() { }

		public bool get_isReadOnly() { }

		internal List<GUIContent> get_rowContents() { }

		public bool GetValue() { }

		public void set_columnLabels(String[] value) { }

		public void set_columnTooltips(String[] value) { }

		public override void SetValue(object value) { }

		public void SetValue(bool value) { }

		private override object UnityEngine.Rendering.DebugUI.IValueField.GetValue() { }

		public override object ValidateValue(object value) { }

	}

	internal class HBox : Container
	{

		public HBox() { }

	}

	internal class HistoryBoolField : BoolField
	{
		[CompilerGenerated]
		private Func<Boolean>[] <historyGetter>k__BackingField; //Field offset: 0x60

		public int historyDepth
		{
			 get { } //Length: 14
		}

		public Func<Boolean>[] historyGetter
		{
			[CompilerGenerated]
			 get { } //Length: 694
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public HistoryBoolField() { }

		public int get_historyDepth() { }

		[CompilerGenerated]
		public Func<Boolean>[] get_historyGetter() { }

		public bool GetHistoryValue(int historyIndex) { }

		[CompilerGenerated]
		public void set_historyGetter(Func<Boolean>[] value) { }

	}

	internal class HistoryEnumField : EnumField
	{
		[CompilerGenerated]
		private Func<Int32>[] <historyIndexGetter>k__BackingField; //Field offset: 0x90

		public int historyDepth
		{
			 get { } //Length: 17
		}

		public Func<Int32>[] historyIndexGetter
		{
			[CompilerGenerated]
			 get { } //Length: 8
			[CompilerGenerated]
			 set { } //Length: 19
		}

		public HistoryEnumField() { }

		public int get_historyDepth() { }

		[CompilerGenerated]
		public Func<Int32>[] get_historyIndexGetter() { }

		public int GetHistoryValue(int historyIndex) { }

		[CompilerGenerated]
		public void set_historyIndexGetter(Func<Int32>[] value) { }

	}

	internal interface IContainer
	{

		public ObservableList<Widget> children
		{
			 get { } //Length: 0
		}

		public string displayName
		{
			 get { } //Length: 0
			 set { } //Length: 0
		}

		public string queryPath
		{
			 get { } //Length: 0
		}

		public ObservableList<Widget> get_children() { }

		public string get_displayName() { }

		public string get_queryPath() { }

		public void set_displayName(string value) { }

	}

	internal class IntField : Field<Int32>
	{
		public Func<Int32> min; //Field offset: 0x60
		public Func<Int32> max; //Field offset: 0x68
		public int incStep; //Field offset: 0x70
		public int intStepMult; //Field offset: 0x74

		public IntField() { }

		public virtual int ValidateValue(int value) { }

	}

	internal interface IValueField
	{

		public object GetValue() { }

		public void SetValue(object value) { }

		public object ValidateValue(object value) { }

	}

	internal class MaskField : EnumField<UInt32>
	{

		public MaskField() { }

		public void Fill(String[] names) { }

		public virtual void SetValue(uint value) { }

	}

	internal class MessageBox : Widget
	{
		internal enum Style
		{
			Info = 0,
			Warning = 1,
			Error = 2,
		}

		public Style style; //Field offset: 0x48
		public Func<String> messageCallback; //Field offset: 0x50

		public string message
		{
			 get { } //Length: 31
		}

		public MessageBox() { }

		public string get_message() { }

	}

	internal class ObjectField : Field<Object>
	{
		public Type type; //Field offset: 0x60

		public ObjectField() { }

	}

	internal class ObjectListField : Field<Object[]>
	{
		public Type type; //Field offset: 0x60

		public ObjectListField() { }

	}

	internal class ObjectPopupField : Field<Object>
	{
		[CompilerGenerated]
		private Func<IEnumerable`1<Object>> <getObjects>k__BackingField; //Field offset: 0x60

		public Func<IEnumerable`1<Object>> getObjects
		{
			[CompilerGenerated]
			 get { } //Length: 694
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public ObjectPopupField() { }

		[CompilerGenerated]
		public Func<IEnumerable`1<Object>> get_getObjects() { }

		[CompilerGenerated]
		public void set_getObjects(Func<IEnumerable`1<Object>> value) { }

	}

	internal class Panel : IContainer, IComparable<Panel>
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static Action<Panel> <>9__29_0; //Field offset: 0x8

			private static <>c() { }

			public <>c() { }

			internal void <.ctor>b__29_0(Panel <p0>) { }

		}

		[CompilerGenerated]
		private Flags <flags>k__BackingField; //Field offset: 0x10
		[CompilerGenerated]
		private string <displayName>k__BackingField; //Field offset: 0x18
		[CompilerGenerated]
		private int <groupIndex>k__BackingField; //Field offset: 0x20
		[CompilerGenerated]
		private ObservableList<Widget> <children>k__BackingField; //Field offset: 0x28
		[CompilerGenerated]
		private Action<Panel> onSetDirty; //Field offset: 0x30

		public event Action<Panel> onSetDirty
		{
			[CompilerGenerated]
			 add { } //Length: 172
			[CompilerGenerated]
			 remove { } //Length: 172
		}

		public private override ObservableList<Widget> children
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			private set { } //Length: 13
		}

		public override string displayName
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public bool editorForceUpdate
		{
			 get { } //Length: 8
		}

		public Flags flags
		{
			[CompilerGenerated]
			 get { } //Length: 4
			[CompilerGenerated]
			 set { } //Length: 4
		}

		public int groupIndex
		{
			[CompilerGenerated]
			 get { } //Length: 4
			[CompilerGenerated]
			 set { } //Length: 4
		}

		public bool isEditorOnly
		{
			 get { } //Length: 8
		}

		public bool isInactiveInEditor
		{
			 get { } //Length: 87
		}

		public bool isRuntimeOnly
		{
			 get { } //Length: 8
		}

		public override string queryPath
		{
			 get { } //Length: 5
		}

		public Panel() { }

		[CompilerGenerated]
		public void add_onSetDirty(Action<Panel> value) { }

		[CompilerGenerated]
		public override ObservableList<Widget> get_children() { }

		[CompilerGenerated]
		public override string get_displayName() { }

		public bool get_editorForceUpdate() { }

		[CompilerGenerated]
		public Flags get_flags() { }

		[CompilerGenerated]
		public int get_groupIndex() { }

		public bool get_isEditorOnly() { }

		public bool get_isInactiveInEditor() { }

		public bool get_isRuntimeOnly() { }

		public override string get_queryPath() { }

		public virtual int GetHashCode() { }

		protected override void OnItemAdded(ObservableList<Widget> sender, ListChangedEventArgs<Widget> e) { }

		protected override void OnItemRemoved(ObservableList<Widget> sender, ListChangedEventArgs<Widget> e) { }

		[CompilerGenerated]
		public void remove_onSetDirty(Action<Panel> value) { }

		[CompilerGenerated]
		private void set_children(ObservableList<Widget> value) { }

		[CompilerGenerated]
		public override void set_displayName(string value) { }

		[CompilerGenerated]
		public void set_flags(Flags value) { }

		[CompilerGenerated]
		public void set_groupIndex(int value) { }

		public void SetDirty() { }

		private override int System.IComparable<UnityEngine.Rendering.DebugUI.Panel>.CompareTo(Panel other) { }

	}

	internal class ProgressBarValue : Value
	{
		public float min; //Field offset: 0x60
		public float max; //Field offset: 0x64

		public ProgressBarValue() { }

		[CompilerGenerated]
		internal static float <FormatString>g__Remap01|2_0(float v, float x0, float y0) { }

		public virtual string FormatString(object value) { }

	}

	internal class RuntimeDebugShadersMessageBox : MessageBox
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static Func<Boolean> <>9__0_0; //Field offset: 0x8

			private static <>c() { }

			public <>c() { }

			internal bool <.ctor>b__0_0() { }

		}


		public RuntimeDebugShadersMessageBox() { }

	}

	internal class Table : Container
	{
		internal class Row : Foldout
		{

			public Row() { }

		}

		private static GUIStyle columnHeaderStyle; //Field offset: 0x0
		public bool isReadOnly; //Field offset: 0x50
		private Boolean[] m_Header; //Field offset: 0x58

		public Boolean[] VisibleColumns
		{
			 get { } //Length: 653
		}

		private static Table() { }

		public Table() { }

		public Boolean[] get_VisibleColumns() { }

		public bool GetColumnVisibility(int index) { }

		protected virtual void OnItemAdded(ObservableList<Widget> sender, ListChangedEventArgs<Widget> e) { }

		protected virtual void OnItemRemoved(ObservableList<Widget> sender, ListChangedEventArgs<Widget> e) { }

		public void SetColumnVisibility(int index, bool visible) { }

	}

	internal class UIntField : Field<UInt32>
	{
		public Func<UInt32> min; //Field offset: 0x60
		public Func<UInt32> max; //Field offset: 0x68
		public uint incStep; //Field offset: 0x70
		public uint intStepMult; //Field offset: 0x74

		public UIntField() { }

		public virtual uint ValidateValue(uint value) { }

	}

	internal class Value : Widget
	{
		[CompilerGenerated]
		private Func<Object> <getter>k__BackingField; //Field offset: 0x48
		public float refreshRate; //Field offset: 0x50
		public string formatString; //Field offset: 0x58

		public Func<Object> getter
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public Value() { }

		public override string FormatString(object value) { }

		[CompilerGenerated]
		public Func<Object> get_getter() { }

		public override object GetValue() { }

		[CompilerGenerated]
		public void set_getter(Func<Object> value) { }

	}

	internal class ValueTuple : Widget
	{
		public Value[] values; //Field offset: 0x48
		public int pinnedElementIndex; //Field offset: 0x50

		public int numElements
		{
			 get { } //Length: 26
		}

		public float refreshRate
		{
			 get { } //Length: 83
		}

		public ValueTuple() { }

		public int get_numElements() { }

		public float get_refreshRate() { }

	}

	internal class VBox : Container
	{

		public VBox() { }

	}

	internal class Vector2Field : Field<Vector2>
	{
		public float incStep; //Field offset: 0x60
		public float incStepMult; //Field offset: 0x64
		public int decimals; //Field offset: 0x68

		public Vector2Field() { }

	}

	internal class Vector3Field : Field<Vector3>
	{
		public float incStep; //Field offset: 0x60
		public float incStepMult; //Field offset: 0x64
		public int decimals; //Field offset: 0x68

		public Vector3Field() { }

	}

	internal class Vector4Field : Field<Vector4>
	{
		public float incStep; //Field offset: 0x60
		public float incStepMult; //Field offset: 0x64
		public int decimals; //Field offset: 0x68

		public Vector4Field() { }

	}

	internal abstract class Widget
	{
		internal struct NameAndTooltip
		{
			public string name; //Field offset: 0x0
			public string tooltip; //Field offset: 0x8

		}

		protected Panel m_Panel; //Field offset: 0x10
		protected IContainer m_Parent; //Field offset: 0x18
		[CompilerGenerated]
		private Flags <flags>k__BackingField; //Field offset: 0x20
		[CompilerGenerated]
		private string <displayName>k__BackingField; //Field offset: 0x28
		[CompilerGenerated]
		private string <tooltip>k__BackingField; //Field offset: 0x30
		[CompilerGenerated]
		private string <queryPath>k__BackingField; //Field offset: 0x38
		public Func<Boolean> isHiddenCallback; //Field offset: 0x40

		public override string displayName
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		public Flags flags
		{
			[CompilerGenerated]
			 get { } //Length: 4
			[CompilerGenerated]
			 set { } //Length: 4
		}

		public bool isEditorOnly
		{
			 get { } //Length: 8
		}

		public bool isHidden
		{
			 get { } //Length: 27
		}

		public bool isInactiveInEditor
		{
			 get { } //Length: 87
		}

		public bool isRuntimeOnly
		{
			 get { } //Length: 9
		}

		public NameAndTooltip nameAndTooltip
		{
			 set { } //Length: 222
		}

		public internal override Panel panel
		{
			 get { } //Length: 5
			internal set { } //Length: 13
		}

		public internal override IContainer parent
		{
			 get { } //Length: 5
			internal set { } //Length: 13
		}

		public private override string queryPath
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			private set { } //Length: 13
		}

		public string tooltip
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 13
		}

		protected Widget() { }

		internal override void GenerateQueryPath() { }

		[CompilerGenerated]
		public override string get_displayName() { }

		[CompilerGenerated]
		public Flags get_flags() { }

		public bool get_isEditorOnly() { }

		public bool get_isHidden() { }

		public bool get_isInactiveInEditor() { }

		public bool get_isRuntimeOnly() { }

		public override Panel get_panel() { }

		public override IContainer get_parent() { }

		[CompilerGenerated]
		public override string get_queryPath() { }

		[CompilerGenerated]
		public string get_tooltip() { }

		public virtual int GetHashCode() { }

		[CompilerGenerated]
		public override void set_displayName(string value) { }

		[CompilerGenerated]
		public void set_flags(Flags value) { }

		public void set_nameAndTooltip(NameAndTooltip value) { }

		internal override void set_panel(Panel value) { }

		internal override void set_parent(IContainer value) { }

		[CompilerGenerated]
		private void set_queryPath(string value) { }

		[CompilerGenerated]
		public void set_tooltip(string value) { }

	}


	public DebugUI() { }

}

