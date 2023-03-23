using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;  // �÷��̾��� ��ġ�� ������ ����

    public float distance = 2.5f;  // ī�޶�� �÷��̾� ���� �Ÿ�
    public float height = 1f;  // ī�޶�� �÷��̾� ���� ����

    static public float smoothSpeed = 0.4f;  // ī�޶� �̵� �� �ε巯�� ������ ���� ����
    public static float changeSpeed = 0.1f; //ī�޶� �������� ����

    private Vector3 velocity = Vector3.zero;  // ī�޶� �̵� �� ����� �ӵ� ����

    void LateUpdate()
    {
        // ī�޶��� ��ġ�� �ε巴�� �̵���Ű�� ���� Lerp �Լ� ���
        Vector3 targetPosition = target.position + Vector3.up * height - target.forward * distance;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);

        // ī�޶� �÷��̾ �ٶ󺸵��� ȸ����Ŵ
        transform.LookAt(target);
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
}
