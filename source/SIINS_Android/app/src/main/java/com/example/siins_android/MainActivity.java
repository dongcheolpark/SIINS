package com.example.siins_android;

import androidx.annotation.NonNull;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.messaging.FirebaseMessaging;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.net.MalformedURLException;
import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    private static final String TAG = "MainActivity";
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
        FirebaseMessaging.getInstance().subscribeToTopic("1");

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView parent, View v, int position, long id) {
                SampleData item = (SampleData) parent.getItemAtPosition(position);
                Intent intent = new Intent(MainActivity.this, DetailsActivity.class);
                intent.putExtra("detail",item);
                startActivity(intent);
            }
        });

        FirebaseMessaging.getInstance().getToken()
                .addOnCompleteListener(new OnCompleteListener<String>() {
                    @Override
                    public void onComplete(@NonNull Task<String> task) {
                        if (!task.isSuccessful()) {
                            Log.w(TAG, "Fetching FCM registration token failed", task.getException());
                            return;
                        }

                        // Get new FCM registration token
                        String token = task.getResult();
                        // Log and toast
                        String msg = getString(R.string.msg_token_fmt,token);
                        Log.d(TAG, msg);
                        Toast.makeText(MainActivity.this, msg, Toast.LENGTH_SHORT).show();
                    }
                });


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
            Homeworklist.add(new SampleData(item.getString("title"),item.getString("subject"),
                                            item.getString("contents"),item.getString("date"), item.getString("t_Name")));
        }
        final ListAdapter c = new ListAdapter(this,Homeworklist);
        listView.setAdapter(c);
    }
}