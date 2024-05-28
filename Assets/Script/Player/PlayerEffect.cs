using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    public void addSpeed(int SpeedGiven, float SpeedDuration)
    {
        PlayerController.instance.HorizontalSpeed += SpeedGiven;
        StartCoroutine(RemoveSpeed(SpeedGiven,SpeedDuration));
    }

    public IEnumerator RemoveSpeed(int SpeedGiven, float SpeedDuration)
    {
        yield return new WaitForSeconds(SpeedDuration);
        PlayerController.instance.HorizontalSpeed -= SpeedGiven;
    }


    public void addJump(int JumpGiven, float JumpDuration)
    {
        PlayerController.instance.jumpPower += JumpGiven;
        StartCoroutine(RemoveJump(JumpGiven,JumpDuration));
    }

    public IEnumerator RemoveJump(int JumpGiven, float JumpDuration)
    {
        yield return new WaitForSeconds(JumpDuration);
        PlayerController.instance.jumpPower -= JumpGiven;
    }

    public void ChangeScale(float NewScale, float scaleDuration)
    {
        Transform transform = GetComponent<Transform>();
        transform.localScale = new Vector3(NewScale, NewScale, NewScale);
        PlayerController.instance.jumpPower -= 3;
        StartCoroutine(RemoveChangeScale(scaleDuration));
    }

    public IEnumerator RemoveChangeScale(float scaleDuration)
    {
        yield return new WaitForSeconds(scaleDuration);
        PlayerController.instance.jumpPower += 3;
        Transform transform = GetComponent<Transform>();
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    
    public void DoubleJump(int NbSautSuppl, float DoubleJumpDuration)
    {
        PlayerController.instance.NbSautSup += NbSautSuppl;
        StartCoroutine(RemoveDoubleJump(NbSautSuppl, DoubleJumpDuration));
    }

    public IEnumerator RemoveDoubleJump(int NbSautSuppl, float DoubleJumpDuration)
    {
        yield return new WaitForSeconds(DoubleJumpDuration);
        PlayerController.instance.NbSautSup -= NbSautSuppl;
    }
}