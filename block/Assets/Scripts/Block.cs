using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject destroyVFX;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] int maxHits;
    [SerializeField] int timesHit;
    Level level;
    GameStatus gameStatus;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        HandleHit();
    }

    private void HandleHit()
    {
        timesHit++;
        maxHits = hitSprites.Length + 1;
        if (tag == "Breakable")
        {
            if (timesHit >= maxHits)
            {
                BlockDestroyed();
            }
            else
            {
                ShowNextHitSprites();
            }
        }
    }

    private void ShowNextHitSprites()
    {
        int spriteIndex = timesHit - 1;
        spriteRenderer.sprite = hitSprites[spriteIndex];

    }

    private void BlockDestroyed()
    {
        level.DestroyBlock();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        BlockDestroyedVFX();
        gameStatus.AddToScore();
        Destroy(gameObject);
    }
    private void BlockDestroyedVFX()
    {
        GameObject sparkles = Instantiate(destroyVFX, transform.position, Quaternion.identity);
        Destroy(sparkles, 2f);
    }
}