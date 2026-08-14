namespace Unity.Properties.Internal;

internal class Vector2IntPropertyBag : ContainerPropertyBag<Vector2Int>
{
	private class XProperty : Property<Vector2Int, Int32>
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

		public virtual int GetValue(ref Vector2Int container) { }

		public virtual void SetValue(ref Vector2Int container, int value) { }

	}

	private class YProperty : Property<Vector2Int, Int32>
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

		public virtual int GetValue(ref Vector2Int container) { }

		public virtual void SetValue(ref Vector2Int container, int value) { }

	}


	public Vector2IntPropertyBag() { }

}

