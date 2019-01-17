using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //scene를 바꾸려면 사용해야 하는 모듈임

public class LoginController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveGame(){
        SceneManager.LoadScene ("Game");
    }
}
