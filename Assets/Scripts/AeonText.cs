using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AeonText : MonoBehaviour
{
    [SerializeField]
    TempObjectPool pool;

    [SerializeField]
    Vector4 spawnBounds;

    [SerializeField]
    Vector2 iterationDelay;

    [SerializeField]
    Vector2Int spawnIterations;

    [SerializeField]
    Vector2Int textCounts;

    [SerializeField]
    GameObject aeonObject;

    // Start is called before the first frame update
    void Start()
    {
        StartText();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (!aeonObject.activeInHierarchy && pool.AreAnyActive())
        {
            Clear();
        }
    }

    public void Clear()
    {
        StopAllCoroutines();
        pool.DisableAll();
    }

    public void StartText()
    {
        StartCoroutine(DoStuff());
    }

    IEnumerator DoStuff()
    {
        int spawnCount = spawnIterations.Random();

        for (int i = 0; i < spawnCount; i++)
        {
            int textCount = textCounts.Random();
            for (int k = 0; k < textCount; k++)
            {
                var text = pool.GetObject();
                text.transform.position = spawnBounds.Random();
                text.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(iterationDelay.Random());
        }
    }
}
