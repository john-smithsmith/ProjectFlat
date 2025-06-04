using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenBlock : Trap
{
    public Tilemap tilemap; // ����� Ÿ�ϸ�
    public Vector3Int tilePosition; // ����� Ÿ�� ��ǥ
    public float delay = 1.0f; // ������� ������ �ð�

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
        tilemap.SetTile(tilePosition, null); // Ÿ�� ����
    }
}
