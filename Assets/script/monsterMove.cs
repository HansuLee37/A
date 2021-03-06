﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class monsterMove : MonoBehaviour {
    //몬스터의 상태 정보가 있는  Enumerable변수 선언
    public enum MonsterState { idle,trace,attack,die};
    //몬스터의 현재 상태정보를 저장할 Enum 변수
    public MonsterState monsterSate = MonsterState.idle;

    //속도 향상을 위해 각종 컴포넌트를 변수에 할당
    private Transform monsterTr;
    private Transform playerTr;
    private NavMeshAgent nvAgent;

    //추적 사정거리
    public float traceDist = 10.0f;
    //공격 사정거리
    public float attackDist = 2.0f;

    //몬스터의 사망 여부
    private bool isDie = false;

	void Start () {
        //몬스터의 Transform 할당
        monsterTr = this.gameObject.GetComponent<Transform>();
        //추적 대상인 Player의 Transform 할당
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //NavMeshAgent 컴포넌트 할당
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();

        //일정한 간격으로 몬스터의 행동 상태를 체크하는 코루틴 함수 실행
        StartCoroutine(this.CheckMonsterState());

        //몬스터의 상태에 따라 동작하는 루틴을 실행하는 코루틴 함수 실행
        StartCoroutine(this.MonsterAction());
	}
	
    //일정한 간격으로 몬스터의 행동 상태를 체크하고 monsterState값 변경
    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            //0.2초 동안 기다렸다가 다음으로 넘어감
            yield return new WaitForSeconds(0.2f);
            //몬스터와 플레이어 사이의 거리 측정
            float dist = Vector3.Distance(playerTr.position, monsterTr.position);

            if (dist <= attackDist) //공격거리 범위 이내로 들어왔는지 확인
            {
                monsterSate = MonsterState.attack;
            }
            else if(dist <= traceDist) //추적거리 범위 이내로 들어왔는지 확인
            {
                monsterSate = MonsterState.trace; //몬스터의 상태를 추적으로 설정
            }
            else
            {
                monsterSate = MonsterState.idle; //몬스터의 상태를 idle 모드로 설정
            }
        }
    }

    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            switch (monsterSate)
            {
                //idle상태
                case MonsterState.idle:
                    //추적 중지
                    nvAgent.Stop();
                    break;

                //추적 상태
                case MonsterState.trace:
                    //추적 대상의 위치를 넘겨줌
                    nvAgent.destination = playerTr.position;
                    //추적을 재시작
                    nvAgent.Resume();
                    break;

                //공격 상태
                case MonsterState.attack:
                    break;
            }
            yield return null;
        }
    }
    //Bullet과 충돌 체크
    void OncollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "BULLET")
        {
            Destroy(coll.gameObject);
            MonsterDie();
        }
    }

    void MonsterDie()
    {
        //모든 코루틴을 정지
        StopAllCoroutines();
        isDie = true;
        monsterSate = MonsterState.idle;
        nvAgent.Stop();
    }
}
