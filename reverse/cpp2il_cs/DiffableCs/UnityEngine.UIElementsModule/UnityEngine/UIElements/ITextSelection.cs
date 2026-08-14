namespace UnityEngine.UIElements;

public interface ITextSelection
{

	public Color cursorColor
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public int cursorIndex
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Vector2 cursorPosition
	{
		 get { } //Length: 0
	}

	internal float cursorWidth
	{
		internal get { } //Length: 0
	}

	public bool doubleClickSelectsWord
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public bool isSelectable
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	internal float lineHeightAtCursorPosition
	{
		internal get { } //Length: 0
	}

	public bool selectAllOnFocus
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public bool selectAllOnMouseUp
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public int selectIndex
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Color selectionColor
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public bool tripleClickSelectsLine
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Color get_cursorColor() { }

	public int get_cursorIndex() { }

	public Vector2 get_cursorPosition() { }

	internal float get_cursorWidth() { }

	public bool get_doubleClickSelectsWord() { }

	public bool get_isSelectable() { }

	internal float get_lineHeightAtCursorPosition() { }

	public bool get_selectAllOnFocus() { }

	public bool get_selectAllOnMouseUp() { }

	public int get_selectIndex() { }

	public Color get_selectionColor() { }

	public bool get_tripleClickSelectsLine() { }

	public bool HasSelection() { }

	public void SelectAll() { }

	public void SelectNone() { }

	public void set_cursorColor(Color value) { }

	public void set_cursorIndex(int value) { }

	public void set_doubleClickSelectsWord(bool value) { }

	public void set_isSelectable(bool value) { }

	public void set_selectAllOnFocus(bool value) { }

	public void set_selectAllOnMouseUp(bool value) { }

	public void set_selectIndex(int value) { }

	public void set_selectionColor(Color value) { }

	public void set_tripleClickSelectsLine(bool value) { }

}

