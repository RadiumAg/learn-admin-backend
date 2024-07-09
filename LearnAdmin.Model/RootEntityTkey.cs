using System;
namespace LearnAdmin.Model
{
	public class RootEntityTkey<TKey> where TKey : IEquatable<TKey>
	{
		/// <summary>
		/// Id
		/// 泛型主键Tkey
		/// </summary>
		public TKey? Id { get; set; }
	}
}

