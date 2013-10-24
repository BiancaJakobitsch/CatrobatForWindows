#pragma once

#include <map>
#include "Object.h"
#include "CompassProvider.h"
#include "RotationProvider.h"

class FormulaTree;

enum Childs {
    LeftChild, 
    RightChild, 
    LeftAndRightChild, 
    NoChild
};

typedef float(RotationProvider::*pt2Func)(ROTATION_PROVIDER_TYPES, float);

class Interpreter
{
private:
    static Interpreter *__instance;

public:
    Interpreter(void);
    ~Interpreter(void);
    static Interpreter *Instance();

    double EvaluateFormula(FormulaTree *tree, Object *object);

    int EvaluateFormulaToInt(FormulaTree *tree, Object *object);
    float EvaluateFormulaToFloat(FormulaTree *tree, Object *object);
    bool EvaluateFormulaToBool(FormulaTree *tree, Object *object);
    
    RotationProvider* GetRotationProvider(FormulaTree *tree, Object *object);

    void ReadAcceleration();
    double ReadSensor();

private:
    // Sensors
    Windows::Devices::Sensors::Accelerometer^ m_accelerometer;
    Windows::Devices::Sensors::AccelerometerReading^ m_accReading;

    // HelperFunctions
    double InterpretOperator(FormulaTree *tree, Object *object);
    double InterpretFunction(FormulaTree *tree, Object *object);
    bool TestChilds(FormulaTree *tree, Childs childs);
    double CalculateMax(double value1, double value2);
    double CalculateMin(double value1, double value2);
    double CalculateRand(double value1, double value2);
    double CalculateModulo(double dividend, double divisor);
    double CalculateCosinus(double degree);
    double RoundDoubleToInt(double value);
};
