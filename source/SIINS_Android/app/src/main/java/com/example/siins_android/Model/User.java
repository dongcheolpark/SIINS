package com.example.siins_android.Model;

import android.animation.IntArrayEvaluator;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.example.siins_android.Func.Network;
import com.google.firebase.messaging.FirebaseMessaging;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.net.MalformedURLException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

public class User {
    private static User user;
    private String id,pw;
    private boolean noti;
    private ArrayList<String> categories;

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

    public void setCategories() throws JSONException, MalformedURLException {
        JSONObject json = new JSONObject();

        json.accumulate("id",this.id);
        json.accumulate("pw",this.pw);
        Network a = new Network("SelectedCategories");
        JSONArray b = a.PostJsonconnection(json);
        for(int i = 0; i<b.length();i++) {
            JSONObject item = b.getJSONObject(i);
            try {
                categories.add(item.getString("catUSelect"));
            }
            catch(Exception e){
                int xcd = 10;
            }
        }
        return;
    }

    public static void setnoti(boolean a) {
        if(user == null) {
            user = new User();
        }
        user.noti = a;
        User.Get().notification();
    }

    public void notification() {
        if (!noti) {
            if(categories != null) {
                for (String item : categories)
                    FirebaseMessaging.getInstance().unsubscribeFromTopic(item);
            }
            return;
        }
        if(categories == null) {
            categories = new ArrayList<String>();
            try {
                setCategories();
            } catch (JSONException e) {
                e.printStackTrace();
            } catch (MalformedURLException e) {
                e.printStackTrace();
            }
        }
        for(String item : categories)
            FirebaseMessaging.getInstance().subscribeToTopic(item);

        return;

    }

    public String Getid() {
        return id;
    }
    public String Getpw() {
        return pw;
    }

}
