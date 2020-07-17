﻿namespace JogoGourmet2.Singleton
{
    public sealed class Singleton<T> where T : class, new()
    {
        private static T _instance;

        public static T Instance()
        {
            lock (typeof(T))
                if (_instance == null)
                    _instance = new T();

            return _instance;
        }
    }
}
