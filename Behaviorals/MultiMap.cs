using System;
using System.Collections.Generic;

namespace Behaviorals {

	public class MultiMap<TKey, TValue> : Dictionary<TKey, HashSet<TValue>> {

		public void Add(TKey key, TValue value) {
			if (key == null) throw new ArgumentNullException($"Parameter {nameof(key)} cannot be null.");
			HashSet<TValue> container;
			if (!TryGetValue(key, out container)) {
				container = new HashSet<TValue>();
				Add(key, container);
			}
			container.Add(value);
		}

		public bool ContainsValue(TKey key, TValue value) {
			if (key == null) throw new ArgumentNullException($"Parameter {nameof(key)} cannot be null.");
			var toReturn = false;
			HashSet<TValue> values;
			if (TryGetValue(key, out values))
				toReturn = values.Contains(value);
			return toReturn;
		}

		public void Remove(TKey key, TValue value) {
			if (key == null) throw new ArgumentNullException($"Parameter {nameof(key)} cannot be null.");

			HashSet<TValue> container;

			if (!TryGetValue(key, out container)) return;

			container.Remove(value);
			if (container.Count <= 0)
				Remove(key);
		}

		public void Merge(MultiMap<TKey, TValue> toMergeWith) {
			if (toMergeWith == null) throw new ArgumentNullException($"Parameter {nameof(toMergeWith)} cannot be null.");

			foreach (var pair in toMergeWith) {
				foreach (var value in pair.Value) {
					Add(pair.Key, value);
				}
			}
		}

		public HashSet<TValue> GetValues(TKey key, bool returnEmptySet) {
			HashSet<TValue> toReturn;
			if (!TryGetValue(key, out toReturn) && returnEmptySet)
				toReturn = new HashSet<TValue>();
			return toReturn;
		}
	}
}