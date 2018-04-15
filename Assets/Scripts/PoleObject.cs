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

    public ArrayList listOfDamagedEquip = new ArrayList();

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
            int tempRand = Random.Range(0, 2);
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
            Debug.Log("it got here");
            assignOneRandomEquip();
        }
        else if (getNumberOfDamagedEquip() == 2) {
            assignTwoRandomEquip();
        }
        else if (getNumberOfDamagedEquip() == 3) {
            assignThreeRandomEquip();
        }
        else
            Debug.Log("inner loop bug");
    }

    //capacitor bank + fuse
    //transformer 
    //recloser
    //afs
    //pothead + dcswitch
    //generateAutomaticLineSwitch
    //la

    public void assignOneRandomEquip() {
        //for capacitor bank
        if (getEquipmentType() == 0) {
            return;
        }
        if (getEquipmentType() == 1)
        {
            int tempEquipType = Random.Range(0, 3);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0)
            {
                setCapacitorBank(tempSev);
                //listOfDamagedEquip.Add("Capacitorbank");
                //listOfDamagedEquip.Add("level " + tempSev);
            }
            else if (tempEquipType == 1)
            {
                setFuseSwitch(tempSev);
                //listOfDamagedEquip.Add("Fuseswitch");
                //listOfDamagedEquip.Add("level " + tempSev);
            }
            else if (tempEquipType == 2)
            {
                randomDump();
            }
        }
        //Transformer
        else if (getEquipmentType() == 2)
        {
            int tempEquipType = Random.Range(0, 3);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0)
            {
                setTransformer(tempSev);
                //listOfDamagedEquip.Add("Transformer");
                //listOfDamagedEquip.Add("level " + tempSev);
            }
            else if (tempEquipType == 1)
            {
                setFuseSwitch(tempSev);
                //listOfDamagedEquip.Add("Fuseswitch");
                //listOfDamagedEquip.Add("level " + tempSev);
            }
            else if (tempEquipType == 2)
            {
                randomDump();
            }
        }
        //Recloser
        else if (getEquipmentType() == 3)
        {
            int tempEquipType = Random.Range(0, 2);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0)
            {
                setRecloser(tempSev);
                //listOfDamagedEquip.Add("Recloser");
                //listOfDamagedEquip.Add("level " + tempSev);
            }
            else if (tempEquipType == 1)
                randomDump();
        }
        //AFS
        else if (getEquipmentType() == 4)
        {
            int tempEquipType = Random.Range(0, 2);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0)
            {
                setAfs(tempSev);
                //listOfDamagedEquip.Add("Afs");
                //listOfDamagedEquip.Add("level " + tempSev);
            }
            else if (tempEquipType == 1)
                randomDump();
        }
        //Pothead + dcswitch
        else if (getEquipmentType() == 5)
        {
            int tempEquipType = Random.Range(0, 3);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0)
            {
                setPothead(tempSev);
                //listOfDamagedEquip.Add("Pothead");
                //listOfDamagedEquip.Add("level " + tempSev);
            }
            else if (tempEquipType == 1)
            {
                setDisconnectSwitch(tempSev);
                //listOfDamagedEquip.Add("Disconnectswitch");
                //listOfDamagedEquip.Add("level " + tempSev);
            }
            else if (tempEquipType == 2)
                randomDump();
        }
        //Automatic line Switch
        else if (getEquipmentType() == 6)
        {
            int tempEquipType = Random.Range(0, 2);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0)
            {
                setAutomaticLineSwitch(tempSev);
                //listOfDamagedEquip.Add("Automaticlineswitch");
                //listOfDamagedEquip.Add("level " + tempSev);
            }
            else if (tempEquipType == 1)
                randomDump();
        }
        //Lightning Arrestor
        else if (getEquipmentType() == 7)
        {
            int tempEquipType = Random.Range(0, 2);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0)
            {
                setLightningArrestor(tempSev);
                //listOfDamagedEquip.Add("Lightningarrestor");
                //listOfDamagedEquip.Add("level " + tempSev);
            }
            else if (tempEquipType == 1)
                randomDump();
        }
        else
            Debug.Log("Bug happened");
        //writeList(listOfDamagedEquip);
    }

    public void assignTwoRandomEquip() {
    }

    public void assignThreeRandomEquip() {
    }


    public void randomCapacitor() {
        int n = 0;
        List<string> tempArray = new List<string>();

        //CapacitorBank
        while (n < getNumberOfDamagedEquip() ) {

            start:
            int tempEquipType = Random.Range(0, 3);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0 && !tempArray.Contains("Capictorbank"))
            {
                setCapacitorBank(tempSev);
                tempArray.Add("Capictorbank");
                n++;
            }
            else if (tempEquipType == 1 && !tempArray.Contains("Fuseswitch"))
            {
                setFuseSwitch(tempSev);
                tempArray.Add("Fuseswitch");
                n++;
            }
            else if (tempEquipType == 2 )
            {
                int tempEquip = Random.Range(2, 10);
                int tempInt = Random.Range(1, 4);
                if (tempEquip == 2 && !tempArray.Contains("Insulator"))
                {
                    setInsulatorDamage(tempInt);
                    tempArray.Add("Insulator");
                    n++;
                }
                else if (tempEquip == 3 && !tempArray.Contains("Fci"))
                {
                    setFci(tempInt);
                    tempArray.Add("Fci");
                    n++;
                }
                else if (tempEquip == 4 && !tempArray.Contains("Splice"))
                {
                    setSplice(true);
                    tempArray.Add("Splice");
                    n++;
                }
                else if (tempEquip == 5 && !tempArray.Contains("Balloon"))
                {
                    setBallon(true);
                    tempArray.Add("Balloon");
                    n++;
                }
                else if (tempEquip == 6 && !tempArray.Contains("Palm")) 
                {
                    setPalm(tempInt);
                    tempArray.Add("Palm");
                    n++;
                }
                else if (tempEquip == 7 && !tempArray.Contains("Nest"))
                {
                    setNest(true);
                    tempArray.Add("Nest");
                    n++;
                }
                else if (tempEquip == 8 && !tempArray.Contains("Oak"))
                {
                    setOak(tempInt);
                    tempArray.Add("Oak");
                    n++;
                }
                else if (tempEquip == 9 && !tempArray.Contains("Kite"))
                {
                    setKite(true);
                    tempArray.Add("Kite");
                    n++;
                }
            }
            else
                goto start;
        }

    }

    public void randomDump()
    {
        int tempEquipType = Random.Range(2,10);
        int tempSev = Random.Range(1,4);
        if (tempEquipType == 2)
        {
            setInsulatorDamage(tempSev);
            //listOfDamagedEquip.Add("Insulator");
            //listOfDamagedEquip.Add("level " + tempSev);
        }
        else if (tempEquipType == 3)
        {
            setFci(tempSev);
            //listOfDamagedEquip.Add("Fci");
            //listOfDamagedEquip.Add("level " + tempSev);
        }
        else if (tempEquipType == 4)
        {
            setSplice(true);
            //listOfDamagedEquip.Add("Splice");
            //listOfDamagedEquip.Add("level " + tempSev);
        }
        else if (tempEquipType == 5)
        {
            setBallon(true);
            //listOfDamagedEquip.Add("Balloon");
            //listOfDamagedEquip.Add("level " + tempSev);
        }
        else if (tempEquipType == 6)
        {
            setPalm(tempSev);
            //listOfDamagedEquip.Add("Palm");
            //listOfDamagedEquip.Add("level " + tempSev);
        }
        else if (tempEquipType == 7)
        {
            setNest(true);
            //listOfDamagedEquip.Add("Nest");
            //listOfDamagedEquip.Add("level " + tempSev);
        }
        else if (tempEquipType == 8)
        {
            setOak(tempSev);
            //listOfDamagedEquip.Add("Oak");
            //listOfDamagedEquip.Add("level " + tempSev);
        }
        else if (tempEquipType == 9)
        {
            setKite(true);
            //listOfDamagedEquip.Add("Kite");
            //listOfDamagedEquip.Add("level " + tempSev);
        }
    }

    public void writeList(ArrayList list) {
        foreach (int i in list) {
            Debug.Log(i);
        }

    }

}
