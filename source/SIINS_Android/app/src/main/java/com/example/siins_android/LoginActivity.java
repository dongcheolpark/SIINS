package com.example.siins_android;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import java.net.MalformedURLException;

public class LoginActivity extends AppCompatActivity {
    EditText id, pwd;
    Button btn;
    CheckBox auto_login;
    Boolean loginAuto;
    String loginId, loginPwd;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        id = (EditText) findViewById(R.id.inputId);
        pwd = (EditText) findViewById(R.id.inputPwd);
        btn = (Button) findViewById(R.id.loginBtn);
        auto_login = (CheckBox) findViewById(R.id.auto_login);
        SharedPreferences auto = getSharedPreferences("auto", Activity.MODE_PRIVATE);
        loginId = auto.getString("inputId", null);
        loginPwd = auto.getString("inputPwd", null);
        TextView text = (TextView)findViewById(R.id.register);
        text.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse("http://siins.site/users/Create"));
                startActivity(intent);
            }
        });

        if (loginId != null && loginPwd != null) {
            User.Set(loginId,loginPwd);
            Toast.makeText(LoginActivity.this, loginId + "님 자동로그인 입니다.", Toast.LENGTH_SHORT).show();
            Intent intent = new Intent(LoginActivity.this, MainActivity.class);
            startActivity(intent);
            finish();
        } // 자동 로그인
        else if (loginId == null && loginPwd == null) {
            btn.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    try {
                        Network network = new Network("users/"+id.getText() +"/" + pwd.getText());
                        if(network.Strconnection().equals("true")) {
                            User.Set(id.getText().toString(),pwd.getText().toString());
                            if (auto_login.isChecked()) {
                                SharedPreferences auto = getSharedPreferences("auto", Activity.MODE_PRIVATE);
                                SharedPreferences.Editor autoLogin = auto.edit();
                                autoLogin.putString("inputId", id.getText().toString());
                                autoLogin.putString("inputPwd", pwd.getText().toString());
                                autoLogin.commit();

                                Toast.makeText(LoginActivity.this, id.getText().toString() + "님 환영합니다.", Toast.LENGTH_SHORT).show();
                                Intent intent = new Intent(LoginActivity.this, MainActivity.class);
                                startActivity(intent);
                            } // 로그인 정보 저장
                            else {
                                Toast.makeText(LoginActivity.this, id.getText().toString() + "님 환영합니다.", Toast.LENGTH_SHORT).show();
                                Intent intent = new Intent(LoginActivity.this, MainActivity.class);
                                startActivity(intent);
                            } // 로그인
                            finish();
                        }
                        else {
                            Toast.makeText(LoginActivity.this, "아이디나 비밀번호가 일치하지 않습니다.", Toast.LENGTH_SHORT).show();
                        }

                    }
                    catch (MalformedURLException e) {
                        e.printStackTrace();
                    }
                    catch (Exception e) {
                        Toast.makeText(LoginActivity.this, "오류", Toast.LENGTH_SHORT).show();
                    }
                }
            });
        }
    }

}
