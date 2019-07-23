using System.Collections;
using System.Collections.Generic;
using AliveObject.Player;
using Managers;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private ParticleSystem confetti;

    public void Start()
    {
        FinishManager.FM.Finish += FinishEffect;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            FinishManager.FM.addFinishedPlayer();
        }
    }

    private void FinishEffect()
    {
        confetti.Play(true);
    }
}
