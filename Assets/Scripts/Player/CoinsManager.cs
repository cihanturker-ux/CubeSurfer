using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;

public class CoinsManager : MonoBehaviour
{
    [Header("UI")]
    public Text coinUIText;
    [SerializeField] GameObject amimatedCoinPrefab;
    [SerializeField] Transform target;

    [Space]
    [Header("Available Coins")]
    [SerializeField] int maxCoins;
    Queue<GameObject> coinsQueue = new Queue<GameObject>();

    [Space]
    [Header("Animation Settings")]
    [SerializeField] [Range(0.5f, 0.9f)] float minAnimDuration;
    [SerializeField] [Range(0.9f, 2f)] float maxAnimDuration;

    [SerializeField] Ease easeType;

    Vector3 targetPosition;

    private int _c = 0;

    public int Coins 
    {
        get { return _c; }
        set { _c = value; coinUIText.text = Coins.ToString(); }
    }

    private void Awake()
    {
        targetPosition = target.position;
        PrepareCoins();
    }

    void PrepareCoins()
    {
        for (int i = 0; i < maxCoins; i++)
        {
            GameObject coin;
            coin = Instantiate(amimatedCoinPrefab);
            coin.transform.parent = transform;
            coin.SetActive(false);
            coinsQueue.Enqueue(coin);
        }
    }

    void Animate(Vector3 collectedCoinPosition,int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (coinsQueue.Count > 0)
            {
                GameObject coin = coinsQueue.Dequeue();
                coin.SetActive(true);

                coin.transform.position = collectedCoinPosition;

                float duration = Random.Range(minAnimDuration, maxAnimDuration);
                coin.transform.DOMove(targetPosition, duration).SetEase(easeType).OnComplete(() => {
                    coin.SetActive(false);
                    coinsQueue.Enqueue(coin);
                    Coins++;
                });
            }
        }
    }

    public void AddCoins(Vector3 collectedCoinPosition, int amount)
    {
        Animate(collectedCoinPosition, amount);
    }

}

