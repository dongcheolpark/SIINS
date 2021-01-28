package com.example.siins_android;

import javax.security.auth.Subject;

public class SampleData {
    private String Title;
    private String Subject;

    public SampleData(String Title, String Subject) {
        this.Title = Title;
        this.Subject = Subject;
    }

    public String GetTitle(){
        return Title;
    }
    public String GetSubject(){
        return Subject;
    }

}