using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//�l�b�g���[�N�p
using System.Net;
using UnityEngine.Networking;



public static class NetManager
{
    /*�ϐ�*/
    //Http���N�G�X�g�̌��ʂ��󂯎��ϐ�
    public static string s_httpResult = null;

    /// <summary>
    /// �yHttpGet���\�b�h(�񓯊�)�z
    /// StartCoroutine���\�b�h�o�R�Ŏ��s����B
    /// </summary>
    /// <param name="domainUrl">domain�A�h���X</param>
    /// <param name="passUrl">api�A�h���X</param>
    /// <param name="query">�N�G������(?�͏ȗ�)</param>
    /// <returns>IEnumerable�^��Ԃ��B</returns>
    public static IEnumerator HttpGetEnumerable(string hostUrl, string passUrl, string query=null)
    {
        /*result�̏�����*/
        s_httpResult = null;

        /*URL�̍쐬*/
        //�t��api�A�h���X���쐬���A�N�G�������ƍ���
        string getUrl = hostUrl + passUrl + $"?{query}";

        /*GetRequest*/
        //using�ɂ��X�R�[�v�𔲂����玩���Ń��������
        using UnityWebRequest getRequest = UnityWebRequest.Get( getUrl );

        /*yield return*/
        //���ʂ��Ԃ�܂ňȍ~�̏������s���Ȃ��B
        yield return getRequest.SendWebRequest();

        /*�ʐM�G���[����*/
        //isNetworkError�͔񐄏��ɂȂ�܂����B
        if(getRequest.result == UnityWebRequest.Result.Success)//����
        {
            //�������͐ڑ����\��
            Debug.Log($"�y�ʐM��(����)�F�z{getUrl}");
            //���ʂ���
            s_httpResult = getRequest.downloadHandler.text;
        }
        else//���s
        {
            //�G���[���N�����ꍇ�̓G���[���e��\��
            Debug.Log($"�y�G���[���e�F�z{getRequest.error}");
            Debug.Log($"�y�ʐM��(���s)�F�z{getUrl}");
            //�ڑ������s�������Ƃ�ʒm
            s_httpResult = "�ڑ������s���܂����B";
        }
    }
    /// <summary>
    /// �yHttpPost���\�b�h(�񓯊�)�z
    /// WWWform���쐬���đ�O�����ɓ���Ă��������B
    /// </summary>
    /// <param name="serverUrl">domain</param>
    /// <param name="postPass">api�A�h���X</param>
    /// <param name="form">form�f�[�^</param>
    /// <returns>IEnumerable�^��Ԃ��B</returns>
    public static IEnumerator HttpPostEnumerable(string serverUrl, string postPass, WWWForm form)
    {
        /*URL�̍쐬*/
        string postUrl = serverUrl + postPass;

        /*PostRequest*/
        using UnityWebRequest postRequest = UnityWebRequest.Post(postUrl, form);

        /*yield return*/
        yield return postRequest.SendWebRequest();

        /*�ʐM�G���[����*/
        //isNetworkError�͔񐄏��ɂȂ�܂����B
        if (postRequest.result == UnityWebRequest.Result.Success)//����
        {
            //�������͐ڑ����\��
            Debug.Log($"�y�ʐM��(����)�F�z{postUrl}");
            //���ʂ���
            s_httpResult = postRequest.downloadHandler.text;
        }
        else//���s
        {
            //�G���[���N�����ꍇ�̓G���[���e��\��
            Debug.Log($"�y�G���[���e�F�z{postRequest.error}");
            Debug.Log($"�y�ʐM��(���s)�F�z{postUrl}");
            //�ڑ������s�������Ƃ�ʒm
            s_httpResult = "�ڑ��Ɏ��s���܂����B";
        }
    }
}
