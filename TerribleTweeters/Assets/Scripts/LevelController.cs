using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] string _nextLevelName;
    Monster[] _monsters;
    private void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>();
    }

    void Update()
    {
        if (MonstersAreAllDead())
        {
            GoToNextLevel();
        }
    }

    private void GoToNextLevel()
    {
        Debug.Log("Go to next level!" + _nextLevelName);
        SceneManager.LoadScene(_nextLevelName);
    }

    private bool MonstersAreAllDead()
    {
        foreach (var monster in _monsters)
        {
            if (monster.gameObject.activeSelf)
                return false;
        }
        return true;
    }
}
