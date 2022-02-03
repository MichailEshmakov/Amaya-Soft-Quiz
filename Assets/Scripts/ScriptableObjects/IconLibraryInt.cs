using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Icon Library" + "/New " + nameof(IconLibraryInt))]
public class IconLibraryInt : IconLibrary<IconMatchInt>
{

}

[Serializable]
public class IconMatchInt : IconMatch<int>
{

}