using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cal : MonoBehaviour
{
    [SerializeField] Tilemap calTilemap;
    [SerializeField] TileBase num1, num2, num3, num4, num5, num6, num7, num8, num9, num0, plus, minus, multiply, divide, equals, clear;

    public Calculator CalAnswer;
    // Update is called once per frame
    void Update()
    {
        handleUserInput();
    }

    private void handleUserInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            TileBase clickedTile = GetTile(calTilemap, worldPosition);
            if(clickedTile != null)
            {
                findKey(clickedTile);
            }
        }
    }

    private void findKey(TileBase tile)
    {
        if(tile == num1)
        {
            CalAnswer.NumberInput(1);
            Debug.Log("num1 pressed");
        }else if (tile == num2)
        {
            CalAnswer.NumberInput(2);
            Debug.Log("num2 pressed");
        }
        else if (tile == num3)
        {
            CalAnswer.NumberInput(3);
            Debug.Log("num3 pressed");
        }
        else if (tile == num4)
        {
            CalAnswer.NumberInput(4);
            Debug.Log("num4 pressed");
        }
        else if (tile == num5)
        {
            CalAnswer.NumberInput(5);
            Debug.Log("num5 pressed");
        }
        else if (tile == num6)
        {
            CalAnswer.NumberInput(6);
            Debug.Log("num6 pressed");
        }
        else if (tile == num7)
        {
            CalAnswer.NumberInput(7);
            Debug.Log("num7 pressed");
        }
        else if (tile == num8)
        {
            CalAnswer.NumberInput(8);
            Debug.Log("num8 pressed");
        }
        else if (tile == num9)
        {
            CalAnswer.NumberInput(9);
            Debug.Log("num9 pressed");
        }
        else if (tile == num0)
        {
            CalAnswer.NumberInput(0);
            Debug.Log("num0 pressed");
        }
        else if (tile == divide)
        {
            CalAnswer.OperInput(Calculator.Operators.div);
            Debug.Log("divide pressed");
        }
        else if (tile == multiply)
        {
            CalAnswer.OperInput(Calculator.Operators.multi);
            Debug.Log("multiply pressed");
        }
        else if (tile == plus)
        {
            CalAnswer.OperInput(Calculator.Operators.plus);
            Debug.Log("plus pressed");
        }
        else if (tile == minus)
        {
            CalAnswer.OperInput(Calculator.Operators.minus);
            Debug.Log("minus pressed");
        }
        else if (tile == equals)
        {
            CalAnswer.EnterInput();
            Debug.Log("equals pressed");
        }
        else if (tile == clear)
        {
            CalAnswer.BackInput();
            Debug.Log("clear pressed");
        }
    }

    public static TileBase GetTile(Tilemap tilemap, Vector2 pos)
    {
        Vector3Int tilePos = tilemap.WorldToCell(pos);
        return tilemap.GetTile(tilePos);
    }

}

[System.Serializable]
public class Calculator{

    [SerializeField] string display;
    [SerializeField] int operand1, operand2, solution;
    public enum Operators
    {
        none,
        plus,
        minus,
        div,
        multi
    }
    Operators oper;
    enum CalStates
    {
        operand1Inputting,
        operatorInputted,
        operand2Inputting,
        solved
    }
    [SerializeField] CalStates calstate;

    public void NumberInput(int num)
    {
        if (calstate == CalStates.operand1Inputting)
        {
            operand1 = operand1 * 10 + num;
            display = operand1.ToString();
        }
        else if (calstate == CalStates.operatorInputted)
        {
            operand2 = num;
            calstate = CalStates.operand2Inputting;
            display = $"{operand1} {oper} {operand2} "; 
        }
        else if (calstate == CalStates.operand2Inputting)
        {
            operand2 = operand2 * 10 + num;
            display = $"{operand1} {oper} {operand2} ";
        }
        else if (calstate == CalStates.solved)
        {
            //operand1 = solution;
            //operand2 = num;
            //calstate = CalStates.operand2Inputting;
            //display = $"{operand1} {oper} {operand2} ";
            clear();
            operand1 = num;
            calstate = CalStates.operand1Inputting;
            display = operand1.ToString();
        }
        else
        {
            Debug.LogWarning("NumberInput() else");
        }
    }

    public void OperInput(Operators oper)
    {
        if(oper == Operators.none)
        {
            Debug.LogWarning("oper == Operators.none not implemented");
        }
        else if (calstate == CalStates.operand1Inputting)
        {
            this.oper = oper;
            calstate = CalStates.operatorInputted;
            display = $"{operand1} {oper}";
            
        }
        else if (calstate == CalStates.operatorInputted)
        {
            this.oper = oper;
            display = $"{operand1} {oper}";
        }
        else if (calstate == CalStates.operand2Inputting)
        {
            solution = solve(operand1, operand2, oper);
            display = $"{operand1} {oper} {operand2} = {solution}";
            operand1 = solve(operand1, operand2, this.oper);
            
            this.oper = oper;
            
            calstate = CalStates.operatorInputted;
            display = $"{operand1} {oper}";

        }
        else if (calstate == CalStates.solved)
        {
            operand1 = solve(operand1, operand2, this.oper);
            this.oper = oper;
            calstate = CalStates.operatorInputted;
            display = $"{operand1} {oper}";
        }
        else
        {
            Debug.LogWarning("OperInput() else");
        }

    }

    public void BackInput()
    {
        if (calstate == CalStates.operand1Inputting)
        {
            if (operand1 != 0) operand1 /= 10;
            display = operand1.ToString();
        }
        else if (calstate == CalStates.operatorInputted)
        {
            oper = Operators.none;
            calstate = CalStates.operand1Inputting;
        }
        else if (calstate == CalStates.operand2Inputting)
        {
            if (operand2 != 0)
            {
                operand2 /= 10;
                display = $"{operand1} {oper} {operand2} ";
            }
            else
            {
                display = $"{operand1} {oper}";
            }
        }
        else if (calstate == CalStates.solved)
        {
            calstate = CalStates.operand1Inputting;
            display = "0";
            clear();
        }
         else
        {
            Debug.LogWarning("BackInput() else");
        }
    }

    public void EnterInput()
    {
        if (calstate == CalStates.operand1Inputting)
        {
            Debug.LogWarning("EnterInput() not valid for operand1Inputting");
        }
        else if (calstate == CalStates.operatorInputted)
        {
            Debug.LogWarning("EnterInput() not valid for operatorInputted");
        }
        else if (calstate == CalStates.operand2Inputting)
        {
            solution = solve(operand1, operand2, oper);
            display = $"{operand1} {oper} {operand2} = {solution}";
            calstate = CalStates.solved;
        }
        else if (calstate == CalStates.solved)
        {
            Debug.LogWarning("EnterInput() not valid for solved");
        }
        else
        {
            Debug.LogWarning("EnterInput() else");
        }
    }
    
    private void clear()
    {
        
        operand1 = 0;
        operand2 = 0;
        oper = Operators.none;
        solution = 0;
    }

    private int solve(int operand1, int operand2, Operators oper)
    {
        switch (oper)
        {
            case Operators.plus:
                return operand1 + operand2;
            case Operators.minus:
                return operand1 - operand2;
            case Operators.multi:
                return operand1 * operand2;
            case Operators.div:
                return operand1 / operand2;
            default:
                Debug.LogWarning("operator not implemented: " + oper);
                return 0;
                

        }
    }
    
}
