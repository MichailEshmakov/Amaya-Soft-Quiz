using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableConstructor : MonoBehaviour
{
    [SerializeField] private float _cellLength;

    public void ConstructTable(IReadOnlyList<Transform> cells, int width, int height)
    {
        if (width <= 0)
            throw new ArgumentOutOfRangeException(nameof(width));

        if (height <= 0)
            throw new ArgumentOutOfRangeException(nameof(height));

        Vector2 leftTopPosition = new Vector2(-(width - 1) * _cellLength / 2, (height - 1) * _cellLength / 2);
        for (int i = 0; i < width && i < cells.Count; i++)
        {
            for (int j = 0; j < height && i * height + j < cells.Count; j++)
            {
                cells[i * height + j].localPosition = leftTopPosition + new Vector2(_cellLength * i, -_cellLength * j);
            }
        }
    }
}
