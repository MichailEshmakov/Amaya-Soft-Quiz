using System;
using UnityEngine;

public interface IIconLibrary
{
    Type Type { get; }

    Sprite GetIcon(object value);
}