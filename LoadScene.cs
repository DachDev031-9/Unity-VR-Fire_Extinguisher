using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadSceneWorldMap(){
        SceneManager.LoadScene("World Map 1");
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag.Equals("Player")){
            SceneManager.LoadScene("World Map 1");
        }
    }
}
