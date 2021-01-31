package com.example.siins_android.Acitivty;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.webkit.WebView;
import android.widget.TextView;

import com.example.siins_android.R;
import com.example.siins_android.Model.SampleData;

import java.text.SimpleDateFormat;

public class DetailsActivity extends AppCompatActivity {
    TextView title,subject,teacher,date;
    WebView content;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_details);
        title = (TextView)findViewById(R.id.title);
        subject = (TextView)findViewById(R.id.subject);
        teacher = (TextView)findViewById(R.id.teacher);
        date = (TextView)findViewById(R.id.date);
        content = (WebView)findViewById(R.id.content);

        SampleData data = (SampleData)getIntent().getSerializableExtra("detail");

        ActionBar ab = getSupportActionBar() ;
        ab.setTitle(data.GetTitle());

        SimpleDateFormat format = new SimpleDateFormat("yyyy년 MM월 dd일 까지");

        title.setText(data.GetTitle());
        subject.setText(data.GetSubject());
        teacher.setText(data.GetTeacher());
        date.setText(format.format(data.GetDate()));
        content.loadData(data.GetContents(),"text/html;charset=utf-8","UTF-8");
    }
}