using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenBlock : Trap
{
    public Tilemap tilemap; // 사라질 타일맵
    public Vector3Int tilePosition; // 사라질 타일 좌표
    public float delay = 1.0f; // 사라지는 딜레이 시간

    private bool activated = false;

    public override void ActivateTrap()
    {
        if (!activated)
        {
            activated = true;
            StartCoroutine(RemoveTileAfterDelay());
        }
    }

    private System.Collections.IEnumerator RemoveTileAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        tilemap.SetTile(tilePosition, null); // 타일 제거
    }
}
