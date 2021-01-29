package com.example.siins_android;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import androidx.core.content.ContextCompat;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;

public class ListAdapter extends BaseAdapter {

    Context mContext = null;
    LayoutInflater mLayoutInflater = null;
    ArrayList<SampleData> sample;

    public ListAdapter(Context context, ArrayList<SampleData> data) {
        mContext = context;
        sample = data;
        mLayoutInflater = LayoutInflater.from(mContext);
    }

    @Override
    public int getCount() {
        return sample.size();
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public SampleData getItem(int position) {
        return sample.get(position);
    }

    @Override
    public View getView(int position, View converView, ViewGroup parent) {
        View view = mLayoutInflater.inflate(R.layout.listview, null);

        TextView Title = (TextView)view.findViewById(R.id.Title);
        TextView Subject = (TextView)view.findViewById(R.id.Subject);
        TextView Dayleft = (TextView)view.findViewById(R.id.dayleft);

        Title.setText(sample.get(position).GetTitle());
        Subject.setText(sample.get(position).GetSubject());


        SimpleDateFormat format2 = new SimpleDateFormat("yyyy-MM-dd");
        try {
            Date date = sample.get(position).GetDate();
            Date now = format2.parse(format2.format(new Date()));

            long diff = date.getTime() - now.getTime();
            long diffDays = diff / (24*60*60*1000);

            diffDays = Math.abs(diffDays);

            int myRed = ContextCompat.getColor(mContext, R.color.red_color);
            int myGreen = ContextCompat.getColor(mContext, R.color.green_color);
            int myYellow = ContextCompat.getColor(mContext, R.color.yellow_color);

            Dayleft.setText("D-"+diffDays);
            if(diffDays == 0) {
                Dayleft.setTextColor(myRed);
                Dayleft.setText("D-Day");
            }
            else if(diffDays<=1) {
                Dayleft.setTextColor(myRed);
                Dayleft.setText("D-"+diffDays);
            }
            else if(diffDays<=4) {
                Dayleft.setTextColor(myYellow);
            }
            else {
                Dayleft.setTextColor(myGreen);
            }




        } catch (ParseException e) {
            e.printStackTrace();
        }

        return view;
    }
}
