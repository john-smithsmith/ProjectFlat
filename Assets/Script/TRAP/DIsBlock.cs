using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Sensor : MonoBehaviour
{
    public Tilemap tilemap;  // ����� Ÿ�ϸ�
    private TilemapRenderer tileRenderer;
    public float detectRadius = 0.5f;  // �÷��̾� ����

    void Start()
    {
        
        if (tilemap != null)
        {
            tileRenderer = tilemap.GetComponent<TilemapRenderer>();
        }
    }

    void Update()
    {
        // �÷��̾� �ֺ� Ÿ�� ����
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectRadius);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                if (tileRenderer != null && tileRenderer.enabled)
                {
                    tileRenderer.enabled = false;
                    Debug.Log("Ÿ�ϸ� �׸� ����");
                }

                Vector3Int tilePos = tilemap.WorldToCell(hit.transform.position);
                if (tilemap.HasTile(tilePos))
                {
                    tilemap.SetTile(tilePos, null);  // Ÿ�� ����
                }
            }
        }
    }
}
// �÷��̾ Ư�� �ݰ濡 ������ Ÿ�ϸ� �����
//1. �������Ʈ
//2. ��ũ��Ʈ�߰�
//3. ��ġ ����(Ÿ�ϸ�)
//4. ��������