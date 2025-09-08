

namespace Levels.Core {
	using System;

	public interface IForward<T, Context> {
		public void Call(T contexst, Type target);
	}

	public static class Forward_Extends {
		public static IForward<T, Context> Interface_IForward<T, Context>(this IForward<T, Context> src)
			=> src;

		public static void Call<T, Context>(this IForward<T, Context> src, T context, Type target) {
			src.Call(context, target);
		}
	}
}
