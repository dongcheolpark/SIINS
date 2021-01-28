package com.example.siins_android;
import android.os.AsyncTask;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;


public class Network {
    private URL url;
    private ApiServerConn Conn;

    public Network(String string) throws MalformedURLException {
        url = new URL("http://siins.site:120/api/" + string);
    }

    public JSONArray GetJsonconnection() {
        try {
            Conn = new ApiServerConn(url,"GET");
            return new JSONArray(Conn.execute().get());
        }
        catch (Exception e) {

        }
        return null;
    }
    public JSONArray PostJsonconnection(JSONObject json) {
        try {
            Conn = new ApiServerConn(url,"POST",json);
            return new JSONArray(Conn.execute().get());
        }
        catch (Exception e) {

        }
        return null;
    }

    public String Strconnection() {
        try {
            Conn = new ApiServerConn(url,"GET");
            return Conn.execute().get();
        }
        catch (Exception e) {

        }
        return null;
    }
}

class ApiServerConn extends AsyncTask<Integer,Integer,String> {

    private URL url;
    private String method;
    private JSONObject json;

    public ApiServerConn(URL url,String method){
        this.url = url;
        this.method = method;
    }

    public ApiServerConn(URL url,String method,JSONObject json){
        this.url = url;
        this.method = method;
        this.json = json;
    }

    protected String doInBackground(Integer... parms) {
        try{
            HttpURLConnection myConnection = (HttpURLConnection) url.openConnection();
            if(method.equals("GET"))
                myConnection.setRequestMethod("GET");
            if(method.equals("POST")){
                myConnection.setRequestMethod("POST");
                myConnection.setRequestProperty("Accept", "application/json");
                myConnection.setRequestProperty("Content-Type", "application/json; utf-8");
                myConnection.setDoOutput(true);
                myConnection.setDoInput(true);
                try(OutputStream opstrm = myConnection.getOutputStream()) {
                    byte[] input = json.toString().getBytes("utf-8");
                    opstrm.write(input,0,input.length);
                    opstrm.flush();
                }

            }

            if (myConnection.getResponseCode() == 200) {
                BufferedReader br = new BufferedReader(new InputStreamReader(myConnection.getInputStream()));
                StringBuilder sb = new StringBuilder();
                String line = null;
                while((line = br.readLine()) != null) {
                    sb.append(line);
                }
                return sb.toString();
            }
            else {
                return "Error";
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }

}
