namespace Unity.Properties.Internal;

internal class RectPropertyBag : ContainerPropertyBag<Rect>
{
	private class HeightProperty : Property<Rect, Single>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public HeightProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual float GetValue(ref Rect container) { }

		public virtual void SetValue(ref Rect container, float value) { }

	}

	private class WidthProperty : Property<Rect, Single>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public WidthProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual float GetValue(ref Rect container) { }

		public virtual void SetValue(ref Rect container, float value) { }

	}

	private class XProperty : Property<Rect, Single>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public XProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual float GetValue(ref Rect container) { }

		public virtual void SetValue(ref Rect container, float value) { }

	}

	private class YProperty : Property<Rect, Single>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public YProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual float GetValue(ref Rect container) { }

		public virtual void SetValue(ref Rect container, float value) { }

	}


	public RectPropertyBag() { }

}

