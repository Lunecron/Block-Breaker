using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config param

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkelsVFX;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;
    GameSession gameStatus;

    //stats variables
    [SerializeField] int timesHit; // TODO Only serialized for testing


    private void Start()
    {

        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameSession>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        for(int index= 0; index < FindObjectsOfType<Ball>().Length; index++)
        {
            if (tag == "Breakable" && collision.gameObject.name.Equals(FindObjectsOfType<Ball>()[index].name))
            {
                HandleHit();

            }

        }


    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from array: " + gameObject.name);
        }
        
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        gameStatus.AddToScore();
        level.BlockDestroyed();
        TriggeSparklesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, gameObject.transform.position);
        Destroy(gameObject, 0f);
    }

    private void TriggeSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkelsVFX,transform.position, transform.rotation);
        Destroy(sparkles, 0.5f);
    }
}
