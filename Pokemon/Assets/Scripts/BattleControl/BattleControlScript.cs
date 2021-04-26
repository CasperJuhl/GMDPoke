using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum StateOfBattle { START, PLAYERTURN, ENEMYTURN, WON, LOST, RUN}
public class BattleControlScript : MonoBehaviour
{
    public StateOfBattle state;
    public GameObject playerFab;
    public GameObject enemyFab;

    public RectTransform playerStation;
    public RectTransform enemyStation;

    UnitScript playerUnit;
    UnitScript enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;


    // Start is called before the first frame update
    void Start()
    {
        state = StateOfBattle.START;
        StartCoroutine(StartBattle());

    }

    IEnumerator StartBattle()
    {
        GameObject player = Instantiate(playerFab, playerStation);
        playerUnit = player.GetComponent<UnitScript>();

        GameObject enemy = Instantiate(enemyFab, enemyStation);
        enemyUnit = enemy.GetComponent<UnitScript>();

        dialogueText.text = "A wild " + enemyUnit.Name + " appeared!";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(5f);

        state = StateOfBattle.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.setHP(enemyUnit.currentHP);
        dialogueText.text = "The attack worked!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = StateOfBattle.WON;
            End();
        }
        else
        {
            state = StateOfBattle.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);

        playerHUD.setHP(playerUnit.currentHP);
        dialogueText.text = playerUnit.Name + " is healing!";

        yield return new WaitForSeconds(2f);

        state = StateOfBattle.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerRun()
    {
        bool gotAway = playerUnit.Run();
        dialogueText.text = playerUnit.Name + " is trying to run away!";

        yield return new WaitForSeconds(2f);

        if (gotAway)
        {
            state = StateOfBattle.RUN;
            Run();
        }
        else
        {
            dialogueText.text = playerUnit.Name + " couldn't escape!";
            yield return new WaitForSeconds(2f);
            state = StateOfBattle.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.Name + " is attacking!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.setHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = StateOfBattle.LOST;
            End();
        }
        else
        {
            state = StateOfBattle.PLAYERTURN;
            PlayerTurn();
        }
    }

    void End()
    {
        if(state == StateOfBattle.WON)
        {
            dialogueText.text = "You won the battle!";
            SceneManager.LoadScene("SampleScene");
        }
        else if (state == StateOfBattle.LOST)
        {
            dialogueText.text = playerUnit.Name + " fainted!";
            SceneManager.LoadScene("SampleScene");
        }
    }

    void Run()
    {
        if (state == StateOfBattle.RUN)
        {
            dialogueText.text = "You got away safely!";
            SceneManager.LoadScene("SampleScene");
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }

    public void AttackButton()
    {
        if (state != StateOfBattle.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack());
    }

    public void HealButton()
    {
        if (state != StateOfBattle.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerHeal());
    }

    public void RunButton()
    {
        if (state != StateOfBattle.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerRun());
    }
}
