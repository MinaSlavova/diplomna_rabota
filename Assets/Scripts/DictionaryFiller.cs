using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DictionaryFiller : MonoBehaviour
{
    [SerializeField] private GameObject[] items;

    private void Awake()
    {
        for(int i = 0; i < items.Length; i++)
        {
            ItemPickup.itemQuantity.TryAdd(items[i].name + "(Clone)", 0);
        }
    }

    private void Start()
    {
        ItemPickup.itemQuantity["Sword(Clone)"] = 1;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        DictionaryClear();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void DictionaryClear()
    {
        for (int i = 0; i < items.Length; i++)
        {
            ItemPickup.itemQuantity[items[i].name + "(Clone)"] = 0;
        }
    }
}
