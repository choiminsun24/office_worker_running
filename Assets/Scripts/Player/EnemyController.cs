using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject target;
    public Transform targetP;  // �÷��̾��� ��ġ�� ������ ����

    public float distance;  // ī�޶�� �÷��̾� ���� �Ÿ�
    public float height = 1f;  // ī�޶�� �÷��̾� ���� ����

    static public float smoothSpeed = 0.33f;  //�ε巯�� ����
    public static float changeSpeed = 0.1f; //�������� ����

    private Vector3 velocity = Vector3.zero;  // �̵� �� ����� �ӵ� ����

    public AudioSource bossAudioSource; //bossSound
    public AudioClip bossAudioClip;
    private float volume = 0.05f;

    void Start()
    {
        //distance = 1f;
        target = GameObject.FindGameObjectWithTag("PlayerPoint");
        targetP = target.GetComponent<Transform>();

        BossSoundPlay();
    }

    void LateUpdate()
    {
        // ī�޶��� ��ġ�� �ε巴�� �̵���Ű�� ���� Lerp �Լ� ���
        Vector3 targetPosition = targetP.position + Vector3.up * height - targetP.forward * distance;
        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);

        // ī�޶� �÷��̾ �ٶ󺸵��� ȸ����Ŵ
        transform.LookAt(targetP);
    }

    static public void smoothSpeedUp()
    {
        smoothSpeed -= changeSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�÷��̾�� �浹");
        }
    }

    public void BossSoundPlay()
    {
        if (!MuteManager.EffectIsMuted)
        {
            bossAudioSource.clip = bossAudioClip;
            volume = 0.3f;

            bossAudioSource.loop = true;
            bossAudioSource.volume = volume;
            bossAudioSource.Play();
        }
    }
}
