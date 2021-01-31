package com.example.siins_android;

import java.io.Serializable;
import java.util.Date;

import javax.security.auth.Subject;

public class SampleData implements Serializable {
    private String Title;
    private String Subject;
    private String Teacher;
    private String Contents;
    private java.util.Date Date;

    public SampleData(String Title, String Subject,String Contents,Date Date,String Teacher) {
        this.Title = Title;
        this.Subject = Subject;
        this.Contents = Contents;
        this.Date = Date;
        this.Teacher = Teacher;
    }

    public String GetTitle(){
        return Title;
    }
    public String GetSubject(){
        return Subject;
    }
    public String GetContents(){
        return Contents;
    }
    public Date GetDate(){
        return Date;
    }
    public String GetTeacher(){
        return Teacher;
    }

}