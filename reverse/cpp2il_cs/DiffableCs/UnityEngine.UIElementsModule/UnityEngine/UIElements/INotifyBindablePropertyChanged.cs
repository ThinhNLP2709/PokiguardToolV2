namespace UnityEngine.UIElements;

public interface INotifyBindablePropertyChanged
{

	public event EventHandler<BindablePropertyChangedEventArgs> propertyChanged
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	[CompilerGenerated]
	public void add_propertyChanged(EventHandler<BindablePropertyChangedEventArgs> value) { }

	[CompilerGenerated]
	public void remove_propertyChanged(EventHandler<BindablePropertyChangedEventArgs> value) { }

}

