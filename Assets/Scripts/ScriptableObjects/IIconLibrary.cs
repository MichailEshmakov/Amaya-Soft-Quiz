using System;
using UnityEngine;

public interface IIconLibrary
{
    Type Type { get; }

    IIconMatch GetMatch(object value);
}