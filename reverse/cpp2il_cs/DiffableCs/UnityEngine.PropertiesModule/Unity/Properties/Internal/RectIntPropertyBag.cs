namespace Unity.Properties.Internal;

internal class RectIntPropertyBag : ContainerPropertyBag<RectInt>
{
	private class HeightProperty : Property<RectInt, Int32>
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

		public virtual int GetValue(ref RectInt container) { }

		public virtual void SetValue(ref RectInt container, int value) { }

	}

	private class WidthProperty : Property<RectInt, Int32>
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

		public virtual int GetValue(ref RectInt container) { }

		public virtual void SetValue(ref RectInt container, int value) { }

	}

	private class XProperty : Property<RectInt, Int32>
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

		public virtual int GetValue(ref RectInt container) { }

		public virtual void SetValue(ref RectInt container, int value) { }

	}

	private class YProperty : Property<RectInt, Int32>
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

		public virtual int GetValue(ref RectInt container) { }

		public virtual void SetValue(ref RectInt container, int value) { }

	}


	public RectIntPropertyBag() { }

}

