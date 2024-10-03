using UnityEngine;
using UnityEngine.UI;
/*�Q�lURL*/
//https://note.com/what_is_picky/n/nf9b5dca6e5b6
//�I�u�W�F�N�g�̕��s�ړ����Ɛ؂�ڂ������Ă��܂��̂ŁA
//�}�e���A���̕��s�ړ��ŏ�������B

public class tBackSkyMove : MonoBehaviour
{
    private const float k_maxLength = 1f;//�ő�l
    private const string k_propName = "_MainTex";//�V�F�[�_�[�ϐ���

    [SerializeField]
    private Vector2 m_offsetSpeed;

    private Material m_material;

    private void Start()
    {
        //Image�R���|�[�l���g�̒��̃}�e���A�����擾
        if (GetComponent<Image>() is Image i)
        {
            m_material = i.material;
        }
    }

    private void Update()
    {
        if (m_material)
        {
            // x��y�̒l��0 �` 1�Ń��s�[�g����悤�ɂ���
            //Mathf.Repeat(A,B);�́AA�ɓn�������̌��ʂ�B�ɒB����x��0�ɖ߂�Ƃ������́B
            //A%B�ɋ߂��B
            var x = Mathf.Repeat(Time.time * m_offsetSpeed.x, k_maxLength);
            var y = Mathf.Repeat(Time.time * m_offsetSpeed.y, k_maxLength);
            var offset = new Vector2(x, y);
            //offset�͕\���ʒu�������Ă��邾��
            //k_propName�́c�c�V�F�[�_�[�ϐ����Ȃ̂ŁA�m���Ƃ������Ȃ��B
            m_material.SetTextureOffset(k_propName, offset);
        }
    }

    private void OnDestroy()
    {
        // �Q�[������߂���Ƀ}�e���A����Offset��߂��Ă���
        if (m_material)
        {
            m_material.SetTextureOffset(k_propName, Vector2.zero);
        }
    }
}
