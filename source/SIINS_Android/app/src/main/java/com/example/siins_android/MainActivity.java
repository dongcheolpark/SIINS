package com.example.siins_android;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ListView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.net.MalformedURLException;
import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    ArrayList<SampleData> Homeworklist;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        try {
            this.InitializeHomeworkData();
        } catch (MalformedURLException e) {
            e.printStackTrace();
        } catch (JSONException e) {
            e.printStackTrace();
        }

        ListView listView = (ListView)findViewById(R.id.listView);

        final ListAdapter a = new ListAdapter(this,Homeworklist);
        listView.setAdapter(a);

    }

    public void InitializeHomeworkData() throws MalformedURLException, JSONException {

        Homeworklist = new ArrayList<SampleData>();

        Network a = new Network("Homework");
        User user = User.Get();
        JSONObject json = new JSONObject();
        json.accumulate("id",user.Getid());
        json.accumulate("pw",user.Getpw());


        JSONArray b = a.PostJsonconnection(json);
        for(int i = 0; i<b.length();i++) {
            JSONObject item = b.getJSONObject(i);
            Homeworklist.add(new SampleData(item.getString("title"),item.getString("subject")));
        }
    }
}