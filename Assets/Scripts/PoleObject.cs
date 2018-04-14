using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleObject {

    public int poleMaterial;
    public string insulatorType;    //V, M, T, SC, DC
    public int InsulatorA;
    public int InsulatorB;
    public int InsulatorC;

    public string disconnectSwitch;
    public string capacitorBank;
    public string fuseSwitch;
    public string lightningArrester;
    public string recloser;
    public string als;
    public string pothead;
    public bool splice;
    public bool jumper;
    public bool palm;
    public bool oak;
    public bool balloon;
    public bool nest;

    public int equipmentType;
    public int transformerCount;

    public PoleObject(){
        poleMaterial =0;
        insulatorType="null";
        InsulatorA = 0;
        InsulatorB = 0;
        InsulatorC = 0;

        disconnectSwitch = "null";
        capacitorBank = "null";
        fuseSwitch = "null";
        lightningArrester = "null";
        recloser = "null";
        als = "null";
        pothead = "null";
        splice = false;
        jumper = false;
        palm = false;
        oak = false;
        balloon = false;
        nest = false;
        equipmentType = 0;
        transformerCount = 0;
    }

    public void setPoleMaterial(int i) {
        this.poleMaterial = i;
    }
    public int getPoleMaterial(){
        return this.poleMaterial;
    }

    public void setInsulatorType(string i) {
        this.insulatorType = i;
    }
    public string getInsulatorType() {
        return this.insulatorType;
    }

    public void setEquipmentType(int i) {
        this.equipmentType = i;
        if (i == 2){
            setTransformerCount(Random.Range(1,4));
        }
    }
    public int getEquipmentType() {
        return this.equipmentType;
    }

    public void setTransformerCount(int i){
        this.transformerCount = i;
    }
    public int getTransformerCount() {
        return this.transformerCount;
    }

}
