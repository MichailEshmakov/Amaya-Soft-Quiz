﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Icon Library" + "/New " + nameof(IconLibraryString))]
public class IconLibraryString : IconLibrary<IconMatchString>
{

}

[Serializable]
public class IconMatchString : IconMatch<string>
{

}
