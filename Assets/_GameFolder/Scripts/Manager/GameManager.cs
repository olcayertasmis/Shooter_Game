using System;
using _GameFolder.Scripts.Enums;
using UnityEngine;

namespace _GameFolder.Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        private void ChangeGameState(GameEnum.GameState setState)
        {
            switch (setState)
            {
                case GameEnum.GameState.Menu:
                    break;
                case GameEnum.GameState.Play:
                    break;
                case GameEnum.GameState.Dead:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(setState), setState, null);
            }
        }
    } // END CLASS
}