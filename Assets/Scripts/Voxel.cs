using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    // 복셀이 날아갈 속도 속성
    public float speed = 5;
    public float destroyTime = 3.0f;  //복셀을 제거할 시간
    public float currentTime;
    void OnEnable()
    {
        currentTime = 0;
        Vector3 direction = Random.insideUnitSphere;  //크기가 1이고 방향만 존재함 
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + Time.deltaTime; //시간이 흘러가도록
        if(currentTime > destroyTime)  //만약 현재 시간이 제거 시간을 초과했다면
        {
            gameObject.SetActive(true); //자기 자신을 비할성화 함
            VoxelMaker.voxelPool.Add(gameObject);  //VoxelMaker의 오브젝트 풀에 자기 자신을 추가
            //Destroy(gameObject); //게임 오브젝트를 제거해라
        }
    }
}
