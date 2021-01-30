package com.example.siins_android;

import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.CalendarView;
import android.widget.ListView;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;


public class EventFragment extends Fragment {

    CalendarView cal;
    ListView listView;
    SimpleDateFormat format2;


    public EventFragment(){

    }

    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.event, container, false);

        cal = (CalendarView) v.findViewById(R.id.calender);
        listView = (ListView) v.findViewById(R.id.listViewEvent);
        format2 = new SimpleDateFormat("yyyy-MM-dd");

        Run(new Date());


        cal.setOnDateChangeListener(new CalendarView.OnDateChangeListener() {
            @Override
            public void onSelectedDayChange(@NonNull CalendarView view, int year, int month, int dayOfMonth) {
                try {
                    month += 1;
                    Date a = format2.parse(String.format(year+"-"+month+"-"+dayOfMonth));
                    Run(a);
                } catch (ParseException e) {
                    e.printStackTrace();
                }
            }
        });
        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView parent, View v, int position, long id) {
                SampleData item = (SampleData) parent.getItemAtPosition(position);
                Intent intent = new Intent(getActivity(), DetailsActivity.class);
                intent.putExtra("detail",item);
                startActivity(intent);
            }
        });

        return v;
    }

    private void Run(Date date) {
        ArrayList<SampleData> a,b;
        b = new ArrayList<SampleData>();
        a = HomeworkList.GetList();
        for(SampleData c : a) {
            if(format2.format(c.GetDate()).equals(format2.format(date))){
                b.add(c);
            }
        }
        final ListAdapter c = new ListAdapter(getActivity(), b);
        listView.setAdapter(c);
    }
}
