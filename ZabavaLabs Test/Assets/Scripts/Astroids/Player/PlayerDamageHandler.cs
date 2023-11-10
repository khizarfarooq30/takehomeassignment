using System.Collections;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    
    [SerializeField] private GameObject[] healthIcons;
    [SerializeField] private GameObject damageEffect;

    [SerializeField] private SpriteRenderer playerSprite;

    [SerializeField] private int maxHealth = 3;
    [SerializeField] private int damage = 1;

    private int currentHealth;
    private bool ignoreDamage;

    private AudioManager audioManager => AudioManager.instance;
    private GameManager gameManager => GameManager.instance;
    
    private void Start()
    {
        currentHealth = maxHealth;
        ignoreDamage = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!ignoreDamage && other.TryGetComponent(out Obstacle obstacles))
        {
            ignoreDamage = true;
            
            audioManager.Play(SoundType.PlayerHit);

            if (currentHealth >= 0)
            {
                currentHealth -= damage;
                healthIcons[currentHealth].SetActive(false);
            }

            damageEffect.transform.parent = null;
            damageEffect.SetActive(true);
            playerSprite.enabled = false;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                playerController.RestrictControls(true);
                gameObject.SetActive(false);
                gameManager.GameOver();
                return;
            }
             
            // disable player sprite for 0.7 seconds and reset player position
            StartCoroutine(ResetPlayer());
        }
    }

    IEnumerator ResetPlayer()
    {
        playerController.RestrictControls(true);
        playerController.ResetPlayer();
        yield return new WaitForSeconds(0.7f);
        playerSprite.enabled = true;
        playerController.RestrictControls(false);
        damageEffect.transform.parent = transform;
        damageEffect.transform.localPosition = Vector3.zero;
        yield return new WaitForSeconds(0.5f);
        ignoreDamage = false;
        

    }
}