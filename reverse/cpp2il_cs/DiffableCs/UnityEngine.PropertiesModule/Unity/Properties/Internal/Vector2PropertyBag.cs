namespace Unity.Properties.Internal;

internal class Vector2PropertyBag : ContainerPropertyBag<Vector2>
{
	private class XProperty : Property<Vector2, Single>
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

		public virtual float GetValue(ref Vector2 container) { }

		public virtual void SetValue(ref Vector2 container, float value) { }

	}

	private class YProperty : Property<Vector2, Single>
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

		public virtual float GetValue(ref Vector2 container) { }

		public virtual void SetValue(ref Vector2 container, float value) { }

	}


	public Vector2PropertyBag() { }

}

