package com.example.siins_android.Model;

public class User {
    private static User user;
    private String id,pw;

    private User() {}

    public static User Get() {
        if(user == null) {
            user = new User();
        }
        return user;
    }

    public static void Set(String id, String pw) {
        if(user == null) {
            user = new User();
        }
        user.id = id;
        user.pw = pw;
    }

    public String Getid() {
        return id;
    }
    public String Getpw() {
        return pw;
    }

}
