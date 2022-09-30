using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SQL : MonoBehaviour
{
    void Start()
    {
        //�����������
        //charset=utf8���Ҫд����Ȼ���ܻᱨ��                                 
        string constr = "server=localhost;User Id=root;password=root;Database=scores;charset=utf8";

        //��������
        MySqlConnection mycon = new MySqlConnection(constr);
        //������
        mycon.Open();

        //��������
        MySqlCommand mycmd = new MySqlCommand("insert into studentscores(id,name,score) values (3,'lisi',100)", mycon);
        if (mycmd.ExecuteNonQuery() > 0)
        {
            print("Insert success!");
        }

        //��ѯ����
        string selstr = "select * from studentscores";
        MySqlCommand myselect = new MySqlCommand(selstr, mycon);

        DataSet ds = new DataSet();

        try
        {
            MySqlDataAdapter da = new MySqlDataAdapter(selstr, mycon);
            da.Fill(ds);
            print("Query success!");
            print(ds.Tables[0].Rows[0][0]);
        }
        catch (Exception e)
        {
            throw new Exception("SQL:" + selstr + "\n" + e.Message.ToString());
        }
        //�ر�����
        mycon.Close();
    }
}
