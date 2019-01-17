using System.Collections;
using System.Collections.Generic;
using UnityEngine; ///코루틴? 1초에 한 번씩 뭐를 해라... 즉 업데이트 함수와 비슷한 개념 , 애니메이션이나 카운트다운할 때 많이 씀
using UnityEngine.UI;


public class GoldCounter : MonoBehaviour
{
    public int Gold = 0;
    public Text TextGold;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (StartGoldCount()); // 유니티에서 엄청나게 많이 쓰임. 비동귀함수, 이거는 내부에 다른 함수를 포함해야 쓸 수 있음.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartGoldCount(){
        while (true) {
            yield return new WaitForSecondsRealtime (1f); //1초씩 쉬는 명령어 , yield가 생소함. Wait~~는 모듈로 예상됨
            Gold++;
            TextGold.text = Gold.ToString ();//텍스트 형이므로 텍스트로 바꿔준다. 그냥 바로 Gold를 쓰지않고 Text형을 쓰는 이유는?
        }
    }

}
