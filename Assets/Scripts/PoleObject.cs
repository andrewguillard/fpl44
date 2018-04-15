using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleObject {

    public int numberOfDamagedEquip;

    public int poleMaterial;        //0 = wood, 1 = concrete
    public string insulatorType;    //V, M, T, SC, DC   
    public int insulatorMaterial;   //0 for ..., 1 for polymer
    public int insulatorA;
    public int insulatorB;
    public int insulatorC;
    public int insulatorDamage;

    public int deadendInsulator;


    public int capacitorBank;
    public int transformer;
    public int fuseSwitch;
    public int lightningArrester;
    public int recloser;
    public int afs;
    public int automaticLineSwitch;
    public int pothead;
    public int disconnectSwitch;
    public int palm;
    public int oak;
    public int downguy;
    public int fci;

    public bool splice;
    public bool balloon;
    public bool nest;
    public bool kite;

    public int equipmentType;
    public int transformerCount;

    public List<string> listOfDamagedEquip = new List<string>();

    public PoleObject() {

        numberOfDamagedEquip = 0;

        poleMaterial = 0;
        insulatorType = "null";
        insulatorMaterial = 0;
        insulatorA = 0;
        insulatorB = 0;
        insulatorC = 0;
        insulatorDamage = 0;

        deadendInsulator = 0;

        capacitorBank = 0;
        transformer = 0;
        fuseSwitch = 0;
        lightningArrester = 0;
        recloser = 0;
        afs = 0;
        automaticLineSwitch = 0;
        pothead = 0;
        disconnectSwitch = 0;
        palm = 0;
        oak = 0;
        downguy = 0;
        fci = 0;

        splice = false;
        balloon = false;
        nest = false;
        kite = false;

        equipmentType = 0;
        transformerCount = 0;

        listOfDamagedEquip = null;

    }
    public void setNumberOfDamagedEquip(int i)
    {
        this.numberOfDamagedEquip = i;
    }
    public int getNumberOfDamagedEquip()
    {
        return this.numberOfDamagedEquip;
    }

    public void setPoleMaterial(int i) {
        this.poleMaterial = i;
    }
    public int getPoleMaterial() {
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
        if (i == 2) {
            setTransformerCount(Random.Range(1, 4));
        }
    }
    public int getEquipmentType() {
        return this.equipmentType;
    }

    public void setInsulatorDamage(int i)
    {
        this.insulatorDamage = i;
    }
    public int getInsulatorDamage()
    {
        return this.insulatorDamage;
    }

    public void setCapacitorBank(int i)
    {
        this.capacitorBank = i;
    }
    public int getCapacitorBank()
    {
        return this.capacitorBank;
    }
    public void setFuseSwitch(int i){
        this.fuseSwitch = i;
    }
    public int getFuseSwitch()
    {
        return this.fuseSwitch;
    }
    public void setTransformerCount(int i) {
        this.transformerCount = i;
    }
    public int getTransformerCount() {
        return this.transformerCount;
    }

    public void setTransformer(int i)
    {
        this.transformer = i;
    }
    public int getTransformer()
    {
        return this.transformer;
    }

    public void setRecloser(int i)
    {
        this.recloser = i;
    }
    public int getRecloser()
    {
        return this.recloser;
    }

    public void setAfs(int i)
    {
        this.afs = i;
    }
    public int getAfs()
    {
        return this.afs;
    }

    public void setPothead(int i)
    {
        this.pothead = i;
    }
    public int getPothead()
    {
        return this.pothead;
    }

    public void setDisconnectSwitch(int i)
    {
        this.disconnectSwitch = i;
    }
    public int getDisconnectSwitch()
    {
        return this.disconnectSwitch;
    }

    public void setAutomaticLineSwitch(int i)
    {
        this.automaticLineSwitch = i;
    }
    public int getAutomaticLineSwitch()
    {
        return this.automaticLineSwitch;
    }
    public void setLightningArrestor(int i)
    {
        this.lightningArrester = i;
    }
    public int getLightningArrestor()
    {
        return this.lightningArrester;
    }


    public void setFci(int i)
    {
        this.fci = i;
    }

    public int getFci(int i)
    {
        return this.fci;
    }


    public void setPalm(int i) {
        this.palm = i;
    }

    public int getPalm(int i) {
        return this.palm;
    }

    public void setOak(int i)
    {
        this.palm = i;
    }

    public int getOak(int i)
    {
        return this.palm;
    }

    public void setBallon(bool i)
    {
        this.balloon =true;
    }

    public bool getBalloon(bool i)
    {
        return this.balloon;
    }

    public void setSplice(bool i)
    {
        this.balloon = true;
    }

    public bool getSplice(bool i)
    {
        return this.splice;
    }

    public void setNest(bool i)
    {
        this.nest = true;
    }

    public bool getNest(bool i)
    {
        return this.nest;
    }

    public void setKite(bool i)
    {
        this.kite = true;
    }

    public bool getkite(bool i)
    {
        return this.kite;
    }

    public void setDamageToItems() {
        //NO DAMAGE
        if (getNumberOfDamagedEquip() == 0) {
            int tempRand = Random.Range(0, 4);
            if (tempRand == 0)
                setPalm(0);
            else if (tempRand == 1)
                setOak(0);
            else if (tempRand == 2)
                setFci(0);
            else if (tempRand == 3)
                return;
        }
        else if (getNumberOfDamagedEquip() == 1) {
            assignOneRandomEquip();
        }
        else if (getNumberOfDamagedEquip() == 2) {
            assignTwoRandomEquip();
        }
        else if (getNumberOfDamagedEquip() == 3) {
            assignThreeRandomEquip();
        }

    }

    //capacitor banmk + fuse
    //transformer 
    //recloser
    //afs
    //pothead + dcswitch
    //generateAutomaticLineSwitch
    //la

    public void assignOneRandomEquip() {
        //for capacitor bank
        if (getEquipmentType() == 1) {
            int tempEquipType = Random.Range(0, 3);
            int tempSev = Random.Range(1,4);
            if (tempEquipType == 0)
            {
                setCapacitorBank(tempSev);
            }
            else if (tempEquipType == 1)
            {
                setFuseSwitch(tempSev);
            }
            else if (tempEquipType == 2) {
                randomDump();
            }
        }
        //Transformer
        else if (getEquipmentType() == 2) {
            int tempEquipType = Random.Range(0, 3);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0)   {
                setTransformer(tempSev);
            }
            else if (tempEquipType == 1) {
                setFuseSwitch(tempSev);
            }
            else if (tempEquipType == 2)  {
                randomDump();
            }
        }
        //Recloser
        else if (getEquipmentType() == 3) {
            int tempEquipType = Random.Range(0, 2);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0) {
                setRecloser(tempSev);
            }
            else if(tempEquipType == 1)
                randomDump();
        }
        //AFS
        else if (getEquipmentType() == 4) {
            int tempEquipType = Random.Range(0, 2);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0)  {
                setAfs(tempSev);
            }
            else if (tempEquipType == 1)
                randomDump();
        }
        //Pothead + dcswitch
        else if (getEquipmentType() == 5) {
            int tempEquipType = Random.Range(0, 3);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0)  {
                setPothead(tempSev);
            }
            else if (tempEquipType == 1) {
                setDisconnectSwitch(tempSev);
            }
            else if (tempEquipType == 2)
                randomDump();
        }
        //Automatic line Switch
        else if (getEquipmentType() == 6) {
            int tempEquipType = Random.Range(0, 2);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0)
            {
                setAutomaticLineSwitch(tempSev);
            }
            else if (tempEquipType == 1)
                randomDump();
        }
        //Lightning Arrestor
        else if (getEquipmentType() == 7) {
            int tempEquipType = Random.Range(0, 2);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0)
            {
                setLightningArrestor(tempSev);
            }
            else if (tempEquipType == 1)
                randomDump();
        }
    }

    public void assignTwoRandomEquip() {


    }

    public void assignThreeRandomEquip() {


    }

    public void randomDump()
    {
        int tempEquipType = Random.Range(2,10);
        int tempSev = Random.Range(1,4);
        if (tempEquipType == 2)
        {
            setInsulatorDamage(tempSev);
        }
        else if (tempEquipType == 3)
        {
            setFci(tempSev);
        }
        else if (tempEquipType == 4)
        {
            setSplice(true);
        }
        else if (tempEquipType == 5)
        {
            setBallon(true);
        }
        else if (tempEquipType == 6)
        {
            setPalm(tempSev);
        }
        else if (tempEquipType == 7)
        {
            setNest(true);
        }
        else if (tempEquipType == 8)
        {
            setOak(tempSev);
        }
        else if (tempEquipType == 9)
        {
            setKite(true);
        }
    }


}
