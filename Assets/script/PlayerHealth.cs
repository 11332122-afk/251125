using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 5;
    public int currentHP;
    public TMP_Text hpText;
    public float damageInterval = 1f;

    private float damageTimer = 0f;

    void Start()
    {
        currentHP = maxHP;
        UpdateHPUI();
    }

    void Update()
    {
        if (damageTimer > 0f)
        {
            damageTimer -= Time.deltaTime;
        }
    }

    // 實體碰撞偵測（敵人與玩家都沒有勾選 Is Trigger 時觸發）
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TryTakeDamage(1);
        }
    }

    // 穿透觸發偵測（任一方有勾選 Is Trigger 時觸發）
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TryTakeDamage(1);
        }
    }

    void TryTakeDamage(int damage)
    {
        if (damageTimer <= 0f && currentHP > 0)
        {
            currentHP -= damage;
            if (currentHP < 0) currentHP = 0;

            damageTimer = damageInterval;
            UpdateHPUI();

            if (currentHP <= 0)
            {
                if (currentHP <= 0)
                {
                    Debug.Log("玩家死亡（Game Over）");

                    if (GameManager.Instance != null)
                    {
                        GameManager.Instance.GameOver();
                    }
                }
            }
        }
    }

    void UpdateHPUI()
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + currentHP + "/" + maxHP;
        }
    }
}