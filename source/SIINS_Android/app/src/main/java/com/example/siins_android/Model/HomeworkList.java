package com.example.siins_android.Model;

import android.content.Context;

import com.example.siins_android.Func.Network;
import com.example.siins_android.Model.SampleData;
import com.example.siins_android.Model.User;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.net.MalformedURLException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;

public class HomeworkList {
    private static ArrayList<SampleData> Homeworklist;
    public HomeworkList() {

    }
    public static ArrayList<SampleData> GetList() {
        if(Homeworklist == null) {
            Homeworklist = new ArrayList<SampleData>();
        }
        return Homeworklist;
    }

    public static void InitializeHomeworkData(Context _context) throws MalformedURLException, JSONException, ParseException {
        Homeworklist = new ArrayList<SampleData>();
        Network a = new Network("Homework");
        User user = User.Get();
        JSONObject json = new JSONObject();
        json.accumulate("id",user.Getid());
        json.accumulate("pw",user.Getpw());


        JSONArray b = a.PostJsonconnection(json);
        for(int i = 0; i<b.length();i++) {
            JSONObject item = b.getJSONObject(i);

            SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd\'T\'HH:mm:ss");
            try {
                Homeworklist.add(new SampleData(item.getString("title"), item.getString("subject"),
                        item.getString("contents"), format.parse(item.getString("date")), item.getString("t_Name")));
            }
            catch(Exception e){
                int xcd = 10;
            }
        }
    }
}
