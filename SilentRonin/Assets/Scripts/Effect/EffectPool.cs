using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPool : MonoBehaviour
{
    // Singleton (chỉ 1 instance)
    public static EffectPool Instance;

    [Header("Prefabs hiệu ứng")]
    public GameObject jumpEffectPrefab;
    public GameObject landEffectPrefab;

    public float effectDuration = 2f;

    // Tạo sẵn hàng đợi cho mỗi loại hiệu ứng
    private Queue<GameObject> jumpPool = new Queue<GameObject>();
    private Queue<GameObject> landPool = new Queue<GameObject>();

    void Awake()
    {
        // Đảm bảo chỉ 1 instance tồn tại
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // ==========================
    // 📦 Hàm chơi hiệu ứng nhảy
    // ==========================
    public void PlayJumpEffect(Vector3 pos)
    {
        PlayEffect(jumpEffectPrefab, jumpPool, pos, effectDuration);
    }

    // ==========================
    // 📦 Hàm chơi hiệu ứng đáp đất
    // ==========================
    public void PlayLandEffect(Vector3 pos)
    {
        PlayEffect(landEffectPrefab, landPool, pos, effectDuration);
    }

    // ==========================
    // 🎬 Hàm chung xử lý hiệu ứng
    // ==========================
    private void PlayEffect(GameObject prefab, Queue<GameObject> pool, Vector3 pos, float duration)
    {
        if (prefab == null) return;

        GameObject effect;

        // Nếu pool có sẵn, lấy ra dùng
        if (pool.Count > 0)
        {
            effect = pool.Dequeue();
            effect.SetActive(true);
        }
        else
        {
            // Không có thì tạo mới
            effect = Instantiate(prefab);
        }

        effect.transform.position = pos;

        // Trả lại pool sau khi chạy xong
        StartCoroutine(ReturnToPool(effect, pool, duration));
    }

    private IEnumerator ReturnToPool(GameObject effect, Queue<GameObject> pool, float delay)
    {
        yield return new WaitForSeconds(delay);
        effect.SetActive(false);
        pool.Enqueue(effect);
    }
}
