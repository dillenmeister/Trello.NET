using System;
using System.ComponentModel;
using TrelloNet.Internal;

namespace TrelloNet
{
	[TypeConverter(typeof(ColorConverter))]
	public class Color
	{
		// Known colors:
		public static readonly Color Green = new Color("green");
		public static readonly Color Yellow = new Color("yellow");
		public static readonly Color Orange = new Color("orange");
		public static readonly Color Red = new Color("red");
		public static readonly Color Purple = new Color("purple");
		public static readonly Color Blue = new Color("blue");
		public static readonly Color Pink = new Color("pink");
		public static readonly Color Sky = new Color("sky");
		public static readonly Color Lime = new Color("lime");
		public static readonly Color Black = new Color("black");

		public string ColorName { get; private set; }

		public Color(string colorName)
		{
			if (colorName == null) throw new ArgumentNullException("colorName");

			ColorName = colorName.ToLower();
		}

		public override string ToString()
		{
			return ColorName;
		}

		protected bool Equals(Color other)
		{
			return string.Equals(ColorName, other.ColorName);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((Color)obj);
		}

		public override int GetHashCode()
		{
			return (ColorName != null ? ColorName.GetHashCode() : 0);
		}

		public static bool operator ==(Color left, Color right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Color left, Color right)
		{
			return !Equals(left, right);
		}
	}
}