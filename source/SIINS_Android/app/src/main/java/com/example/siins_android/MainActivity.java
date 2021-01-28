package com.example.siins_android;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ListView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.net.MalformedURLException;
import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    ArrayList<SampleData> Homeworklist;
    ListView listView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        ActionBar ab = getSupportActionBar() ;
        ab.setTitle("HomeworkList");
        listView = (ListView)findViewById(R.id.listView);

        try {
            this.InitializeHomeworkData();
        } catch (MalformedURLException e) {
            e.printStackTrace();
        } catch (JSONException e) {
            e.printStackTrace();
        }

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.actionbar_action, menu) ;
        return true ;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.action_setting :
                Intent intent = new Intent(MainActivity.this, PreferenceActivity.class);
                startActivity(intent);
                return true ;
            case R.id.action_refresh :
                try {
                    this.InitializeHomeworkData();
                } catch (MalformedURLException e) {
                    e.printStackTrace();
                } catch (JSONException e) {
                    e.printStackTrace();
                }
                return true ;
            // ...
            // ...
            default :
                return super.onOptionsItemSelected(item) ;
        }
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
        final ListAdapter c = new ListAdapter(this,Homeworklist);
        listView.setAdapter(c);
    }
}