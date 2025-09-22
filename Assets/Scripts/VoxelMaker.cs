using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    //생성할 대상 등록
    public GameObject voxelFactory;  //게임 오브젝트라는 변수가 만들어짐, public으로 등록했기 때문에 인스펙터에서 수정 가능
    
    //오브젝트 풀의 크기
    public int voxelPoolSize = 20;

    //오브젝트 풀, static은 내가 만든 변수는 오로지 1개라는 정적 함수
    public static List<GameObject> voxelPool = new List<GameObject>();
    public float createTime = 0.1f;
    float currentTime = 0;
    public Transform crosshair; //크로스헤어 변수 저장
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < voxelPoolSize; i++) //for문으로 20번 반복하게 하기
        {
            GameObject voxel = Instantiate(voxelFactory);  //시작하면 객체를 생성해라
            voxel.SetActive(false); //복셀 비활성화
            voxelPool.Add(voxel); //복셀을 오브젝트 풀에 담고 싶다
        }
    }

    // Update is called once per frame
    void Update()
    {
        ARAVRInput.DrawCrosshair(crosshair); //크로스헤어 그리기

        if(ARAVRInput.Get(ARAVRInput.Button.One)) //VR 컨트롤러의 발사 버튼을 누르면
        {
            currentTime += Time.deltaTime;

            if(currentTime > createTime)
            {
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //ray 변수 저장, 사전의 마우스로 했던 부분은 주석처리
                Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection); //컨트롤러가 향하는 방향으로 시선 만들기
                RaycastHit hitInfo = new RaycastHit(); //Hit라는 결과물에 대한 정보를 받음
            
            //마우스의 위치가 바닥 위에 위치한다면
                if(Physics.Raycast(ray, out hitInfo)) //ray에 대한 결과물이 true일 때 hitInfo에 넣어주는
                {
                //복셀 오브젝트 풀 사용하기
                    if(voxelPool.Count > 0) //오브젝트 풀 안에 voxel이 있는지 확인
                    {
                        GameObject voxel = voxelPool[0];  //오브젝트 풀에서 가장 처음 복셀을 하나 가져옴
                        voxel.SetActive(true); //비활성화 되어있던 복셀을 활성화시킴
                        voxel.transform.position = hitInfo.point;  //복셀을 배치
                        voxelPool.RemoveAt(0); //오브젝트 풀에서 복셀을 제거함
                        currentTime = 0;
                    }
                }
            }
        }
    
    }
}
