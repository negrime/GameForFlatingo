using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Collider2D))]
public class EndFlagReached : MonoBehaviour
{
    public AudioClip _winClip;
    private Collider2D _collider;
    private Animator _animator;
    private AudioSource _audioSource;

    [SerializeField]
    private int _checkPointNumber;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        _audioSource.PlayOneShot(_winClip);
        _animator.SetBool("end", true); 
        PlayerPrefs.SetInt("CheckPoint", _checkPointNumber);
        //StartCoroutine(StartNextLevel(4));
        GetComponent<Collider2D>().enabled = false;
    }

    IEnumerator StartNextLevel(float timeToWait)
    {

        yield return new WaitForSeconds(2f);

        GameObject.FindWithTag("Transition").GetComponent<LevelTransitionEffect>().EndLevel();

        yield return new WaitForSeconds(1f);
   //     SceneManager.LoadScene(_nextSceneName);
    }
}
