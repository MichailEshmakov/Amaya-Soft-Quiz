using System;

namespace ScriptableObjects
{
    public interface IIconLibrary
    {
        Type Type { get; }

        IIconMatch GetMatch(object value);
    }
}
