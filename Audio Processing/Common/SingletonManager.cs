namespace AudioProcessing.Common
{
    /// <summary>
    /// Provides a generic way to manage singleton instances for any class type.
    /// </summary>
    /// <typeparam name="T">The type of class for which to manage the singleton instance.</typeparam>
    public static class SingletonManager<T> where T : class, new()
    {
        private static readonly Dictionary<Type, T> instances = new Dictionary<Type, T>();

        /// <summary>
        /// Gets the singleton instance of the specified class type.
        /// </summary>
        /// <returns>The singleton instance of the specified class type.</returns>
        public static T GetInstance()
        {
            Type type = typeof(T);

            if (!instances.ContainsKey(type))
            {
                instances[type] = new T();
            }

            return instances[type];
        }
    }
}