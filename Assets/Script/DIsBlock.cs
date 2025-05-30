using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Sensor : MonoBehaviour
{
    public Tilemap tilemap;  // 사라질 타일맵
    private TilemapRenderer tileRenderer;
    public float detectRadius = 0.5f;  // 플레이어 감지

    void Update()
    {
        // 플레이어 주변 타일 감지
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectRadius);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                if (tileRenderer != null && tileRenderer.enabled)
                {
                    tileRenderer.enabled = false;
                    Debug.Log("타일맵 그림 숨김");
                }

                Vector3Int tilePos = tilemap.WorldToCell(hit.transform.position);
                if (tilemap.HasTile(tilePos))
                {
                    tilemap.SetTile(tilePos, null);  // 타일 제거
                }
            }
        }
    }
}
