using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IconMatcher : MonoBehaviour
{
    [SerializeField] private List<ScriptableObject> _iconLibraries;

    private void OnValidate()
    {
        for (int i = 0; i < _iconLibraries.Count; i++)
        {
            if (_iconLibraries[i] is IIconLibrary == false)
            {
                _iconLibraries.RemoveAt(i);
                i--;
            }
        }
    }

    public Sprite FindSprite(object value, Type type)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));

        if (type == null)
            throw new ArgumentNullException(nameof(type));

        IIconLibrary typedLibrary = _iconLibraries.FirstOrDefault(library =>
        {
            IIconLibrary iconLibrary = library as IIconLibrary;
            return iconLibrary.Type == type;
        }) as IIconLibrary;

        Sprite result = typedLibrary.GetIcon(value);
        if (result == null)
            throw new InvalidOperationException();

        return result;
    }
}
