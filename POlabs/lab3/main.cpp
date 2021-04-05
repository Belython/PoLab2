/**
 * @file main.cpp
 * @author your name (you@domain.com)
 * @brief 
 * @version 0.1
 * @date 2021-02-25
 * 
 * @copyright Copyright (c) 2021
 * 
 */

#include<iostream>
#include <fstream>
#include <string>
#include <stdlib.h>
#include <vector>

using namespace std;

double Summa(double x, double y)
{
    return x + y;
}

double Differense(double x, double y)
{
    return x - y;
}

double Multiplication(double x, double y)
{
    return x * y;
}

double Division(double x, double y)
{
    try 
    {
        if (y == 0)
            throw "Division 0"; 
 
        return x / y;
    }
    catch (const char* exception)
    {
        cerr << "Error: " << exception;
    }
}

int main ()
{
    bool flag = true;
    double x;
    double y;
    char s;
    freopen ("test.txt", "r", stdin);
    freopen ("answer.txt", "w", stdout);
    while (cin >> s)
    {
        switch (s)
        {
            case '+':
                cin >> x;
                cin >> y;
                cout << Summa(x, y) << endl;
                break;
            case '-':
                cin >> x;
                cin >> y;
                cout << Differense(x, y) << endl;
                break;
            case '*':
                cin >> x;
                cin >> y;
                cout << Multiplication(x, y) << endl;
                break;
            case '/':
                cin >> x;
                cin >> y;
                cout << Division(x, y) << endl;
                break;
            default:
                break;
        }
    }   
    return 0;
}