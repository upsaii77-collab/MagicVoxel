using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    //생성할 대상 등록
    public GameObject voxelFactory;  //게임 오브젝트라는 변수가 만들어짐, public으로 등록했기 때문에 인스펙터에서 수정 가능
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) //버튼이 눌렸을 때(사용자가 마우스를 클릭했다면) 아니 Fire1이 숫자 1이었네...
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //ray 변수 저장
            RaycastHit hitInfo = new RaycastHit(); //Hit라는 결과물에 대한 정보를 받음

            //마우스의 위치가 바닥 위에 위치한다면
            if(Physics.Raycast(ray, out hitInfo)) //ray에 대한 결과물이 true일 때 hitInfo에 넣어주는
            {
                GameObject voxel = Instantiate(voxelFactory);  //복셀 공장에서 복셀을 만듦
                voxel.transform.position = hitInfo.point;  //복셀을 배치
            }
        }
    }
}
