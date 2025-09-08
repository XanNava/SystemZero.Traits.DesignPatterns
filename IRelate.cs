

namespace Levels.Core {
	using UnityEngine;

	public interface IRelate<Key, Value> {
		public Value GetFor(Key key);
	}

	public static class Key_Extends {
		public static IRelate<Key, Value> Interface_IKeyed<Key, Value>(this IRelate<Key, Value> src)
			=> src;

		public static Value GetFor<Key, Value>(this IRelate<Key, Value> src, Key key)
			=> src.GetFor(key);
	}
}
