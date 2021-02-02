package com.example.siins_android.Acitivty;

import androidx.annotation.NonNull;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import android.app.ProgressDialog;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ListView;

import com.example.siins_android.Fragment.CheckboxFragment;
import com.example.siins_android.Fragment.EventFragment;
import com.example.siins_android.Fragment.ListFragment;
import com.example.siins_android.Model.HomeworkList;
import com.example.siins_android.Model.SampleData;
import com.example.siins_android.Model.User;
import com.example.siins_android.R;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.google.firebase.messaging.FirebaseMessaging;

import org.json.JSONException;

import java.net.MalformedURLException;
import java.text.ParseException;
import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    private static final String TAG = "MainActivity";
    ArrayList<SampleData> Homeworklist;
    ListView listView;
    FragmentTransaction fragmentTransaction;
    ProgressDialog progressDialog;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ActionBar ab = getSupportActionBar() ;
        ab.show();
        ab.setTitle("숙제 리스트");
        User.setnoti(true);

        BottomNavigationView a = (BottomNavigationView)findViewById(R.id.bottom_nav);

        FragmentManager fm = getSupportFragmentManager();
        fragmentTransaction = fm.beginTransaction();
        fragmentTransaction.replace(R.id.fragmentMain,new ListFragment());
        fragmentTransaction.commit();

        a.setOnNavigationItemSelectedListener(new BottomNavigationView.OnNavigationItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                FragmentManager fm = getSupportFragmentManager();
                fragmentTransaction = fm.beginTransaction();
                try {
                    switch (item.getItemId()) {
                        case R.id.action_list:
                            fragmentTransaction.replace(R.id.fragmentMain, new ListFragment());
                            fragmentTransaction.commit();
                            return true;
                        case R.id.action_event:
                            fragmentTransaction.replace(R.id.fragmentMain, new EventFragment());
                            fragmentTransaction.commit();
                            return true;
                        case R.id.action_checkbox:
                            Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse("http://siins.site/Student/ChangeCat"));
                            startActivity(intent);
                            return true;
                    }
                    return false;
                }
                catch (Exception e){
                    return false;
                }

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
                        //Toast.makeText(MainActivity.this, msg, Toast.LENGTH_SHORT).show();
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
                FragmentManager fm = getSupportFragmentManager();
                try {
                    HomeworkList.InitializeHomeworkData(MainActivity.this);
                } catch (MalformedURLException e) {
                    e.printStackTrace();
                } catch (JSONException e) {
                    e.printStackTrace();
                } catch (ParseException e) {
                    e.printStackTrace();
                }
                fragmentTransaction = fm.beginTransaction();
                fragmentTransaction.replace(R.id.fragmentMain,new ListFragment());
                fragmentTransaction.commit();
                return true ;
            // ...
            // ...
            default :
                return super.onOptionsItemSelected(item) ;
        }
    }

    public void loading() {
        //로딩
        new android.os.Handler().postDelayed(
                new Runnable() {
                    public void run() {
                        progressDialog = new ProgressDialog(MainActivity.this);
                        progressDialog.setIndeterminate(true);
                        progressDialog.setMessage("잠시만 기다려 주세요");
                        progressDialog.show();
                    }
                }, 0);
    }

    public void loadingEnd() {
        new android.os.Handler().postDelayed(
                new Runnable() {
                    @Override
                    public void run() {
                        progressDialog.dismiss();
                    }
                }, 0);
    }

}